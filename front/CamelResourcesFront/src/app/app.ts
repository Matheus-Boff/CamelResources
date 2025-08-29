import { Component, signal } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import { Header } from './header/header';
import { ModalViewComponent } from './modal-view/modal-view.component';
import { NotebookForm } from './notebook-form/notebook-form';
import { LabForm } from './lab-form/lab-form';
import { SalaForm } from './sala-form/sala-form';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, ModalViewComponent, NotebookForm, LabForm, SalaForm],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  isLoggedIn = false;
  isModalOpen = false;

  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.isLoggedIn = this.router.url !== '/';
    });
  }
}