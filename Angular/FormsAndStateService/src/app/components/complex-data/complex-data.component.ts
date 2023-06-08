import { Component, OnInit, effect } from '@angular/core';
import { AsyncPipe, CommonModule, JsonPipe, NgFor, NgIf } from '@angular/common';
import { ComplexDataStateService } from './state/comlext-data.state';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { OrderReponse, Product } from 'src/app/models/product.model';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddProductComponent } from '../add-product/add-product.component';
import { Order } from 'src/app/models/order.model';
import { EditProductItemComponent } from '../edit-product-item/edit-product-item.component';
import { EditProductListComponent } from '../edit-product-list/edit-product-list.component';
import { Observable } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-complex-data',
  standalone: true,
  providers: [ComplexDataStateService],
  imports: [
    AddProductComponent,
    EditProductListComponent,
    FormsModule,
    ReactiveFormsModule,
    JsonPipe,
    MatInputModule,
    NgFor, AsyncPipe, NgIf, MatButtonModule],
  templateUrl: './complex-data.component.html',
  styleUrls: ['./complex-data.component.scss']
})
export class ComplexDataComponent implements OnInit {
  editData$ = this.dataService.fullEditableData$;
  fullData$ = this.dataService.fullData$;
  fullDataSig = toSignal(this.fullData$);

  orders$ = this.dataService.orders$;
  products$ = this.dataService.products$;
  isBusy$ = this.dataService.isBusy$;

  bigForm = this.formBuilder.group({
    orders: new FormControl<Order[]>([]),
    products: new FormControl<Product[]>([])
  })

  save() {
    this.dataService.save(this.bigForm.value as OrderReponse);
  }

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly dataService: ComplexDataStateService) {
  
      // effect(()=> {
      //   this.bigForm.patchValue(this.fullDataSig() as OrderReponse);
      // });
    }

  ngOnInit(): void {
    this.dataService.onChange(this.bigForm.valueChanges as Observable<OrderReponse>);
    this.fullData$.subscribe(p => {
      this.bigForm.patchValue(p as OrderReponse);
    });
    this.dataService.init();
  }

}

