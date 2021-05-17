import { componentFactoryName } from '@angular/compiler';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormComponent } from './modules/form/form.component';
import { ShippersComponent } from './modules/shippers/shippers.component';
import { UpdateComponent } from './modules/update/update.component';

const routes: Routes = [
  {
    path:'shippers',
    component: ShippersComponent
    
  },
  {
    path:'shippers/update/:id',
    component: UpdateComponent
  },
  {
    path:'shippers/form',
    component: FormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
