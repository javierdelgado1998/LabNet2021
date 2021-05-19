import { invalid } from '@angular/compiler/src/render3/view/util';
import { Component, Inject, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Shippers } from '../models/shippers';
import { ShippersService } from '../services/shippers.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit, OnDestroy {
  
  private sucessSubmit: boolean;

  @Input() shipperChild: Shippers;
  @Output() messageEvent = new EventEmitter<boolean>();

  private subscription: Subscription;
  
  form: FormGroup;

  get nameCtrl(): AbstractControl {
    return this.form.get('name');
  }

  get phoneCtrl(): AbstractControl {
    return this.form.get('phone');
  }

  constructor(private fb: FormBuilder, private saveService: ShippersService) { }

  ngOnInit(): void {
    this.subscription = new Subscription();
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(40), Validators.pattern('[a-zA-Z ]*')]],
      phone: ['', [Validators.required, Validators.maxLength(24), Validators.pattern('^[0-9\()\-\-\+\ ]+$')]]
    });
  }

  onSubmit(): void {
    if(this.shipperChild.ShipperID == null)
    {
      var shippers = new Shippers();
      shippers.CompanyName = this.form.get('name').value;
      shippers.Phone = this.form.get('phone').value;
      this.subscription.add(
      this.saveService.postShippers(shippers).subscribe(
        (response: Shippers) => {console.log(response)},
        (error: any) => {this.sucessSubmit=false, this.messageEvent.emit(this.sucessSubmit), console.log(error)},
        () => {this.sucessSubmit=true, this.messageEvent.emit(this.sucessSubmit), this.onClear()},
      ));
    }
    else
    {
      this.shipperChild.CompanyName = this.form.get('name').value;
      this.shipperChild.Phone = this.form.get('phone').value;
      this.subscription.add(
      this.saveService.updateShippers(this.shipperChild).subscribe(
        (response: Shippers) => {console.log(response)},
        (error: any) => {this.sucessSubmit=false, this.messageEvent.emit(this.sucessSubmit), console.log(error)},
        () => {this.sucessSubmit=true, this.messageEvent.emit(this.sucessSubmit), this.onClear()},
      ));
    }

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

  ngOnDestroy() {
    this.subscription.unsubscribe;
    console.log("form destroy");
  }

}
