import { Button } from "@/components/ui/button";
import {
    Dialog,
    DialogContent,
    DialogFooter,
    DialogHeader,
    DialogTitle
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue
} from "@/components/ui/select";
import { Category } from "@/models/Category";
import { Person } from "@/models/Person";
import { Transaction } from "@/models/Transaction";
import { TransactionTypeEnum, TypeLabels } from "@/models/TransactionTypeEnum";
import { api } from "@/services/api";
import { useEffect, useState } from "react";
import { toast } from "sonner";

type TypeKey = keyof typeof TransactionTypeEnum;

type ModalProps = {
    selectedTransaction: Transaction | null;
    isOpen: boolean;
    setIsDialogOpen: (value: boolean) => void;
};

export function UpdateTransactionModal({
    isOpen,
    selectedTransaction,
    setIsDialogOpen
}: ModalProps) {
    const [selectedTransactionDescription, setSelectedTransactionDescription] =
        useState<string>("");
    const [selectedTransactionValue, setSelectedTransactionValue] =
        useState<number | undefined>();
    const [selectedTransactionType, setSelectedTransactionType] =
        useState<TypeKey>("Expense");
    const [selectedTransactionCategory, setSelectedTransactionCategory] =
        useState<number | undefined>();
    const [selectedTransactionPerson, setSelectedTransactionPerson] =
        useState<number | undefined>();

    const [categoriesData, setCategoriesData] = useState<Category[]>([]);
    const [personsData, setPersonsData] = useState<Person[]>([]);

    const fetchData = async () => {
        const { data: categoriesFetchedData } = await api.get("Category");
        const { data: personsFetchedData } = await api.get("Person");

        setCategoriesData(categoriesFetchedData);
        setPersonsData(personsFetchedData);
    };

    const onSave = async () => {
        try {

            const payload = {
                description: selectedTransactionDescription,
                value: selectedTransactionValue,
                Type: TransactionTypeEnum[selectedTransactionType],
                personId: selectedTransactionPerson,
                categoryId: selectedTransactionCategory
            }
            if (selectedTransaction) {
                await api.put(`/Transaction/${selectedTransaction.id}`, payload)
                toast.success("Transação alterada com sucesso")

            } else {
                await api.post("/Transaction", payload)
                toast.success("Transação criada com sucesso")

            }
        } catch {
            toast.error("Erro ao salvar transação")

        }

        setIsDialogOpen(false)
    }
    useEffect(() => {
        if (!isOpen) return;

        fetchData();

        setSelectedTransactionDescription(selectedTransaction?.description ?? "");
        setSelectedTransactionValue(selectedTransaction?.value);
        setSelectedTransactionCategory(selectedTransaction?.categoryId);
        setSelectedTransactionPerson(selectedTransaction?.personId);

        if (selectedTransaction?.type !== undefined) {
            setSelectedTransactionType(
                Object.keys(TransactionTypeEnum).find(
                    key => TransactionTypeEnum[key as keyof typeof TransactionTypeEnum] == TransactionTypeEnum[selectedTransaction.type]
                ) as keyof typeof TransactionTypeEnum
            );
        } else {
            setSelectedTransactionType("Expense");
        }
    }, [isOpen, selectedTransaction]);

    return (
        <Dialog open={isOpen} onOpenChange={setIsDialogOpen}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de transação</DialogTitle>
                </DialogHeader>

                <div>
                    Descrição
                    <Input
                        type="text"
                        value={selectedTransactionDescription}
                        onChange={e =>
                            setSelectedTransactionDescription(e.target.value)
                        }
                        placeholder="Insira a descrição"
                    />
                </div>

                <div>
                    Valor
                    <Input
                        type="number"
                        value={selectedTransactionValue ?? ""}
                        onChange={e =>
                            setSelectedTransactionValue(
                                e.target.value
                                    ? parseFloat(e.target.value)
                                    : undefined
                            )
                        }
                        placeholder="Insira o valor"
                    />
                </div>

                <section className="flex justify-between">
                    <div className="w-[50%] mr-2">
                        Tipo
                        <Select
                            value={selectedTransactionType}
                            onValueChange={value =>
                                setSelectedTransactionType(value as TypeKey)
                            }
                        >
                            <SelectTrigger className="w-full">
                                <SelectValue>
                                    {TypeLabels[selectedTransactionType]}
                                </SelectValue>
                            </SelectTrigger>
                            <SelectContent>
                                {Object.keys(TransactionTypeEnum)
                                    .filter(key => isNaN(Number(key)))
                                    .map(key => (
                                        <SelectItem key={key} value={key}>
                                            {TypeLabels[key as TypeKey]}
                                        </SelectItem>
                                    ))}
                            </SelectContent>
                        </Select>
                    </div>

                    <div className="w-[50%] ml-2">
                        Pessoa
                        <Select
                            value={selectedTransactionPerson?.toString()}
                            onValueChange={value =>
                                setSelectedTransactionPerson(parseInt(value))
                            }
                        >
                            <SelectTrigger className="w-full">
                                <SelectValue placeholder="Pessoa" />
                            </SelectTrigger>
                            <SelectContent>
                                {personsData.map(person => (
                                    <SelectItem
                                        key={person.id}
                                        value={person.id.toString()}
                                    >
                                        {person.name}
                                    </SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>
                </section>

                <div className="w-full">
                    Categoria
                    <Select
                        value={selectedTransactionCategory?.toString()}
                        onValueChange={value =>
                            setSelectedTransactionCategory(parseInt(value))
                        }
                    >
                        <SelectTrigger className="w-full">
                            <SelectValue placeholder="Categoria" />
                        </SelectTrigger>
                        <SelectContent>
                            {categoriesData
                                .filter(category =>
                                    selectedTransactionType === "Expense"
                                        ? category.finality === "Expense" ||
                                        category.finality === "Both"
                                        : category.finality === "Revenue" ||
                                        category.finality === "Both"
                                )
                                .map(category => (
                                    <SelectItem
                                        key={category.id}
                                        value={category.id.toString()}
                                    >
                                        {category.description}
                                    </SelectItem>
                                ))}
                        </SelectContent>
                    </Select>
                </div>

                <DialogFooter>
                    <Button className="bg-emerald-600" onClick={onSave} disabled={
                        !selectedTransactionDescription ||
                        selectedTransactionValue === undefined ||
                        selectedTransactionPerson === undefined ||
                        selectedTransactionCategory === undefined ||
                        selectedTransactionType === undefined
                    }>
                        Salvar
                    </Button>
                    <Button
                        className="bg-gray-500"
                        onClick={() => setIsDialogOpen(false)}
                    >
                        Cancelar
                    </Button>
                </DialogFooter>
            </DialogContent>
        </Dialog >
    );
}
