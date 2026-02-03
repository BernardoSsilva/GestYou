"use client"

import { DataTable } from "@/components/datatable";
import { TransactionsPerCategory } from "@/models/TransactionsPerCategory";
import { api } from "@/services/api";
import { ColumnDef } from "@tanstack/react-table";
import { useEffect, useState } from "react";

export default function TotalPerPersonScreen() {
    const [data, setData] = useState<TransactionsPerCategory[]>([])

    const fetchData = async () => {
        const { data: returnData } = await api.get("/Transaction/byCategory")

        console.log(returnData)

        setData(returnData)
    }

    useEffect(() => {
        fetchData();
    }, [])
    const columns: ColumnDef<TransactionsPerCategory>[] = [
        {
            accessorKey: "categoryId",
            header: "id da categoria",
        },
        {
            accessorKey: "categoryDescription",
            header: "Descrição da categoria",
        },
        {
            accessorKey: "totalRevenues",
            header: "Receitas totais",
            cell: ({ row }) => {
                const { totalRevenues } = row.original


                const formattedValue = new Intl.NumberFormat("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                }).format(totalRevenues)

                return <p className="text-emerald-600 font-bold">{formattedValue}</p>
            }
        },
        {
            accessorKey: "totalExpenses",
            header: "Despesas totais",
            cell: ({ row }) => {
                const { totalExpenses } = row.original


                const formattedValue = new Intl.NumberFormat("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                }).format(totalExpenses)

                return <p className="text-red-600 font-bold">{formattedValue}</p>
            }
        },
    ]

    return (
        <main className="h-full flex w-full flex-col">
            <header>
                <h1 className="font-bold text-4xl w-full mb-2 border-b-2  border-b-gray-200">
                    Total por Categoria
                </h1>
            </header>

            <DataTable columns={columns} data={data} />

        </main>
    )
}