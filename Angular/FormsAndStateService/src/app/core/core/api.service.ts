import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { Order } from 'src/app/models/order.model';
import { OrderReponse, Product } from 'src/app/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }


  getCurrentItemsByUser(): Observable<OrderReponse> {
    return of({
      products: [
        { name: 'Bamba', price: 12.6, id: 1 },
        { name: 'Mastik', price: 1.6, id: 2 }
      ],
      orders: [
        { productId: 1, productName: 'Bamba', amount: 4, id: 11123, date: new Date() },
        { productId: 2, productName: 'Mastik', amount: 9, id: 88373, date: new Date() },
      ]
    }).pipe(delay(1500));
  }

}
