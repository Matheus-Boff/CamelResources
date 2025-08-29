import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface NotebookPayload {
  numPatrimonio: string;
  marca: string;
  descricao: string;
}

@Component({
  selector: 'app-add-notebook-modal',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './modal-add-notebook.component.html',
  styleUrls: ['./modal-add-notebook.component.css']
})
export class ModalAddNotebookComponent {
  @Input() isOpen: boolean = false;

  @Output() isOpenChange = new EventEmitter<boolean>();

  @Output() submitted = new EventEmitter<NotebookPayload>();

  notebook: NotebookPayload = { numPatrimonio: '', marca: '', descricao: '' };

  requestClose() {
    this.isOpen = false;
    this.isOpenChange.emit(false);
  }

  @HostListener('document:keydown.escape')
  onEsc() {
    if (this.isOpen) this.requestClose();
  }

  onSubmit() {
    const { numPatrimonio, marca, descricao } = this.notebook;
    if (!numPatrimonio?.trim() || !marca?.trim() || !descricao?.trim()) return;

    this.submitted.emit({ ...this.notebook });
    this.notebook = { numPatrimonio: '', marca: '', descricao: '' };
    this.requestClose();
  }
}
