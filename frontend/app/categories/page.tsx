"use client"

import { DataTable } from "@/components/datatable";
import { Button } from "@/components/ui/button";
import { Category } from "@/models/Category";
import { ColumnDef } from "@tanstack/react-table";
import { Pencil, Plus, Trash } from "lucide-react";
import { useState } from "react";
import { UpdateCategoriesModal } from "./updateCategoriesModal";
import { FinalityEnum } from "@/models/FinalityEnum";

export default function CategoriesScreen() {

    const [selectedCategory, setSelectedCategory] = useState<Category | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);

    const columns: ColumnDef<Category>[] = [
        {
            accessorKey: "Id",
            header: "id",
        },
        {
            accessorKey: "Description",
            header: "Descrição",
        },
        {
            accessorKey: "Finality",
            header: "Finalidade",
        },
        {
            id: "actions",
            cell: ({ row }) => {
                const category = row.original

                return (
                    <div className="flex justify-end gap-2">
                        <Button variant='outline' className="border-[#f1a800]" onClick={() => {
                            setSelectedCategory(category)
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
            <UpdateCategoriesModal selectedCategory={selectedCategory}
                isOpen={isDialogOpen}
                setIsDialogOpen={(value) => setIsDialogOpen(value)} />

            <header>
                <h1 className="font-bold text-4xl w-full mb-2 border-b-2  border-b-gray-200">
                    Cadastro de categorias
                </h1>

            </header>

            <section className="w-full mb-2 flex justify-end">
                <Button className="bg-emerald-600" onClick={() => {
                    setSelectedCategory(null)
                    setIsDialogOpen(true)
                }}>
                    <Plus />
                    Nova Categoria
                </Button>
            </section>
            <DataTable columns={columns} data={[
                { Id: 1, Description: 'teste da melhor descrição', Finality: FinalityEnum.expense },
                { Id: 2, Description: 'teste da melhor descrição2 ', Finality: FinalityEnum.revenue }

            ]} />

        </main>
    )
}