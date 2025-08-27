import { Component, signal } from '@angular/core';
import { RouterOutlet, Router} from '@angular/router';
import { Header } from './header/header';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, NgIf],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  isLoggedIn = false;

  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.isLoggedIn = this.router.url !== '/';
    })
  }
}
