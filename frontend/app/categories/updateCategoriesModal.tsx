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
import { Category } from "@/models/Category";
import { FinalityEnum } from "@/models/FinalityEnum";
import { useEffect, useState } from "react";

type ModalProps = {
    selectedCategory: Category | null,
    isOpen: boolean,
    setIsDialogOpen: (value: boolean) => void
}
export function UpdateCategoriesModal(
    { isOpen, selectedCategory, setIsDialogOpen }: ModalProps
) {
    const [selectedCategoryDescription, setSelectedCategoryDescription] = useState<string | undefined>()
    const [selectedCategoryFinality, setSelectedCategoryFinality] = useState<FinalityEnum | undefined>(FinalityEnum.both)

    useEffect(() => {
        setSelectedCategoryDescription(selectedCategory?.Description)
        setSelectedCategoryFinality(selectedCategory?.Finality)
    }, [isOpen])



    return (

        <Dialog open={isOpen} onOpenChange={(value) => { setIsDialogOpen(value) }}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de pessoa</DialogTitle>
                </DialogHeader>
                <div>
                    Nome
                    <Input type="text" id="category-new-description" value={selectedCategoryDescription} onChange={e => setSelectedCategoryDescription(e.target.value)} placeholder="insira a descrição" />
                </div>
                <div>
                    Finalidade
                    <Select
                        value={selectedCategoryFinality}
                        onValueChange={(value) => setSelectedCategoryFinality(value as FinalityEnum)}>
                        <SelectTrigger className="w-[180px]">
                            <SelectValue placeholder="FInalidade" />
                        </SelectTrigger>
                        <SelectContent>
                            {Object.values(FinalityEnum).map((finality) => (
                                <SelectItem key={finality} value={finality}>{finality}</SelectItem>
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