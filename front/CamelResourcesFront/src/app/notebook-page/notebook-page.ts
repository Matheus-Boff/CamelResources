import { Component } from '@angular/core';
import { ResourcesPageComponent } from '../resources-page/resources-page.component';
import { FormsModule } from '@angular/forms';
import { ModalAddNotebookComponent } from '../modal-add-notebook/modal-add-notebook.component';

interface NotebookPayload {
  numPatrimonio: string;
  marca: string;
  descricao: string;
}

@Component({
  selector: 'app-notebook-page',
  standalone: true,
  imports: [ResourcesPageComponent, FormsModule, ModalAddNotebookComponent],
  templateUrl: './notebook-page.html',
  styleUrls: ['./notebook-page.css']
})
export class NotebookPage {
  isModalOpen = false;

  openAddNotebookModal() {
    this.isModalOpen = true;
    document.body.classList.add('modal-open');
    console.log('[PAI] openAddNotebookModal → isModalOpen =', this.isModalOpen);
  }

  closeModal() {
    this.isModalOpen = false;
    document.body.classList.remove('modal-open');
    console.log('[PAI] closeModal → isModalOpen =', this.isModalOpen);
  }

  onModalToggle(open: boolean) {
    this.isModalOpen = open;
    document.body.classList.toggle('modal-open', open);
    console.log('[PAI] isOpenChange →', open);
  }

  handleCreate(novo: NotebookPayload) {
    console.log('Notebook criado:', novo);
    this.closeModal(); 
  }
}
