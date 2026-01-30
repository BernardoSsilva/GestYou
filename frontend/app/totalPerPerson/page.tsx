import { DataTable } from "@/components/datatable";
import { TransactionsPerPerson } from "@/models/transactionsPerPerson";
import { ColumnDef } from "@tanstack/react-table";

export default function TotalPerPersonScreen() {
    const columns: ColumnDef<TransactionsPerPerson>[] = [
        {
            accessorKey: "PersonId",
            header: "id",
        },
        {
            accessorKey: "PersonName",
            header: "Nome",
        },
        {
            accessorKey: "TotalRevenues",
            header: "Receitas totais",
        },
        {
            accessorKey: "TotalExpenses",
            header: "Despesas totais",
        }, {
            accessorKey: "Balance",
            header: "Saldo",
        },

    ]
    return (
        <main>
            <header>
                <h1 className="font-bold text-4xl w-full mb-2   border-b-2  border-b-gray-200">
                    Total por pessoa
                </h1>
            </header>

            <section>

            </section>

            <DataTable columns={columns} data={[]} />

        </main>
    )
}