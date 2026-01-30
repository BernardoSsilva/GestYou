import { DataTable } from "@/components/datatable";
import { TransactionsPerCategory } from "@/models/TransactionsPerCategory";
import { ColumnDef } from "@tanstack/react-table";

export default function TotalPerPersonScreen() {
    const columns: ColumnDef<TransactionsPerCategory>[] = [
        {
            accessorKey: "CategoryId",
            header: "id",
        },
        {
            accessorKey: "CategoryName",
            header: "Nome",
        },
        {
            accessorKey: "TotalRevenues",
            header: "Receitas totais",
        },
        {
            accessorKey: "TotalExpenses",
            header: "Despesas totais",
        },
    ]
    return (
        <main>
            <header>
                <h1 className="font-bold text-4xl w-full mb-2   border-b-2  border-b-gray-200">
                    Total por Categoria
                </h1>
            </header>

            <section>

            </section>

            <DataTable columns={columns} data={[]} />

        </main>
    )
}