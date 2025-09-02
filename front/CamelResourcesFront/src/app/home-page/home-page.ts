import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { CalendarComponent } from '../calendar/calendar';
import { ResourcesBoard } from '../resources-board/resources-board';
import { MyRequests } from "../my-requests/my-requests";

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [CalendarComponent, ResourcesBoard, NgFor, MyRequests],  
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {
  tipos: Array<'Notebook' | 'Sala' | 'Laboratorio'> = ['Notebook', 'Sala', 'Laboratorio'];
  selecionado: 'Notebook' | 'Sala' | 'Laboratorio' = 'Notebook';
  selectedDate : Date = new Date();
}
