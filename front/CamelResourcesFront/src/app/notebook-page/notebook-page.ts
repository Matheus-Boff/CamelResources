import { Component, Input } from '@angular/core';
import { ResourcesPageComponent } from "../resources-page/resources-page.component";

@Component({
  selector: 'app-notebook-page',
  standalone: true,
  imports: [ResourcesPageComponent],
  templateUrl: './notebook-page.html',
  styleUrls: ['./notebook-page.css']
})
export class NotebookPage {}
