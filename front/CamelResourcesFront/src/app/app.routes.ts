import { Routes } from '@angular/router';
import { Login } from './login/login';
import { HomePage } from './home-page/home-page';
import { ResourcesPageComponent } from './resources-page/resources-page.component';

export const routes: Routes = [
    { path: '', component: ResourcesPageComponent },
    { path: 'home', component: HomePage }
];
