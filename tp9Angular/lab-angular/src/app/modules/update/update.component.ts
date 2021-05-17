
import { Component, Inject, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Shippers } from '../shippers/models/shippers';
import { ShippersService } from '../shippers/shippers.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  form: FormGroup;
  public shipper: Shippers

  get nameCtrl(): AbstractControl {
    return this.form.get('name');
  }

  get phoneCtrl(): AbstractControl {
    return this.form.get('phone');
  }

  constructor(private fb: FormBuilder, private saveService: ShippersService, private router:ActivatedRoute) { }

  ngOnInit(): void {
    this.saveService.readShippers(this.router.snapshot.params.id).subscribe((result)=>{
      this.shipper = result
    });
    this.form = this.fb.group({
      name: [this.nameCtrl, Validators.required],
      phone: [this.phoneCtrl, Validators.required]
    });
  }

  onSubmit(): void {
    var shippers = new Shippers();
    shippers.CompanyName = this.form.get('name').value;
    shippers.Phone = this.form.get('phone').value;
    this.saveService.updateShippers(shippers).subscribe(
      (response: Shippers) => console.log(response),
      (error: any) => alert('Ocurio un error!'),
      () => {
        alert('Empleado updateado con exito'),
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
