"use client"

import { DataTable } from "@/components/datatable";
import { Person } from "@/models/Person";
import { ColumnDef } from "@tanstack/react-table"
import { Button } from "@/components/ui/button"
import { Pencil, Plus, Trash } from "lucide-react";
import { useEffect, useState } from "react";
import { UpdatePersonModal } from "./updatePersonModal";
import { api } from "@/services/api";
import { DeleteConfirmationDialog } from "@/components/deleteConfirmationDialog";
import { toast } from "sonner";

export default function PersonsScreen() {

    const [personsData, setPersonsData] = useState<Person[]>([]);

    const [selectedPerson, setSelectedPerson] = useState<Person | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);
    const [isDeleteDialogOpen, setIsDeleteDialogOpen] = useState(false)


    const fetchData = async () => {
        const { data } = await api.get("/Person")

        setPersonsData(data)
    }

    var onConfirmDelete = async () => {
        try {
            await api.delete(`/Person/${selectedPerson?.id}`)
            fetchData()
            toast.success("Item excluído com sucesso")
        } catch {
            toast.error("Erro ao realizar a exclusão")
        }


        setIsDeleteDialogOpen(false)
    }

    useEffect(() => {
        fetchData()
    }, [isDialogOpen])


    const columns: ColumnDef<Person>[] = [
        {
            accessorKey: "id",
            header: "id",
        },
        {
            accessorKey: "name",
            header: "Nome",
        },
        {
            accessorKey: "age",
            header: "Idade",
        },
        {
            id: "actions",
            cell: ({ row }) => {
                const person = row.original

                return (
                    <div className="flex justify-end gap-2">
                        <Button variant='outline' className="border-[#f1a800]" onClick={() => {
                            setSelectedPerson(person)
                            setIsDialogOpen(true)
                        }}>
                            <Pencil color="#f1a800" />
                        </Button>
                        <Button variant='outline' className="border-[#ff1c1c]" onClick={
                            () => {
                                setSelectedPerson(person)
                                setIsDeleteDialogOpen(true);
                            }
                        }>
                            <Trash color="#ff1c1c" />
                        </Button>
                    </div>
                )
            },
        },
    ]
    return (
        <main className="w-full h-full flex flex-col">

            <DeleteConfirmationDialog isOpen={isDeleteDialogOpen} onConfirmDelete={onConfirmDelete} setIsDialogOpen={(value) => setIsDeleteDialogOpen(value)} />

            <UpdatePersonModal selectedPerson={selectedPerson}
                isOpen={isDialogOpen}
                setIsDialogOpen={(value) => setIsDialogOpen(value)} />

            <header>
                <h1 className="font-bold text-4xl w-full mb-2 border-b-2  border-b-gray-200 ">
                    Cadastro de Pessoas
                </h1>

            </header>

            <section className="w-full mb-2 flex justify-end">
                <Button className="bg-emerald-600" onClick={() => {
                    setSelectedPerson(null)
                    setIsDialogOpen(true)
                }}>
                    <Plus />
                    Nova Pessoa
                </Button>
            </section>
            <DataTable columns={columns} data={personsData.sort((a, b) => { return a.id - b.id })} />

        </main>
    )
}