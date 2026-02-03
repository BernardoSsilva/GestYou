import { Transaction } from '@/models/Transaction';
export interface TransactionWithNames extends Transaction {
    personName: string,
    categoryName: string
}