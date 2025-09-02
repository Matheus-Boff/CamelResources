import { Component, OnInit } from '@angular/core';
import { ResourcesPageComponent } from '../resources-page/resources-page.component';
import { FormsModule } from '@angular/forms';
import { ModalAddNotebookComponent } from '../modal-add-notebook/modal-add-notebook.component';
import { ResourcesService } from '../services/resourcesService';
import { ModalViewComponent } from "../modal-view/modal-view.component";
import { NotebookForm } from "../notebook-form/notebook-form";

interface NotebookPayload {
  numPatrimonio: string;
  dataAquisicao: string;
  descricao: string;
}

@Component({
  selector: 'app-notebook-page',
  standalone: true,
  imports: [ResourcesPageComponent, FormsModule, ModalAddNotebookComponent, ModalViewComponent, NotebookForm],
  templateUrl: './notebook-page.html',
  styleUrls: ['./notebook-page.css']
})
export class NotebookPage implements OnInit {
  isModalOpen = false;
  buttons: Array<{ icon: string; number: string; id?: number; recurso?: any }> = [];

  constructor(private resourcesService: ResourcesService) {}

  ngOnInit() {
    this.loadNotebooks();
  }

  loadNotebooks() {
    this.resourcesService.getNotebooks().subscribe((notebooks : any[]) => {
      this.buttons = notebooks.map(n => ({
        icon: 'notebooks',
        number: `${n.descricao}`,
        id: n.id,
        recurso: n
      }));
    });
  }

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
    this.resourcesService.createNotebook({
      nroPatrimonio: novo.numPatrimonio,
      dataAquisicao: novo.dataAquisicao,
      descricao: novo.descricao
    }).subscribe({
      next: () => {
        console.log('Notebook criado com sucesso');
        this.loadNotebooks();
        this.closeModal();
      },
      error: (err: any) => {
        console.error('Erro ao criar notebook:', err);
        alert('Erro ao criar notebook: ' + (err.error?.message || 'Erro desconhecido'));
      }
    });
  }
}