import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-view',
  templateUrl: './modal-view.component.html',
  styleUrls: ['./modal-view.component.css'],
})
export class ModalViewComponent {
  @Input() modalTitle: string = '';
  @Input() isOpen: boolean = false;
  @Output() close = new EventEmitter<void>();

  onClose() {
    this.close.emit();
  }
}