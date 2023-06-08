import { Order } from "./order.model";

export interface Product {
    id?: number;
    name: string;
    price: number;
    bmi?: number;
}


export interface OrderReponse {
    products: Product[];
    orders: Order[]
} 