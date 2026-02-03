import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService } from '../../service/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})

export class ClienteComponent implements OnInit {
  clienteForm!: FormGroup;
  clientes: Cliente[] = [];
  isEditMode = false;
  clienteIdActual: number | null = null;

  constructor(private fb: FormBuilder, private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.initForm();
    this.listarClientes();
  }

  initForm() {
    this.clienteForm = this.fb.group({
      nombre: ['', [Validators.required]],
      apellidoP: ['', [Validators.required]],
      apellidoM: ['', [Validators.required]],
      direccion: ['', [Validators.required]]
    });
  }

  listarClientes() {
    this.clienteService.getClientes().subscribe(data => this.clientes = data);
  }

  guardarCliente() {
    if (this.clienteForm.invalid) return;

    const cliente: Cliente = {
      clienteId: this.clienteIdActual ?? 0,
      ...this.clienteForm.value
    };

    if (this.isEditMode) {
      this.clienteService.updateCliente(cliente).subscribe(() => this.finalizarAccion());
    } else {
      this.clienteService.createCliente(cliente).subscribe(() => this.finalizarAccion());
    }
  }

  prepararEdicion(cliente: Cliente) {
    this.isEditMode = true;
    this.clienteIdActual = cliente.clienteId;
    this.clienteForm.patchValue(cliente);
  }

  eliminar(id: number) {
    if (confirm('¿Deseas eliminar este cliente?')) {
      this.clienteService.deleteCliente(id).subscribe(() => this.listarClientes());
    }
  }

  finalizarAccion() {
    this.clienteForm.reset();
    this.isEditMode = false;
    this.clienteIdActual = null;
    this.listarClientes();
  }
}
