export enum TransactionTypeEnum {
    Expense = 0,
    Revenue = 1
}

export const TypeLabels: Record<keyof typeof TransactionTypeEnum, string> = {
    Expense: "Despesa",
    Revenue: "Receita"
};