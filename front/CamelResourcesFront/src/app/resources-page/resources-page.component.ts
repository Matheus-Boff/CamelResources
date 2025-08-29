import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardResourcesComponent } from '../card-resources/card-resources.component';
import { ModalViewComponent } from "../modal-view/modal-view.component";
import { NotebookForm } from "../notebook-form/notebook-form";
import { LabForm } from "../lab-form/lab-form";
import { SalaForm } from "../sala-form/sala-form";

@Component({
  selector: 'app-resources-page',
  templateUrl: './resources-page.component.html',
  styleUrl: './resources-page.component.css',
  imports: [CommonModule, CardResourcesComponent, ModalViewComponent, NotebookForm, LabForm, SalaForm]
})
export class ResourcesPageComponent {
  isModalOpen: boolean = false;
  tipoRecurso: string = 'notebooks';
  selectedRecurso: any = null;
  modalTitle: string = 'Editar Recurso';

  @Input() buttons: Array<{ icon: string; number: string; id?: number; recurso?: any }> = [];
  @Output() refreshRequested = new EventEmitter<void>();

  abrirModal(btn: any) {
    this.isModalOpen = true;
    this.tipoRecurso = btn.icon;
    this.selectedRecurso = btn.recurso;
    this.modalTitle = 'Editar ' + (this.tipoRecurso === 'notebooks' ? 'Notebook' : this.tipoRecurso === 'salas' ? 'Sala' : 'Laboratório');
  }

  onRefreshRequested() {
    this.refreshRequested.emit();
  }
}
