import { Component } from '@angular/core';
import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';
import { AbstractControl, ControlValueAccessor, FormBuilder, FormControl, FormsModule, NG_VALIDATORS, NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { Product } from 'src/app/models/product.model';
import { EditProductItemComponent } from '../edit-product-item/edit-product-item.component';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-edit-product-list',
  standalone: true,
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: EditProductListComponent,
      multi: true
    },
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: EditProductListComponent,
      multi: true
    }],
  imports:
    [
      EditProductItemComponent,
      FormsModule,
      MatButtonModule,
      ReactiveFormsModule,
      MatInputModule,
      NgFor,
      AsyncPipe,
      NgIf],
  templateUrl: './edit-product-list.component.html',
  styleUrls: ['./edit-product-list.component.scss']
})
export class EditProductListComponent implements ControlValueAccessor, Validator {

  productsArray = this.formBuilder.array([]);
  registerOnChangeCallback: any;

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.productsArray.valueChanges.subscribe(products => {
      if (this.registerOnChangeCallback) {
        this.registerOnChangeCallback(products);
      }
    });
  }
  validate(control: AbstractControl): ValidationErrors | null {
    if (this.productsArray.valid) {
      return null;
    }
    return { 'productsArray': 'not-valid' };
  };


  registerOnChange(fn: any): void {
    this.registerOnChangeCallback = fn;
  }

  removeItem(index: number) {
    this.productsArray.removeAt(index);
  }

  addItem() {
    this.productsArray.push(new FormControl<Product | null>(null));
  }


  writeValue(product: Product[]): void {
    if (!product) {
      return;
    }

    this.productsArray.clear();
    for (let index = 0; index < product.length; index++) {
      this.addItem();
    }
    this.productsArray.patchValue(product, { emitEvent: false });
  }

  registerOnTouched(fn: any): void {
  }

}
