import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from '@angular/common/http'

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormComponent } from './form/form.component';
import { ShippersComponent } from './shippers/shippers.component';

@NgModule({
  declarations: [
    FormComponent, ShippersComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ModulesModule { }
