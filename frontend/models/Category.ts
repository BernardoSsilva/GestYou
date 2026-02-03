import { FinalityEnum } from "./FinalityEnum";

export interface Category {
    id: number,
    description: string,
    finality: keyof typeof FinalityEnum
}