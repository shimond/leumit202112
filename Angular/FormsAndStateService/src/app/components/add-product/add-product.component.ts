import { Component } from '@angular/core';
import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { Product } from 'src/app/models/product.model';
import { ComplexDataStateService } from '../complex-data/state/comlext-data.state';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    NgFor, AsyncPipe, NgIf, MatButtonModule],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent {
  
  addItemForm = this.fb.group({
    name: new FormControl<string>(''),
    price: new FormControl<number>(0),
  });

  constructor(
    private readonly fb: FormBuilder,
    private readonly dataService: ComplexDataStateService) {
  }

  addNewItem() {
    this.dataService.add(this.addItemForm.getRawValue() as Product);
  }



}
