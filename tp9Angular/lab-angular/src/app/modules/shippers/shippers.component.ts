import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Shippers } from './models/shippers';
import { ShippersService } from './shippers.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap'
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit, OnDestroy {

  cardShow: boolean = false;
  closeResult = '';

  public listShippers: Shippers[] = [];
  public shippers: Shippers;
  public shipperParent: Shippers = new Shippers();

  private subscription: Subscription = new Subscription();
  
  formSearch: FormGroup;


  constructor(private formBuilder: FormBuilder,
    private shippersService:
      ShippersService,
    private modalService: NgbModal) {
    //Refrescar la lista al iniciar..
    this.getShippers();
  }

  // Metodos principales..

  ngOnInit(): void {
    this.formSearch = this.formBuilder.group({
      search: new FormControl('', Validators.required)
    });
  }

  searchShippers(event) {
    this.cardShow = true;
    this.subscription.add(
      this.shippersService.readShippers(event).subscribe(
        resp => {
          this.shippers = resp;
        },
        error => { console.log(error), alert("No se encontro el registro solicitado!") },
      ));
  }

  getShippers() {
    this.subscription.add(
      this.shippersService.getShippers().subscribe(
        resp => {
          this.listShippers = resp;
        },
        error => { alert("Ocurrio un error al mostrar los datos!") }));
  }

  deleteShippers(id: number) {
    this.subscription.add(
      this.shippersService.deleteShippers(id).subscribe(
        resp => {
          console.log(resp);
        },
        (error: any) => Swal.fire('No se pudo eliminar el registro solicitado!', 'error'),
        () => {
          Swal.fire('Yeah!', 'Empleado eliminado con exito!', 'success')
          this.getShippers()
        },
      ));
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  // Metodos secundarios..

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.resetShipper();
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
    if ($event) {
      Swal.fire('Yeah!', 'Operación exitosa!', 'success')
      this.getShippers();
    }
    else {
      Swal.fire("La operación fallo!", 'error');
    }
  }

  getUpdate(shipper: Shippers) {
    this.shipperParent.ShipperID = shipper.ShipperID;
    this.shipperParent.CompanyName = shipper.CompanyName;
    this.shipperParent.Phone = shipper.Phone;
  }

  closeCard() {
    this.cardShow = false;
  }

  resetShipper() {
    this.shipperParent.ShipperID = null;
    this.shipperParent.CompanyName = null;
    this.shipperParent.Phone = null;
  }

  handleWarningAlert(id: number) {

    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this imaginary file!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
    }).then((result) => {

      if (result.isConfirmed) {

        this.deleteShippers(id);

      }
    })

  }


}
