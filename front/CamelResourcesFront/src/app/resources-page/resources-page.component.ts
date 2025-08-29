import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardResourcesComponent } from '../card-resources/card-resources.component';

@Component({
  selector: 'app-resources-page',
  templateUrl: './resources-page.component.html',
  styleUrl: './resources-page.component.css',
  imports: [CommonModule, CardResourcesComponent]
})
export class ResourcesPageComponent {
  @Input() buttons: Array<{ icon: string; number: string }> = [];
}
