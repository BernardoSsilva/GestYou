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
import { api } from "@/services/api";
import { toast } from "sonner";

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
        setSelectedPersonName(selectedPerson?.name)
        setSelectedPersonAge(selectedPerson?.age)
    }, [isOpen])

    const onSave = async () => {
        try {

            const payload = {
                name: selectedPersonName,
                age: selectedPersonAge
            }
            if (selectedPerson) {
                api.put(`/Person/${selectedPerson.id}`, payload)
                toast.success("Pessoa alterada com sucesso")

            } else {
                api.post("/Person", payload)

                toast.success("Pessoa criada com sucesso")
            }
        } catch {
            toast.error("Erro ao salvar pessoa")
        }

        setIsDialogOpen(false)
    }

    return (

        <Dialog open={isOpen} onOpenChange={(value) => { setIsDialogOpen(value) }}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Edição de pessoa</DialogTitle>
                </DialogHeader>
                <div>
                    Nome
                    <Input type="text" id="person-new-name" value={selectedPersonName} onChange={e => setSelectedPersonName(e.target.value)} placeholder="insira o nome" required />
                </div>
                <div>
                    Idade
                    <Input type="number" id="person-new-age" value={selectedPersonAge} onChange={e => setSelectedPersonAge(parseInt(e.target.value))} placeholder="insira a idade" required />
                </div>
                <DialogFooter>
                    <Button className="bg-emerald-600" onClick={onSave} disabled={!selectedPersonName || selectedPersonName?.length <= 0 || !selectedPersonAge || selectedPersonAge <= 0}>
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