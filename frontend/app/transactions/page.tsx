"use client"

import { DataTable } from "@/components/datatable";
import { Button } from "@/components/ui/button";
import { Transaction } from "@/models/Transaction";
import { TransactionTypeEnum } from "@/models/TransactionTypeEnum";
import { ColumnDef } from "@tanstack/react-table";
import { Pencil, Plus, Trash } from "lucide-react";
import { useState } from "react";
import { UpdateTransactionModal } from "./updateTransactionModal";
import { TransactionWithNames } from "@/models/TransactionWithNames";

export default function TransactionScreen() {

    const [selectedTransaction, setSelectedTransaction] = useState<Transaction | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);

    const columns: ColumnDef<TransactionWithNames>[] = [
        {
            accessorKey: "Id",
            header: "id",
        },
        {
            accessorKey: "Description",
            header: "descrição",
        },
        {
            accessorKey: "Value",
            header: "Valor",
        },
        {
            accessorKey: "Type",
            header: "Tipo",
        },
        {
            accessorKey: "CategoryName",
            header: "Categoria",
        },
        {
            accessorKey: "PersonName",
            header: "Pessoa",
        },
        {
            id: "actions",
            cell: ({ row }) => {
                const transaction = row.original

                return (
                    <div className="flex justify-end gap-2">
                        <Button variant='outline' className="border-[#f1a800]" onClick={() => {
                            setSelectedTransaction(transaction)
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
            <UpdateTransactionModal selectedTransaction={selectedTransaction}
                isOpen={isDialogOpen}
                setIsDialogOpen={(value) => setIsDialogOpen(value)} />

            <header>
                <h1 className="font-bold text-4xl w-full mb-2   border-b-2  border-b-gray-200">
                    Cadastro de Transações
                </h1>

            </header>

            <section className="w-full mb-2 flex justify-end">
                <Button className="bg-emerald-600" onClick={() => {
                    setSelectedTransaction(null)
                    setIsDialogOpen(true)
                }}>
                    <Plus />
                    Nova Transação
                </Button>
            </section>
            <DataTable columns={columns} data={[
                { Id: 1, CategoryId: 1, Description: "teste descrição muito baluda", PersonName: 'teste', PersonId: 1, CategoryName: 'teste', Type: TransactionTypeEnum.expense, Value: 2590.00 }
            ]} />

        </main>
    )
}