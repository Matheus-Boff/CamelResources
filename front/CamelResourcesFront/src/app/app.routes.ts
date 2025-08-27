import { Routes } from '@angular/router';
import { Login } from './login/login';
import { HomePage } from './home-page/home-page';

export const routes: Routes = [
    { path: '', component: Login },
    { path: 'home', component: HomePage }
];
