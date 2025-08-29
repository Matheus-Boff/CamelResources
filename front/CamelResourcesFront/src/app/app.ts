import { Component, signal } from '@angular/core';
import { RouterOutlet, Router} from '@angular/router';
import { Header } from './header/header';
import { NgIf } from '@angular/common';
import { ModalAddNotebookComponent } from "./modal-add-notebook/modal-add-notebook.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, NgIf, ModalAddNotebookComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  isLoggedIn = false;
isModalOpen: any;

  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.isLoggedIn = this.router.url !== '/';
    })
  }
}
