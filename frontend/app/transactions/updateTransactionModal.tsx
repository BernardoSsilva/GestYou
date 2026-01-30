import { Button } from "@/components/ui/button";
import {
    Dialog,
    DialogContent,
    DialogFooter,
    DialogHeader,
    DialogTitle
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { FinalityEnum } from "@/models/FinalityEnum";
import { Transaction } from "@/models/Transaction";
import { TransactionTypeEnum } from "@/models/TransactionTypeEnum";
import { useEffect, useState } from "react";

type ModalProps = {
    selectedTransaction: Transaction | null,
    isOpen: boolean,
    setIsDialogOpen: (value: boolean) => void
}
export function UpdateTransactionModal(
    { isOpen, selectedTransaction, setIsDialogOpen }: ModalProps
) {
    const [selectedTransactionDescription, setSelectedTransactionDescription] = useState<string | undefined>()
    const [selectedTransactionValue, setSelectedTransactionValue] = useState<number | undefined>()
    const [selectedTransactionType, setSelectedTransactionType] = useState<TransactionTypeEnum | undefined>(TransactionTypeEnum.expense)
    const [selectedTransactionCategory, setSelectedTransactionCategory] = useState<number>()
    const [selectedTransactionPerson, setSelectedTransactionPerson] = useState<number | undefined>()

    useEffect(() => {
        setSelectedTransactionDescription(selectedTransaction?.Description)
        setSelectedTransactionValue(selectedTransaction?.Value)
        setSelectedTransactionType(selectedTransaction?.Type)
        setSelectedTransactionCategory(selectedTransaction?.CategoryId)
        setSelectedTransactionPerson(selectedTransaction?.PersonId)
    }, [isOpen])



    return (

        <Dialog open={isOpen} onOpenChange={(value) => { setIsDialogOpen(value) }}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de pessoa</DialogTitle>
                </DialogHeader>
                <div>
                    Descrição
                    <Input type="text" id="Category-new-description" value={selectedTransaction?.Description} onChange={e => setSelectedTransactionDescription(e.target.value)} placeholder="insira a descrição" />
                </div>
                <div>
                    Valor
                    <Input type="number" id="transaction-new-value" value={selectedTransactionValue} onChange={e => setSelectedTransactionValue(parseFloat(e.target.value))} placeholder="insira o valor" />
                </div>

                <section className="flex justify-between">
                    <div className="w-[50%] mr-2">
                        Tipo
                        <Select
                            value={selectedTransactionType}
                            onValueChange={(value) => setSelectedTransactionType(value as TransactionTypeEnum)}>
                            <SelectTrigger className="w-full">
                                <SelectValue placeholder="Tipo" />
                            </SelectTrigger>
                            <SelectContent>
                                {Object.values(TransactionTypeEnum).map((type) => (
                                    <SelectItem key={type} value={type}>{type}</SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>

                    <div className="w-[50%] ml-2">
                        Pessoa
                        <Select
                            value={selectedTransactionPerson?.toString()}
                            onValueChange={(value) => setSelectedTransactionPerson(parseInt(value))}>
                            <SelectTrigger className="w-full">
                                <SelectValue placeholder="Pessoa" />
                            </SelectTrigger>
                            <SelectContent>
                                {[].map((item, index) => (
                                    <SelectItem key={index} value={index.toString()}>{item}</SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>
                </section>

                <div className="w-full">
                    Categoria
                    <Select
                        value={selectedTransactionCategory?.toString()}
                        onValueChange={(value) => setSelectedTransactionCategory(parseInt(value))}>
                        <SelectTrigger className="w-full">
                            <SelectValue placeholder="Categoria" />
                        </SelectTrigger>
                        <SelectContent>
                            {[].map((category, index) => (
                                <SelectItem key={category} value={index.toString()}>{category}</SelectItem>
                            ))}
                        </SelectContent>
                    </Select>
                </div>
                <DialogFooter>
                    <Button className="bg-emerald-600" >
                        Salvar
                    </Button>
                    <Button className="bg-gray-500" onClick={() => setIsDialogOpen(false)}>
                        Cancelar
                    </Button>
                </DialogFooter>
            </DialogContent>
        </Dialog>
    )
}