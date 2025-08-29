import { Component, Input, Inject, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { NgFor, NgSwitch, NgSwitchCase } from '@angular/common';
import { ResourcesService } from '../services/resourcesService';
import { AlocacoesService } from '../services/alocacoesService';


@Component({
  selector: 'app-resources-board',
  standalone: true,
  imports: [NgFor, NgSwitch, NgSwitchCase],
  templateUrl: './resources-board.html',
  styleUrls: ['./resources-board.css'],
  providers: [ResourcesService]
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

  onReservarNote(recurso: any) {
    const idUsuario = localStorage.getItem('funcionarioId');
    if (idUsuario) {
      this.alocacoesService.addAlocacaoNote(idUsuario, recurso.id.toString(), this.selectedDate).subscribe({
        next: () => {
          console.log('Reserva de notebook realizada');
          this.loadResources();
          this.alocacoesService.notifyRefresh();
        },
        error: (err) => {
          console.error('Erro na reserva:', err);
          alert(err.error?.message || 'Erro ao realizar reserva de notebook');
        }
      });
    }
}

onReservarSala(recurso: any) {
    const idUsuario = localStorage.getItem('funcionarioId');
    if (idUsuario) {
      this.alocacoesService.addAlocacaoSala(idUsuario, recurso.id.toString(), this.selectedDate).subscribe({
        next: () => {
          console.log('Reserva de sala realizada');
          this.loadResources();
          this.alocacoesService.notifyRefresh();
        },
        error: (err) => {
          console.error('Erro na reserva:', err);
          alert(err.error?.message || 'Erro ao realizar reserva de sala');
        }
      });
    }
}

onReservarLab(recurso: any) {
    const idUsuario = localStorage.getItem('funcionarioId');
    if (idUsuario) {
      this.alocacoesService.addAlocacaoLab(idUsuario, recurso.id.toString(), this.selectedDate).subscribe({
        next: () => {
          console.log('Reserva de laboratório realizada');
          this.loadResources();
          this.alocacoesService.notifyRefresh();
        },
        error: (err) => {
          console.error('Erro na reserva:', err);
          alert(err.error?.message || 'Erro ao realizar reserva de laboratório');
        }
      });
    }
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

    this.resourcesService.getAvailableNotebooks(this.selectedDate).subscribe(resources => {
      this.data.Notebook = resources;
    });

    this.resourcesService.getAvailableSalas(this.selectedDate).subscribe(resources => {
      this.data.Sala = resources;
    });

    this.resourcesService.getAvailableLaboratorios(this.selectedDate).subscribe(resources => {
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
