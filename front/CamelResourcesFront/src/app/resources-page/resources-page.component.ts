import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardResourcesComponent } from '../card-resources/card-resources.component';
import { Header } from '../header/header';

@Component({
  selector: 'app-resources-page',
  templateUrl: './resources-page.component.html',
  styleUrl: './resources-page.component.css',
  imports: [CommonModule, CardResourcesComponent, Header]
})
export class ResourcesPageComponent {
  /* Lista de botões a serem exibidos na página */
  @Input() buttons: Array<{ icon: string; number: string }> = [
    { icon: 'assets/logo.png', number: '1234567890' },
    { icon: 'assets/logo.png', number: '9876543210' },
    { icon: 'assets/logo.png', number: '1122334455' },
    { icon: 'assets/logo.png', number: '5566778899' }
  ];
}
