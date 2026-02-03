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

export default function CategoriesScreen() {

    const [categoriesData, setCategoriesData] = useState<Category[]>([]);

    const [selectedCategory, setSelectedCategory] = useState<Category | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);

    var fetchData = async () => {
        var { data } = await api.get("/Category")

        console.log(data)
        setCategoriesData(data)
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
                    <div>
                        <p>

                            {FinalityLabels[category.finality as keyof typeof FinalityEnum]}
                        </p>
                    </div>
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
            <DataTable columns={columns} data={
                categoriesData
            } />

        </main>
    )
}