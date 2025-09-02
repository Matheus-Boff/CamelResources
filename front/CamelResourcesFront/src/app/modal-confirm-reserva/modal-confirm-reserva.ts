import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal-confirm-reserva',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal-confirm-reserva.html',
  styleUrl: './modal-confirm-reserva.css'
})
export class ModalConfirmReserva {
  @Input() isOpen : boolean = false;
  @Input() recurso : any = null;
  @Input() tipo : string = '';

  @Output() confirm = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();

  onConfirm() {
    this.confirm.emit();
  }

  onCancel() {
    this.cancel.emit();
  }
}
