import { Transaction } from '@/models/Transaction';
export interface TransactionWithNames extends Transaction {
    PersonName: string,
    CategoryName: string
}