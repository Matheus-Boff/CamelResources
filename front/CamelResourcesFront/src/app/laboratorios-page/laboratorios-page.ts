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
  buttons: Array<{ icon: string; number: string; id?: number; recurso?: any }> = [];

  constructor(private resourcesService: ResourcesService) {}

  ngOnInit() {
    this.loadLabs();
  }

  loadLabs() {
    this.resourcesService.getLaboratorios().subscribe((labs : any[]) => {
      this.buttons = labs.map(l => ({
        icon: 'laboratorios',
        number: `${l.nome}, computadores: ${l.numComputadores}`,
        id: l.id,
        recurso: l
      }));
    });
  }
}
