import { TransactionTypeEnum } from "./TransactionTypeEnum"

export interface Transaction {
    id: number
    description: string
    value: number
    type: keyof typeof TransactionTypeEnum
    categoryId: number
    personId: number
}