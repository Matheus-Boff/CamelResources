import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

export type EventMap = Record<string, number>; // ex.: { "2025-09-02": 3 }

@Component({
  selector: 'app-calendar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './calendar.html',
  styleUrls: ['./calendar.css'],
})
export class CalendarComponent {
  /** Data selecionada (two-way) */
  @Input() date: Date = new Date();
  @Output() dateChange = new EventEmitter<Date>();

  /** Mapa opcional de eventos para desenhar um "dot" */
  @Input() events: EventMap = {};

  /** Desabilitar datas passadas? (padrão: true) */
  @Input() disablePast = true;

  /** Começar semana na segunda? (padrão: false) */
  @Input() mondayStart = false;

  // estado interno
  viewMonth = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
  calendarCells: (Date | null)[] = [];

  ngOnInit() { this.normalizeSelected(); this.build(); }

  get title(): string {
    return this.viewMonth.toLocaleDateString('pt-BR', { month: 'long', year: 'numeric' });
  }

  prevMonth() { this.viewMonth = new Date(this.viewMonth.getFullYear(), this.viewMonth.getMonth() - 1, 1); this.build(); }
  nextMonth() { this.viewMonth = new Date(this.viewMonth.getFullYear(), this.viewMonth.getMonth() + 1, 1); this.build(); }

  onSelect(d: Date) {
    if (this.disablePast && this.isPast(d)) return;
    this.date = this.stripTime(d);
    this.dateChange.emit(this.date);
  }

  // ===== helpers de estado/estilo =====
  isToday(d: Date | null): boolean {
    if (!d) return false;
    return this.stripTime(d).getTime() === this.stripTime(new Date()).getTime();
  }

  isPast(d: Date | null): boolean {
    if (!d) return true;
    const x = this.stripTime(d).getTime();
    const t = this.stripTime(new Date()).getTime();
    return x < t;
  }

  isSelected(d: Date | null): boolean {
    if (!d || !this.date) return false;
    return this.stripTime(d).getTime() === this.stripTime(this.date).getTime();
  }

  hasEvent(d: Date | null): boolean {
    if (!d) return false;
    return !!this.events[this.iso(d)];
  }

  // ===== construção da grade =====
  private build() {
    const year = this.viewMonth.getFullYear();
    const month = this.viewMonth.getMonth();
    const first = new Date(year, month, 1);

    const dow = first.getDay(); // 0..6 (Dom)
    const offset = this.mondayStart ? ((dow + 6) % 7) : dow;

    const daysInMonth = new Date(year, month + 1, 0).getDate();

    const cells: (Date | null)[] = [];
    // buracos iniciais
    for (let i = 0; i < offset; i++) cells.push(null);
    // dias do mês
    for (let d = 1; d <= daysInMonth; d++) cells.push(new Date(year, month, d));
    // completar grade (múltiplo de 7)
    while (cells.length % 7 !== 0) cells.push(null);

    this.calendarCells = cells;
  }

  private normalizeSelected() {
    this.date = this.stripTime(this.date ?? new Date());
  }

  private stripTime(d: Date): Date {
    const x = new Date(d);
    x.setHours(0, 0, 0, 0);
    return x;
  }

  private iso(d: Date): string {
    return this.stripTime(d).toISOString().slice(0, 10);
  }
}
