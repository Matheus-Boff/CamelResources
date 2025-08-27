import { Routes } from '@angular/router';
import { Login } from './login/login';
import { HomePage } from './home-page/home-page';
import { LaboratoriosPage } from './laboratorios-page/laboratorios-page';
import { SalasPage } from './salas-page/salas-page';
import { RelatorioPage } from './relatorio-page/relatorio-page';

export const routes: Routes = [
    { path: '', component: Login },
    { path: 'home', component: HomePage },
    { path: 'laboratorios', component: LaboratoriosPage },
    { path: 'salas', component: SalasPage },
    { path: 'relatorios', component: RelatorioPage }
];
