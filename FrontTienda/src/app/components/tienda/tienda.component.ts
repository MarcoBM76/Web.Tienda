import { Component } from '@angular/core';
import { TiendaService } from '../../service/tienda.service';
import { Tienda } from '../../models/tienda';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent {

  tiendas: Tienda[] = [];

  tiendaForm!: FormGroup;

  isEditMode: boolean = false;
  tiendaIdActual: number | null = null;

  constructor(private _tiendaService: TiendaService, private fb: FormBuilder) {
    this.tiendaForm = this.fb.group({
      sucursal: ['', [Validators.required, Validators.minLength(3)]],
      direccion: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.getTiendas()
  }


  getTiendas() {
    this._tiendaService.getAll().subscribe({
      next: (data) => {
        this.tiendas = data;
      },
      error: (err) => {
        console.error('Error al obtener las tiendas:', err);
      }
      });
  }

  addTienda() {
    if (this.tiendaForm.invalid) return;

    const tiendaData = this.tiendaForm!.value as Tienda;

    if (this.isEditMode) {
      this._tiendaService.update(this.tiendaIdActual!, tiendaData).subscribe({
        next: (data) => {
          this.getTiendas();
          this.resetearFormulario();
        },
        error: (err) => {}
      });
      return;
    }

    this._tiendaService.add(tiendaData).subscribe({
      next: (data) => {
        this.getTiendas();
        this.tiendaForm.reset();
      },
      error: (err) => {}
      });
  }

  deleteTienda(id: number) {
    this._tiendaService.delete(id).subscribe({
      next: (data) => {
        this.getTiendas();
      },
      error: (err) => {
      }
    });
  }


  prepararEdicion(tienda: Tienda) {
    this.isEditMode = true;
    this.tiendaIdActual = tienda.tiendaId;

    this.tiendaForm.patchValue({
      sucursal: tienda.sucursal,
      direccion: tienda.direccion
    });
  }

  resetearFormulario() {
    this.isEditMode = false;
    this.tiendaIdActual = null;
    this.tiendaForm.reset();
  }

}
