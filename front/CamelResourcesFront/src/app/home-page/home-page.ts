import { Component } from '@angular/core';
import { CalendarComponent } from "../calendar/calendar";
import { ResourcesBoard } from "../resources-board/resources-board";
import { MyRequests } from "../my-requests/my-requests";

type TipoRecurso = 'Notebook' | 'Sala' | 'Laboratorio';
interface NotebookResource { type:'Notebook'; patrimonio:string; dataAquisicao:string; descricao:string; }
interface SalaResource { type:'Sala'; numero:string; lugares:number; projetor:boolean; }
interface LaboratorioResource { type:'Laboratorio'; nome:string; qtdComputadores:number; descricaoConfig:string; }
type ResourceDetail = NotebookResource | SalaResource | LaboratorioResource;

interface BoardData {
  Notebook: NotebookResource[];
  Sala: SalaResource[];
  Laboratorio: LaboratorioResource[];
}

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home-page.html',
  styleUrls: ['./home-page.css'],
  imports: [CalendarComponent, MyRequests, ResourcesBoard]
})
export class HomePage {
  tipos: TipoRecurso[] = ['Notebook', 'Sala', 'Laboratorio'];
  selecionado: TipoRecurso = 'Notebook';

  data: BoardData = {
    Notebook: [
      { type:'Notebook', patrimonio:'NB-0023', dataAquisicao:'2023-04-18', descricao:'Dell i5, 8GB, 256GB SSD' },
      { type:'Notebook', patrimonio:'NB-0041', dataAquisicao:'2022-11-03', descricao:'Lenovo i7, 16GB, 512GB SSD' },
    ],
    Sala: [
      { type:'Sala', numero:'101', lugares:40, projetor:true },
      { type:'Sala', numero:'202', lugares:28, projetor:false },
    ],
    Laboratorio: [
      { type:'Laboratorio', nome:'Lab Redes', qtdComputadores:28, descricaoConfig:'Ubuntu 22.04, i5, 8GB' },
      { type:'Laboratorio', nome:'Lab IA', qtdComputadores:32, descricaoConfig:'Windows 11, i7, 16GB, CUDA' },
    ]
  };

  isModalOpen = false;
  selectedResource: ResourceDetail | null = null;

  setSelecionado(tipo: TipoRecurso) {
    this.selecionado = tipo;
  }

  openResourceModal(item: ResourceDetail) {
    this.selectedResource = item;
    this.selecionado = item.type; 
    this.isModalOpen = true;
  }

  closeModal() { this.isModalOpen = false; }

  reservar(resource: ResourceDetail | null) {
    if (!resource) return;
    console.log('Reservar:', resource);
    this.isModalOpen = false;
    alert('Solicitação de reserva criada (mock).');
  }
}
