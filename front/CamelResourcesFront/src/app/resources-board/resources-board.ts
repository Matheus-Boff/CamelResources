import { Component, Input } from '@angular/core';
import { NgFor, NgSwitch, NgSwitchCase } from '@angular/common';

@Component({
  selector: 'app-resources-board',
  standalone: true,
  imports: [NgFor, NgSwitch, NgSwitchCase],
  templateUrl: './resources-board.html',
  styleUrls: ['./resources-board.css']
})
export class ResourcesBoard {
  @Input() tipo: 'Notebook' | 'Sala' | 'Laboratorio' = 'Notebook';

  data = {
    Notebook: ['Dell 15"', 'Lenovo 14"', 'Acer Aspire'],
    Sala: ['Sala 101 (20 lugares)', 'Sala 202 (30 lugares)'],
    Laboratorio: ['Lab Redes', 'Lab Química', 'Lab Robótica']
  } as const;
}
