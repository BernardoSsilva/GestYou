"use client"

import { DataTable } from "@/components/datatable";
import { Button } from "@/components/ui/button";
import { Transaction } from "@/models/Transaction";
import { TransactionTypeEnum, TypeLabels } from "@/models/TransactionTypeEnum";
import { ColumnDef } from "@tanstack/react-table";
import { Pencil, Plus, Trash } from "lucide-react";
import { useEffect, useState } from "react";
import { UpdateTransactionModal } from "./updateTransactionModal";
import { TransactionWithNames } from "@/models/TransactionWithNames";
import { api } from "@/services/api";
import { DeleteConfirmationDialog } from "@/components/deleteConfirmationDialog";
import { toast } from "sonner";

export default function TransactionScreen() {

    const [selectedTransaction, setSelectedTransaction] = useState<TransactionWithNames | null>(null);

    const [isDialogOpen, setIsDialogOpen] = useState(false);
    const [isDeleteDialogOpen, setIsDeleteDialogOpen] = useState(false)

    const [transactionsData, setTransactionsData] = useState<TransactionWithNames[]>([])

    const fetchData = async () => {
        const { data } = await api.get("Transaction")

        setTransactionsData(data);
    }

    var onConfirmDelete = async () => {
        try {
            await api.delete(`/Transaction/${selectedTransaction?.id}`)
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

    const columns: ColumnDef<TransactionWithNames>[] = [
        {
            accessorKey: "id",
            header: "id",
        },
        {
            accessorKey: "description",
            header: "descrição",
        },
        {
            accessorKey: "value",
            header: "Valor",
            cell: ({ row }) => {
                const { value } = row.original

                const formattedValue = new Intl.NumberFormat("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                }).format(value)

                return (
                    <p>
                        {formattedValue}
                    </p>
                )
            }
        },
        {
            accessorKey: "type",
            header: "Tipo",
            cell: ({ row }) => {

                const transaction = row.original
                return <p>{TypeLabels[transaction.type as unknown as keyof typeof TransactionTypeEnum]}</p>
            }
        },
        {
            accessorKey: "categoryName",
            header: "Categoria",
        },
        {
            accessorKey: "personName",
            header: "Pessoa",
        },
        {
            id: "actions",
            cell: ({ row }) => {
                const transactionWithName = row.original

                return (
                    <div className="flex justify-end gap-2">
                        <Button variant='outline' className="border-[#f1a800]" onClick={() => {
                            setSelectedTransaction(transactionWithName)
                            setIsDialogOpen(true)
                        }}>
                            <Pencil color="#f1a800" />
                        </Button>
                        <Button variant='outline' className="border-[#ff1c1c]" onClick={
                            () => {
                                setSelectedTransaction(transactionWithName)
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
            <DataTable columns={columns} data={transactionsData} />

        </main>
    )
}