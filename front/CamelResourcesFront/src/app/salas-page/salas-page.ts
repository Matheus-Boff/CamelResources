import { Component, OnInit } from '@angular/core';
import { ResourcesPageComponent } from '../resources-page/resources-page.component';
import { ResourcesService } from '../services/resourcesService';


@Component({
  selector: 'app-salas-page',
  standalone: true,
  imports: [ResourcesPageComponent],
  templateUrl: './salas-page.html',
  styleUrls: ['./salas-page.css']
})
export class SalasPage implements OnInit {
  buttons: Array<{ icon: string; number: string }> = [];

  constructor(private resourcesService: ResourcesService) {}

  ngOnInit() {
    this.loadSalas();
  }

  loadSalas() {
    this.resourcesService.getSalas().subscribe(salas => {
      this.buttons = salas.map(s => ({
        icon: 'assets/logo.png',
        number: `Sala ${s.numero}, lugares ${s.numLugares}, projetor: ${s.projetor ? 'Sim' : 'Não'}`
      }));
    });
  }
}
