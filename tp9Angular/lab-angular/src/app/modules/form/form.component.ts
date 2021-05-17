import { invalid } from '@angular/compiler/src/render3/view/util';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';



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

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      phone: ['', Validators.required]
    });
  }

  onSubmit(): void {
    
    console.log(this.form.value);
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
