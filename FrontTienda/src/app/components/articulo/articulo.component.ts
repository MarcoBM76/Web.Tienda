import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArticuloService } from '../../service/articulo.service';
import { AddArticulo, Articulo } from '../../models/articulo.model';
import { TiendaService } from '../../service/tienda.service';

@Component({
  selector: 'app-articulo',
  templateUrl: './articulo.component.html',
  styleUrls: ['./articulo.component.css']
})
export class ArticuloComponent implements OnInit {
  articuloForm!: FormGroup;
  articulos: any[] = [];
  tiendas: any[] = [];
  isEditMode = false;
  selectedId: number | null = null;

  constructor(private fb: FormBuilder, private _articuloService: ArticuloService, private _tiendaService: TiendaService) { }

  ngOnInit(): void {
    this.articuloForm = this.fb.group({
      codigo: ['', Validators.required],
      descripcion: ['', Validators.required],
      precio: [0, [Validators.required, Validators.min(1)]],
      imagen: [''],
      stock: [0, [Validators.required, Validators.min(0)]],
      idTienda: ['', Validators.required]
    });
    this.getArticulos();
  }

  getArticulos() {
    this._tiendaService.getAll().subscribe({
      next: (data) => {
        this.tiendas = data;
      },
      error: (err) => console.error('Error al cargar tiendas', err)
    });

    this._articuloService.getAllArticuloTienda().subscribe({
      next: (data) => {
        console.log(data)
        this.articulos = data.map(item => ({
          articuloId: item.articulo.articuloId,
          codigo: item.articulo.codigo,
          descripcion: item.articulo.descripcion,
          precio: item.articulo.precio,
          imagen: item.articulo.imagen,
          stock: item.articulo.stock,
          idTienda: item.tienda.tiendaId,
          nombreTienda: item.tienda.sucursal
        }));
        console.log(this.articulos)
      },
      error: (err) => console.error('Error al cargar artículos', err)
    });
  }

  guardar() {
    if (this.articuloForm.invalid) return;

    const formValue = this.articuloForm.value;

    const articuloData: Articulo = {
      articuloId: this.selectedId ?? 0,
      codigo: formValue.codigo,
      descripcion: formValue.descripcion,
      precio: formValue.precio,
      imagen: formValue.imagen,
      stock: formValue.stock
    };

    if (this.isEditMode) {
      this._articuloService.update(this.selectedId!, articuloData).subscribe(() => this.finalizar());
    } else {
      const addArticuloData = articuloData as AddArticulo;
      addArticuloData.tiendaId = formValue.idTienda;
      this._articuloService.add(addArticuloData).subscribe(() => this.finalizar());
    }
  }

  prepararEdicion(item: any) {
    this.isEditMode = true;
    this.selectedId = item.articuloId;
    this.articuloForm.patchValue({
      ...item,
      idTienda: item.idTienda
    });
    this.articuloForm.get('idTienda')?.disable();
  }

  eliminar(id: number) {
    if (confirm('¿Eliminar artículo? Esto borrará sus relaciones con tiendas.')) {
      this._articuloService.delete(id).subscribe(() => this.getArticulos());
    }
  }

  finalizar() {
    this.articuloForm.reset();
    this.isEditMode = false;
    this.selectedId = null;
    this.getArticulos();
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      if (!file.type.startsWith('image/')) {
        alert('Por favor, selecciona un archivo de imagen válido');
        return;
      }

      const reader = new FileReader();

      reader.onload = () => {
        const base64String = reader.result as string;

        this.articuloForm.patchValue({
          imagen: base64String
        });
      };

      reader.readAsDataURL(file);
    }
  }
}
