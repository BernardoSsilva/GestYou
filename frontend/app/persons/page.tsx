"use client"

import { DataTable } from "@/components/datatable";
import { Person } from "@/models/Person";
import { ColumnDef } from "@tanstack/react-table"
import { Button } from "@/components/ui/button"
import { Pencil, Plus, Trash } from "lucide-react";
import { useState } from "react";
import { UpdatePersonModal } from "./updatePersonModal";

export default function PersonsScreen() {

    const [selectedPerson, setSelectedPerson] = useState<Person | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);

    const columns: ColumnDef<Person>[] = [
        {
            accessorKey: "Id",
            header: "id",
        },
        {
            accessorKey: "Name",
            header: "Nome",
        },
        {
            accessorKey: "Age",
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
                        <Button variant='outline' className="border-[#ff1c1c]">
                            <Trash color="#ff1c1c" />
                        </Button>
                    </div>
                )
            },
        },
    ]
    return (
        <main className="w-full h-full flex flex-col">
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
            <DataTable columns={columns} data={[
                { Id: 1, Age: 18, Name: 'Bernardo' }
            ]} />

        </main>
    )
}