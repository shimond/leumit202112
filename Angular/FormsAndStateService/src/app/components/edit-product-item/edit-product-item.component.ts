import { Component, OnInit } from '@angular/core';
import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';
import {
  AbstractControl, ControlValueAccessor, FormBuilder, FormControl, FormsModule,
  NG_VALIDATORS,
  NG_VALUE_ACCESSOR, ReactiveFormsModule, ValidationErrors, Validator, Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-edit-product-item',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    NgFor,
    AsyncPipe,
    NgIf,
    MatButtonModule],
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: EditProductItemComponent,
      multi: true
    },
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: EditProductItemComponent,
      multi: true
    }],
  templateUrl: './edit-product-item.component.html',
  styleUrls: ['./edit-product-item.component.scss']
})
export class EditProductItemComponent implements OnInit, ControlValueAccessor, Validator {

  editForm = this.fb.group({
    id: new FormControl<number>(-1),
    name: new FormControl<string>('', [Validators.required]),
    price: new FormControl<number | null>(null),
    bmi: new FormControl<number>(0)
  });

  callBack?: Function;

  constructor(
    private readonly fb: FormBuilder,
  ) {
  }

  ngOnInit(): void {
    this.editForm.controls.price.valueChanges.subscribe(o => {
      if (o) {
        this.editForm.controls.bmi.setValue(o / 2);
      }
    });

    this.editForm.valueChanges.subscribe(o => {
      if (this.callBack) {
        this.callBack(o);
      }
    });
  }

  validate(control: AbstractControl): ValidationErrors | null {
    if (this.editForm.valid) {
      return null;
    }
    return { 'EditProductItemComponent': 'not-valid' };
  };

  writeValue(obj: Product): void {
    this.editForm.patchValue({...obj, price:obj.price > 10 ? null : obj.price}, { emitEvent: false });
  }

  registerOnChange(fn: any): void {
    this.callBack = fn;
  }

  registerOnTouched(fn: any): void {
  }

  setDisabledState?(isDisabled: boolean): void {
    if (isDisabled) {
      this.editForm.disable();
    } else {
      this.editForm.enable();
    }
  }


}
