import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Shippers } from './models/shippers';
import { ShippersService } from './shippers.service';



@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit {

  form: FormGroup;
  formSearch: FormGroup;
  public shippers: Shippers;
  public listShippers: Shippers[] = [];

  get nameCtrl(): AbstractControl {
    return this.form.get('name');
  }
  get phoneCtrl(): AbstractControl {
    return this.form.get('phone');
  }

  constructor(private formBuilder: FormBuilder,
    private shippersService: ShippersService,
  ) {

  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: new FormControl('', Validators.required),
      phone: new FormControl('', Validators.required)
    });

    this.formSearch = this.formBuilder.group({
      search: new FormControl('', Validators.required)
    });

  }

  save() {
    var shippers = new Shippers();
    shippers.CompanyName = this.form.get('name').value;
    shippers.Phone = this.form.get('phone').value;
    this.shippersService.postShippers(shippers).subscribe(
      (response: Shippers) => console.log(response),
      (error: any) => alert('Ocurio un error!'),
      () => {
        alert('Empleado agregado con exito'),
          this.onClear(),
          this.getShippers()
      }
    );
  }

  searchShippers(event) {
    this.shippersService.readShippers(event).subscribe(
      resp => {
        this.shippers = resp;
      },
      error => { console.log(error) });
  }

  getShippers() {
    this.shippersService.getShippers().subscribe(
      resp => {
        this.listShippers = resp;
      },
      error => { console.log(error) });
  }

  deleteShippers(id: number ) {
    if (confirm('Are you sure to delete??')) {

      this.shippersService.deleteShippers(id).subscribe(
        resp => {
          console.log(resp);
        },
        (error: any) => alert('Ocurio un error!'),
        () => {
          alert('Empleado eliminado con exito'),
            this.getShippers()
        },
      )
    }
  }

  updateShippers(shipper: Shippers) {
    shipper.CompanyName = this.form.get('name').value;
    shipper.Phone = this.form.get('phone').value;
    this.shippersService.updateShippers(shipper).subscribe(
      resp => {
        console.log(resp);
      },
      (error: any) => alert('Ocurio un error!'),
      () => {
        alert('Empleado updateado con exito'),
          this.getShippers()
      },
    )
  }



  onClear(): void {

    console.log(this.form);

    if (this.nameCtrl) {
      this.nameCtrl.reset();
    }
    if (this.phoneCtrl) {
      this.phoneCtrl.reset();
    }

  }

}
