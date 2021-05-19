import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Shippers } from '../models/shippers';
import { ShippersService } from '../services/shippers.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap'
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit, OnDestroy {

  public cardShow: boolean = false;
  public closeResult = '';

  public listShippers: Shippers[];
  public shippers: Shippers;
  public shipperParent: Shippers;

  private subscription: Subscription;

  formSearch: FormGroup;


  constructor(private formBuilder: FormBuilder,
    private shippersService:
      ShippersService,
    private modalService: NgbModal) {
  }

  // Metodos principales..

  ngOnInit(): void {
    this.subscription = new Subscription();
    this.shipperParent = new Shippers();
    this.shippers = new Shippers();
    this.formSearch = this.formBuilder.group({
      search: new FormControl('', Validators.required)
    }),
    this.getShippers();
  }

  searchShippers(event) {
    this.subscription.add(
      this.shippersService.readShippers(event).subscribe(
        resp => {
          this.shippers = resp;
        },
        error => { console.log(error), Swal.fire('Algo salio mal!','No se encontro el registro solicitado!', 'error') },
        () => {this.cardShow = true},
      ))
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
        (error: any) => Swal.fire('Algo salio mal!','No se pudo eliminar el registro solicitado!', 'error'),
        () => {
          Swal.fire('Yeah!', 'Empleado eliminado con exito!', 'success')
          this.getShippers()
        },
      ));
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
      title: 'Estas seguro?',
      text: 'No podras recuperar este registro!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si, eliminar!',
      cancelButtonText: 'No, mantener',
    }).then((result) => {

      if (result.isConfirmed) {

        this.deleteShippers(id);

      }
    })

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    console.log("main destroy");
  }


}
