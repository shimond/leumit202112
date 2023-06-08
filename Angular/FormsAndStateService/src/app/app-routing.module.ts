import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComplexDataComponent } from './components/complex-data/complex-data.component';

const routes: Routes = [{
  path:'', component: ComplexDataComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
