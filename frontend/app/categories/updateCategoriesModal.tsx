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
import { FinalityEnum, FinalityLabels } from "@/models/FinalityEnum";
import { api } from "@/services/api";
import { useEffect, useState } from "react";
import { toast } from "sonner";

type FinalityKey = keyof typeof FinalityEnum;

type ModalProps = {
    selectedCategory: Category | null;
    isOpen: boolean;
    setIsDialogOpen: (value: boolean) => void;
};

export function UpdateCategoriesModal({
    isOpen,
    selectedCategory,
    setIsDialogOpen
}: ModalProps) {

    const [selectedCategoryDescription, setSelectedCategoryDescription] =
        useState<string>("");

    const [selectedCategoryFinality, setSelectedCategoryFinality] =
        useState<FinalityKey>("Both");

    useEffect(() => {
        if (!isOpen) return;

        setSelectedCategoryDescription(selectedCategory?.description ?? "");

        if (selectedCategory?.finality !== undefined) {
            setSelectedCategoryFinality(
                Object.keys(FinalityEnum).find(
                    key =>
                        FinalityEnum[key as keyof typeof FinalityEnum] == FinalityEnum[selectedCategory.finality]
                ) as keyof typeof FinalityEnum
            );
        } else {
            setSelectedCategoryFinality("Both");
        }
    }, [isOpen, selectedCategory]);

    const saveData = async () => {
        const finalityValue = FinalityEnum[selectedCategoryFinality];

        const payload = {
            description: selectedCategoryDescription,
            finality: finalityValue
        };
        try {

            if (selectedCategory) {
                await api.put(`Category/${selectedCategory.id}`, payload);
                toast.success("Categoria alterada com sucesso")

            } else {
                await api.post("Category", payload);
                toast.success("Categoria criada com sucesso")

            }
        } catch {
            toast.error("Erro ao salvar categoria")

        }

        setIsDialogOpen(false);
    };

    return (
        <Dialog open={isOpen} onOpenChange={setIsDialogOpen}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de Categoria</DialogTitle>
                </DialogHeader>

                <div className="space-y-2">
                    <label>Nome</label>
                    <Input
                        value={selectedCategoryDescription}
                        onChange={e => setSelectedCategoryDescription(e.target.value)}
                        placeholder="Insira a descrição"
                        required
                    />
                </div>

                <div className="space-y-2">
                    <label>Finalidade</label>
                    <Select
                        value={selectedCategoryFinality}
                        onValueChange={(value) =>
                            setSelectedCategoryFinality(value as FinalityKey)
                        }
                    >
                        <SelectTrigger className="w-[180px]">
                            <SelectValue>
                                {FinalityLabels[selectedCategoryFinality]}
                            </SelectValue>
                        </SelectTrigger>

                        <SelectContent>
                            {Object.keys(FinalityEnum)
                                .filter(key => isNaN(Number(key)))
                                .map((key) => (
                                    <SelectItem key={key} value={key}>
                                        {FinalityLabels[key as FinalityKey]}
                                    </SelectItem>
                                ))}
                        </SelectContent>
                    </Select>

                </div>

                <DialogFooter>
                    <Button className="bg-emerald-600" onClick={saveData} disabled={selectedCategoryFinality == undefined || selectedCategoryDescription.length <= 0}>
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
        </Dialog>
    );
}
