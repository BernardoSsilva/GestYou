"use client"

import { DataTable } from "@/components/datatable";
import { Button } from "@/components/ui/button";
import { Category } from "@/models/Category";
import { api } from "@/services/api";
import { ColumnDef } from "@tanstack/react-table";
import { Pencil, Plus, Trash } from "lucide-react";
import { useEffect, useState } from "react";
import { UpdateCategoriesModal } from "./updateCategoriesModal";
import { FinalityEnum, FinalityLabels } from "@/models/FinalityEnum";
import { DeleteConfirmationDialog } from "@/components/deleteConfirmationDialog";
import { toast } from "sonner";

export default function CategoriesScreen() {

    const [categoriesData, setCategoriesData] = useState<Category[]>([]);

    const [selectedCategory, setSelectedCategory] = useState<Category | null>(null);

    const [isDeleteDialogOpen, setIsDeleteDialogOpen] = useState(false)
    const [isDialogOpen, setIsDialogOpen] = useState(false);

    var fetchData = async () => {
        var { data } = await api.get("/Category")

        setCategoriesData(data)
    }

    var onConfirmDelete = async () => {
        try {

            await api.delete(`/Category/${selectedCategory?.id}`)
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


    const columns: ColumnDef<Category>[] = [
        {
            accessorKey: "id",
            header: "id",
        },
        {
            accessorKey: "description",
            header: "Descrição",
        },
        {
            accessorKey: "finality",
            header: "Finalidade",
            cell: ({ row }) => {
                const category = row.original

                return (
                    <p>
                        {FinalityLabels[category.finality as keyof typeof FinalityEnum]}
                    </p>
                )
            }
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
                        <Button variant='outline' className="border-[#ff1c1c]" onClick={() => {
                            setSelectedCategory(category)
                            setIsDeleteDialogOpen(true);
                        }}>
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
            <DataTable columns={columns} data={
                categoriesData.sort((a, b) => { return a.id - b.id })
            } />

        </main>
    )
}