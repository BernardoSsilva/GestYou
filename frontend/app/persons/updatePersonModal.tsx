import { Person } from "@/models/Person";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import { Input } from "@/components/ui/input";
import { useEffect, useState } from "react";
import { Button } from "@/components/ui/button";

type ModalProps = {
    selectedPerson: Person | null,
    isOpen: boolean,
    setIsDialogOpen: (value: boolean) => void
}
export function UpdatePersonModal(
    { isOpen, selectedPerson, setIsDialogOpen }: ModalProps
) {
    const [selectedPersonName, setSelectedPersonName] = useState<string | undefined>()
    const [selectedPersonAge, setSelectedPersonAge] = useState<number | undefined>()

    useEffect(() => {
        setSelectedPersonName(selectedPerson?.Name)
        setSelectedPersonAge(selectedPerson?.Age)
    }, [isOpen])



    return (

        <Dialog open={isOpen} onOpenChange={(value) => { setIsDialogOpen(value) }}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de pessoa</DialogTitle>
                </DialogHeader>
                <div>
                    Nome
                    <Input type="text" id="person-new-name" value={selectedPersonName} onChange={e => setSelectedPersonName(e.target.value)} placeholder="insira o nome" />
                </div>
                <div>
                    Idade
                    <Input type="number" id="person-new-age" value={selectedPersonAge} onChange={e => setSelectedPersonAge(parseInt(e.target.value))} placeholder="insira a idade" />
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