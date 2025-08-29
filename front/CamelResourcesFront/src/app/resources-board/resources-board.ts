import { Component, EventEmitter, Input, Output } from '@angular/core';

type TipoRecurso = 'Notebook' | 'Sala' | 'Laboratorio';

interface NotebookResource {
  type: 'Notebook';
  patrimonio: string;
  dataAquisicao: string;
  descricao: string;
}
interface SalaResource {
  type: 'Sala';
  numero: string;
  lugares: number;
  projetor: boolean;
}
interface LaboratorioResource {
  type: 'Laboratorio';
  nome: string;
  qtdComputadores: number;
  descricaoConfig: string;
}
type ResourceDetail = NotebookResource | SalaResource | LaboratorioResource;

interface BoardData {
  Notebook: NotebookResource[];
  Sala: SalaResource[];
  Laboratorio: LaboratorioResource[];
}

@Component({
  selector: 'app-resources-board',
  standalone: true,
  templateUrl: './resources-board.html',
  styleUrls: ['./resources-board.css'],
  imports: []
})
export class ResourcesBoard {
  @Input() tipo!: TipoRecurso;
  @Input() data!: BoardData;

  @Output() select = new EventEmitter<ResourceDetail>();

  onSelect(item: ResourceDetail) {
    this.select.emit(item);
  }
}
