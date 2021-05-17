import { invalid } from '@angular/compiler/src/render3/view/util';
import { Component, Inject, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Shippers } from '../shippers/models/shippers';
import { ShippersService } from '../shippers/shippers.service';





@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {


  form: FormGroup;

  get nameCtrl(): AbstractControl {
    return this.form.get('name');
  }

  get phoneCtrl(): AbstractControl {
    return this.form.get('phone');
  }

  constructor(private fb: FormBuilder, private saveService: ShippersService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required]
    });
  }

  onSubmit(): void {
    var shippers = new Shippers();
    shippers.CompanyName = this.form.get('name').value;
    shippers.Phone = this.form.get('phone').value;
    this.saveService.postShippers(shippers).subscribe(
      (response: Shippers) => console.log(response),
      (error: any) => alert('Ocurio un error!'),
      () => {
        alert('Empleado agregado con exito'),
          this.onClear()
      }
    );
  }
  
  onClear(): void {

    console.log(this.form);

    if(this.nameCtrl)
    {
      this.nameCtrl.reset();
    }
    if(this.phoneCtrl)
    {
      this.phoneCtrl.reset();
    }

  }

}
