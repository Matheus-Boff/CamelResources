import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-resources',
  templateUrl: './card-resources.component.html',
  styleUrls: ['./card-resources.component.css']
})
export class CardResourcesComponent {
  @Input() icon: string = ''; 
  @Input() number: string = ''; 
}