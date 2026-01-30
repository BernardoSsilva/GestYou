import { Transaction } from '@/models/Transaction';
export interface TransactionDto extends Transaction {
    PersonName: string,
    CategoryName: string
}