import { Component, Input, Inject, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { NgFor, NgSwitch, NgSwitchCase } from '@angular/common';
import { ResourcesService } from '../services/resourcesService';
import { AlocacoesService } from '../services/alocacoesService';
import { ModalConfirmReserva } from '../modal-confirm-reserva/modal-confirm-reserva';


@Component({
  selector: 'app-resources-board',
  standalone: true,
  imports: [NgFor, NgSwitch, NgSwitchCase, ModalConfirmReserva],
  templateUrl: './resources-board.html',
  styleUrls: ['./resources-board.css'],
})
export class ResourcesBoard implements OnInit, OnChanges{
  @Input() tipo: 'Notebook' | 'Sala' | 'Laboratorio' = 'Notebook';
  @Input() selectedDate! : Date;
  
  constructor(
    private resourcesService : ResourcesService,
    private alocacoesService : AlocacoesService
  ){}
 
  resources : any[] = [];

  data : {Notebook : any[]; Sala : any[]; Laboratorio : any[]} = {
    Notebook: [],
    Sala: [],
    Laboratorio: []
  };

  isModalOpen = false;
  selectedRecurso : any = null;

  onReservarNote(recurso: any) {
    this.selectedRecurso = recurso;
    this.isModalOpen = true;
  }

  onReservarSala(recurso: any) {
    this.selectedRecurso = recurso;
    this.isModalOpen = true;
  }

  onReservarLab(recurso: any) {
    this.selectedRecurso = recurso;
    this.isModalOpen = true;
  }

  onConfirmReserva() {
    const idUsuario = localStorage.getItem('funcionarioId');
    if (idUsuario && this.selectedRecurso) {
      let serviceCall;
      if (this.tipo === 'Notebook') {
        serviceCall = this.alocacoesService.addAlocacaoNote(idUsuario, this.selectedRecurso.id.toString(), this.selectedDate);
      } else if (this.tipo === 'Sala') {
        serviceCall = this.alocacoesService.addAlocacaoSala(idUsuario, this.selectedRecurso.id.toString(), this.selectedDate);
      } else if (this.tipo === 'Laboratorio') {
        serviceCall = this.alocacoesService.addAlocacaoLab(idUsuario, this.selectedRecurso.id.toString(), this.selectedDate);
      }

      if (serviceCall) {
        serviceCall.subscribe({
          next: () => {
            console.log('Reserva realizada');
            this.loadResources();
            this.alocacoesService.notifyRefresh();
            this.closeModal();
          },
          error: (err) => {
            console.error('Erro na reserva:', err);
            alert(err.error?.message || 'Erro ao realizar reserva');
          }
        });
      }
    }
  }

  onCancelReserva() {
    this.closeModal();
  }

  closeModal() {
    this.isModalOpen = false;
    this.selectedRecurso = null;
  }

  getNomeNotebook(descricao: string): string {
    return descricao.split('-')[0].trim();
  }

  ngOnInit(){
    this.loadResources();
  }

  ngOnChanges(changes : SimpleChanges){
    if (changes['selectedDate']) {
      this.loadResources();
    }
  }

  loadResources() {
    const idUsuario = localStorage.getItem('funcionarioId');

    this.resourcesService.getAvailableNotebooks(this.selectedDate).subscribe((resources : any[]) => {
      this.data.Notebook = resources;
    });

    this.resourcesService.getAvailableSalas(this.selectedDate).subscribe((resources : any[]) => {
      this.data.Sala = resources;
    });

    this.resourcesService.getAvailableLaboratorios(this.selectedDate).subscribe((resources : any[]) => {
      this.data.Laboratorio = resources;
    });

    if (idUsuario) {
      this.alocacoesService.getAlocacoesById(idUsuario).subscribe(allocations => {
        const userAllocationsOnDate = allocations.filter(a =>
          new Date(a.dataAlocacao).toDateString() === this.selectedDate.toDateString()
        );

        const hasLab = userAllocationsOnDate.some(a => a.laboratorioId);
        const hasSala = userAllocationsOnDate.some(a => a.salaId);
        const hasNotebook = userAllocationsOnDate.some(a => a.notebookId);

        if (hasLab) {
          this.data.Notebook = [];
          this.data.Sala = [];
        }

        if (hasSala || hasNotebook) {
          this.data.Laboratorio = [];
        }
      });
    }
  }
}
