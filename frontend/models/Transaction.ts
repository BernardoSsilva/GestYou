import { TransactionTypeEnum } from "./TransactionTypeEnum"

export interface Transaction {
    Id: number
    Description: string
    Value: number
    Type: TransactionTypeEnum
    CategoryId: number
    PersonId: number
}