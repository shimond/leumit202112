import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, filter, map, take } from "rxjs";
import { ApiService } from "src/app/core/core/api.service";
import { OrderReponse, Product } from "src/app/models/product.model";

@Injectable()
export class ComplexDataStateService {


    private fullDataSubject$ = new BehaviorSubject<OrderReponse | null>(null);
    private isBusySubject$ = new BehaviorSubject<boolean>(false);
    private editableDataSubject$ = new BehaviorSubject<OrderReponse | null>(null);

    fullEditableData$ = this.editableDataSubject$.asObservable();
    isBusy$ = this.isBusySubject$.asObservable();
    fullData$ = this.fullDataSubject$.pipe(filter(o => o !== null));
    orders$ = this.fullData$.pipe(map(o => o?.orders));
    products$ = this.fullData$.pipe(map(o => o?.products));
    expensiveProducts$ = this.products$.pipe(map(x => x?.filter(o => o.price > 10)));

    constructor(private api: ApiService) {

    }

    init() {
        this.isBusySubject$.next(true);
        this.api.getCurrentItemsByUser().pipe(take(1)).subscribe(p => {
            this.fullDataSubject$.next(p);
            this.isBusySubject$.next(false);
        });

    }

    onChange(items: Observable<OrderReponse>) {
        items.subscribe(o => {
            this.editableDataSubject$.next(o);
        });
    }


    save(req: OrderReponse) {
        this.fullDataSubject$.next(req);
    }


    add(p: Product) {
        this.isBusySubject$.next(true);
        setTimeout(() => {
            const ordersAndProducts = this.fullDataSubject$.value;
            const productsToUpdate = ordersAndProducts!.products.map(o => {
                if (o.id === 2) {
                    return { ...o, price: 800 }
                }
                return o;
            });

            this.fullDataSubject$.next({
                products: [...productsToUpdate, { id: 99, name: p.name, price: p.price }],
                orders: ordersAndProducts!.orders
            });
            this.isBusySubject$.next(false);
        }, 1500);
    }

}