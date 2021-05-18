import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { Shippers } from './models/shippers';
import { ShippersService } from './shippers.service';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap'
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit, OnDestroy {

  closeResult = '';
  private subscription: Subscription = new Subscription();
  formSearch: FormGroup;
  public shippers: Shippers;
  public listShippers: Shippers[] = [];
  shipperParent: Shippers = new Shippers();

  constructor(private formBuilder: FormBuilder, 
    private shippersService: 
    ShippersService, 
    private modalService:NgbModal) {
    //Refrescar la lista
    this.getShippers();
  }

  ngOnInit(): void {
    this.formSearch = this.formBuilder.group({
      search: new FormControl('', Validators.required)
    });
  }

  searchShippers(event) {
    this.subscription.add(
    this.shippersService.readShippers(event).subscribe(
      resp => {
        this.shippers = resp;
      },
      error => { console.log(error) }));
  }

  getShippers() {
    this.subscription.add(
    this.shippersService.getShippers().subscribe(
      resp => {
        this.listShippers = resp;
      },
      error => { alert("Ocurrio un error al mostrar los datos!")}));
  }

  deleteShippers(id: number ) {
    if (confirm('Are you sure to delete??')) {
      this.subscription.add(
      this.shippersService.deleteShippers(id).subscribe(
        resp => {
          console.log(resp);
        },
        (error: any) => alert('Ocurio un error!'),
        () => {
          alert('Empleado eliminado con exito'),
            this.getShippers()
        },
      ));
    }
  }
  //Falta ver el tema de ng on Destroy
  updateShippers(shipper: Shippers) {
    this.subscription.add(
    this.shippersService.updateShippers(shipper).subscribe(
      resp => {
        console.log(resp);
      },
      (error: any) => alert('Ocurio un error!'),
      () => {
        alert('Empleado updateado con exito'),
          this.getShippers()
      },
    ));
  }

  open(content) {
    this.modalService.open(content,{ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.shipperParent.ShipperID = null;
      this.shipperParent.CompanyName = null;
      this.shipperParent.Phone = null;
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  receiveMessage($event) {
    if($event)
    {
      alert("Operacion exitosa!");
      
      this.getShippers();
    }
    else
    {
      alert("Algo salio mal!");
    }
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  getUpdate(shipper: Shippers)
  {
    this.shipperParent.ShipperID = shipper.ShipperID;
    this.shipperParent.CompanyName = shipper.CompanyName;
    this.shipperParent.Phone = shipper.Phone;
  }



}
