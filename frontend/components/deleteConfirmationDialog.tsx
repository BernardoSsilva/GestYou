
import {
    Dialog,
    DialogContent,
    DialogFooter,
    DialogHeader,
    DialogTitle
} from "@/components/ui/dialog";
import { Button } from "./ui/button";

type ModalProps = {
    isOpen: boolean;
    setIsDialogOpen: (value: boolean) => void;
    onConfirmDelete: () => void;
};


export function DeleteConfirmationDialog({ isOpen, onConfirmDelete, setIsDialogOpen }: ModalProps) {

    return (
        <Dialog open={isOpen} onOpenChange={setIsDialogOpen}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Deseja excluir o registro selecionado?</DialogTitle>
                </DialogHeader>

                <p>
                    Ao excluir este item todos os registros dependentes dele serão excluídos em conjunto
                </p>
                <DialogFooter>
                    <Button className="bg-red-600" onClick={onConfirmDelete} >
                        Excluir
                    </Button>
                    <Button
                        className="bg-gray-500"
                        onClick={() => setIsDialogOpen(false)}
                    >
                        Cancelar
                    </Button>
                </DialogFooter>
            </DialogContent>
        </Dialog>)

}