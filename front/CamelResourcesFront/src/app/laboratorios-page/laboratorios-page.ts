import { Component, OnInit } from '@angular/core';
import { ResourcesPageComponent } from '../resources-page/resources-page.component';
import { ResourcesService } from '../services/resourcesService';

@Component({
  selector: 'app-laboratorios-page',
  standalone: true,
  imports: [ResourcesPageComponent],
  templateUrl: './laboratorios-page.html',
  styleUrls: ['./laboratorios-page.css']
})
export class LaboratoriosPage implements OnInit {
  buttons: Array<{ icon: string; number: string }> = [];

  constructor(private resourcesService: ResourcesService) {}

  ngOnInit() {
    this.loadLaboratorios();
  }

  loadLaboratorios() {
    this.resourcesService.getLaboratorios().subscribe(laboratorios => {
      this.buttons = laboratorios.map(l => ({
        icon: 'assets/logo.png',
        number: `${l.nome}, computadores: ${l.numComputadores}`
      }));
    });
  }
}
