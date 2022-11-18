import { Component, OnInit } from '@angular/core';
import { Articulo } from 'src/app/shared/models/articulo';
import { ArticuloService } from 'src/app/shared/services/articulo.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Familia } from 'src/app/shared/models/familia';
import { FamiliaService } from 'src/app/shared/services/familia.service';
import { Departamento } from 'src/app/shared/models/departamento';
import { DepartamentoService } from 'src/app/shared/services/departamento.service';
import { Clase } from 'src/app/shared/models/clase';
import { ClaseService } from 'src/app/shared/services/clase.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteArticuloComponent } from 'src/app/shared/modals/confirm-delete-articulo/confirm-delete-articulo.component';
import { MensajeExitoComponent } from 'src/app/shared/modals/mensaje-exito/mensaje-exito.component';
import {MatSnackBar} from '@angular/material/snack-bar';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public formSku!: FormGroup;
  public formArticulo!: FormGroup;

  articulo: Articulo = new Articulo();

  public clases?: Clase[];
  public familias?: Familia[];
  public departamentos?: Departamento[];

  constructor(
    private _articuloService: ArticuloService,
    private _familiaService: FamiliaService,
    private _departamentoService: DepartamentoService,
    private _claseService: ClaseService,
    private _dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.initForms();
    this.getFamilias();
    this.getDepartamentos();
    this.getClases();
  }

  getClases(): void{
    this._claseService.GetAllClases().subscribe(res => {
      if(res){
        this.clases = res;
      }
    })
  }

  getDepartamentos(): void{
    this._departamentoService.GetAllDepartamentos().subscribe(res => {
      if(res){
        this.departamentos = res;
      }
    })
  }

  getFamilias(): void{
    this._familiaService.GetAllFamilias().subscribe(res => {
      if(res){
        this.familias = res;
      }
    })
  }

  initForms() : void{
    //formsku
    this.formSku = new FormGroup({
      id: new FormControl(''),
      sku: new FormControl('', [Validators.required])
    });
    //formarticulo
    this.formArticulo = new FormGroup({
      descontinuado: new FormControl(''),
      nombreArticulo: new FormControl('', [Validators.required]),
      marca: new FormControl('', [Validators.required]),
      modelo: new FormControl('', [Validators.required]),
      idDepartamento: new FormControl('', [Validators.required]),
      idClase: new FormControl('', [Validators.required]),
      idFamilia: new FormControl('', [Validators.required]),
      stock: new FormControl('', [Validators.required]),
      cantidad: new FormControl('', [Validators.required]),
      fechaAlta: new FormControl(''),
      fechaBaja: new FormControl('')
    });
  }

  loadDataOfFormInEntity(): void {
    this.articulo = {
      sku: this.formSku.get('sku')?.value,
      id: this.formSku.get('id')?.value ? this.formSku.get('id')?.value : "0",
      //descontinuado: this.formArticulo.get('descontinuado')?.value,
      nombreArticulo: this.formArticulo.get('nombreArticulo')?.value,
      marca: this.formArticulo.get('marca')?.value,
      modelo: this.formArticulo.get('modelo')?.value,
      idDepartamento: this.formArticulo.get('idDepartamento')?.value,
      idClase: this.formArticulo.get('idClase')?.value,
      idFamilia: this.formArticulo.get('idFamilia')?.value,
      stock: this.formArticulo.get('stock')?.value,
      cantidad: this.formArticulo.get('cantidad')?.value,
      //fechaAlta: this.formArticulo.get('fechaAlta')?.value,
      //fechaBaja: this.formArticulo.get('fechaBaja')?.value,
    }
  }

  pintarDataEnFormulario(res: Articulo): void{
    this.formSku.get('id')?.setValue(res.id);
    this.formArticulo.get('descontinuado')?.setValue(res.descontinuado);
    this.formArticulo.get('nombreArticulo')?.setValue(res.nombreArticulo);
    this.formArticulo.get('marca')?.setValue(res.marca);
    this.formArticulo.get('modelo')?.setValue(res.modelo);
    this.formArticulo.get('idDepartamento')?.setValue(res.idDepartamento);
    this.formArticulo.get('idClase')?.setValue(res.idClase);
    this.formArticulo.get('idFamilia')?.setValue(res.idFamilia);
    this.formArticulo.get('stock')?.setValue(res.stock);
    this.formArticulo.get('cantidad')?.setValue(res.cantidad);
    this.formArticulo.get('fechaAlta')?.setValue(res.fechaAlta);
    this.formArticulo.get('fechaBaja')?.setValue(res.fechaBaja);
  }

  limpiarFormulario(): void{
    this.formSku.get('id')?.setValue('');
    this.formSku.get('sku')?.setValue('');
    this.formArticulo.get('descontinuado')?.setValue('');
    this.formArticulo.get('nombreArticulo')?.setValue('');
    this.formArticulo.get('marca')?.setValue('');
    this.formArticulo.get('modelo')?.setValue('');
    this.formArticulo.get('idDepartamento')?.setValue('');
    this.formArticulo.get('idClase')?.setValue('');
    this.formArticulo.get('idFamilia')?.setValue('');
    this.formArticulo.get('stock')?.setValue('');
    this.formArticulo.get('cantidad')?.setValue('');
    this.formArticulo.get('fechaAlta')?.setValue('');
    this.formArticulo.get('fechaBaja')?.setValue('');
  }

  onSubmitFormSku(): void {
    if(this.formSku.invalid.valueOf()){
      this.limpiarFormulario();
      return;
    }
    this.formSku.get('id')?.setValue('');
    this.formArticulo.get('descontinuado')?.setValue('');
    this.formArticulo.get('nombreArticulo')?.setValue('');
    this.formArticulo.get('marca')?.setValue('');
    this.formArticulo.get('modelo')?.setValue('');
    this.formArticulo.get('idDepartamento')?.setValue('');
    this.formArticulo.get('idClase')?.setValue('');
    this.formArticulo.get('idFamilia')?.setValue('');
    this.formArticulo.get('stock')?.setValue('');
    this.formArticulo.get('cantidad')?.setValue('');
    this.formArticulo.get('fechaAlta')?.setValue('');
    this.formArticulo.get('fechaBaja')?.setValue('');
    let sku = this.formSku.get('sku')?.value;
    this._articuloService.GetArticuloBySku(sku).subscribe(res => {
      if(res){
        this.pintarDataEnFormulario(res);
      }else{
        console.log("Creando nuevo articulo");
      }
    })
  }

  saveArticulo(): void {
    if(this.formArticulo.invalid.valueOf() || this.formSku.invalid.valueOf()){
      return;
    }
    this.loadDataOfFormInEntity();
    this._articuloService.CreateArticulo(this.articulo).subscribe(res => {
      if(res){
        this.pintarDataEnFormulario(res);
      }
    })
  }

  openModalDeleteArticulo(): void{
    if(this.formArticulo.invalid.valueOf() || this.formSku.invalid.valueOf()){
      return;
    }
    const dialogRef = this._dialog.open(ConfirmDeleteArticuloComponent, {
      data: this.formSku.get('sku')?.value
    });

    dialogRef.afterClosed().subscribe(res => {
      if(res){
        this.deleteArticulo();
      }else{
        console.log("cancelado...");
      }
    });
  }

  deleteArticulo(): void{
    this._articuloService.DeleteArticulo(this.formSku.get('sku')?.value).subscribe(res => {
      if(res){
        this._snackBar.openFromComponent(MensajeExitoComponent, {
          duration: 2500
        })
        this.limpiarFormulario();
      }
    });
  }

  UpdateArticulo(): void{
    if(this.formArticulo.invalid.valueOf() || this.formSku.invalid.valueOf()){
      return;
    }
    this.loadDataOfFormInEntity();
    this._articuloService.UpdateArticulo(this.articulo).subscribe(res => {
      if(res){
        this._snackBar.openFromComponent(MensajeExitoComponent, {
          duration: 2500
        });
        this.pintarDataEnFormulario(res);
      }
    })
  }

  getDatos(): void{
    let sku = +this.formArticulo.get('sku')?.value;
    console.log(sku);
    this._articuloService.GetArticuloBySku(sku).subscribe((res: Articulo) => {
      if(res){
        console.log(res);
      }else{
        console.log("no se encontro el resultado");
      }
    })
  }

}
