export enum FinalityEnum {
    Expense = 0,
    Revenue = 1,
    Both = 2
}

export const FinalityLabels: Record<keyof typeof FinalityEnum, string> = {
    Expense: "Despesa",
    Revenue: "Receita",
    Both: "Ambos"
};
