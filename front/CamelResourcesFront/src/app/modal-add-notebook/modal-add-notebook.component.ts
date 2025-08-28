import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-notebook-modal',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './modal-add-notebook.component.html',
  styleUrls: ['./modal-add-notebook.component.css']
})
export class ModalAddNotebookComponent {
  notebook = {
    nome: '',
    marca: '',
    descricao: ''
  };

  onSubmit() {
    console.log('Notebook adicionado:', this.notebook);
  }
}