import { Component } from '@angular/core';
import { CalendarComponent } from '../calendar/calendar';

@Component({
  selector: 'app-home-page',
  imports: [CalendarComponent],
  templateUrl: './home-page.html',
  styleUrl: './home-page.css'
})
export class HomePage {

}
