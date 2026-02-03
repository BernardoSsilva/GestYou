"use client"

import { DataTable } from "@/components/datatable";
import { TransactionsPerPerson } from "@/models/TransactionsPerPerson";
import { api } from "@/services/api";
import { ColumnDef } from "@tanstack/react-table";
import { useEffect, useState } from "react";

export default function TotalPerPersonScreen() {

    const [data, setData] = useState<TransactionsPerPerson[]>([]);

    const fetchData = async () => {
        const { data: resultData } = await api.get("/Transaction/byPerson")

        setData(resultData)
    }

    useEffect(() => {
        fetchData()
    }, [])

    const columns: ColumnDef<TransactionsPerPerson>[] = [
        {
            accessorKey: "personId",
            header: "id da pessoa",
        },
        {
            accessorKey: "personName",
            header: "Nome",
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
        }, {
            accessorKey: "balance",
            header: "Saldo",
            cell: ({ row }) => {
                const { balance } = row.original


                const formattedValue = new Intl.NumberFormat("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                }).format(balance)

                const colorClass =
                    balance < 0 ? "text-red-600 font-bold" : balance > 0 ? "text-emerald-600 font-bold" : "text-gray-500"

                return <p className={colorClass} >{formattedValue}</p>
            }
        },

    ]
    return (
        <main className="h-full flex w-full flex-col">
            <header>
                <h1 className="font-bold text-4xl w-full mb-2 border-b-2 border-b-gray-200">
                    Total por pessoa
                </h1>
            </header>

            <DataTable columns={columns} data={data} />

        </main>
    )
}