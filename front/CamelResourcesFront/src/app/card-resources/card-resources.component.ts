import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-resources',
  imports: [],
  templateUrl: './card-resources.component.html',
  styleUrl: './card-resources.component.css'
})
export class CardResourcesComponent {

  @Input() icon: string = '';
  @Input() number: string = '';
}
