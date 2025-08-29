import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ResourcesBoard } from "../resources-board/resources-board";

type TotalPorRecurso = { tipo: string; qtd: number };
type DiaMovimentado = { date: Date; reservas: number };

@Component({
  selector: 'app-status-page',
  standalone: true,
  imports: [CommonModule, FormsModule, ResourcesBoard],
  templateUrl: './relatorio-page.html',
  styleUrls: ['./relatorio-page.css'],
})
export class RelatorioPage {
  startDate: string | null = null;
  endDate: string | null = null;

  selectedDate = new Date();

  totalsByResource: TotalPorRecurso[] = [
    { tipo: 'Notebook', qtd: 10 },
    { tipo: 'Sala', qtd: 5 },
    { tipo: 'Laboratorio', qtd: 8 },
  ];

  busiestDays: DiaMovimentado[] = [
    { date: this.makeDate('2025-05-10'), reservas: 12 },
    { date: this.makeDate('2025-05-15'), reservas: 9 },
    { date: this.makeDate('2025-05-20'), reservas: 15 },
  ];

  get minNavDate(): Date | null {
    return this.startDate ? this.makeDate(this.startDate) : null;
  }
  get maxNavDate(): Date | null {
    return this.endDate ? this.makeDate(this.endDate) : null;
  }

  get isRangeValid(): boolean {
    if (!this.startDate || !this.endDate) return false;
    return this.makeDate(this.startDate) <= this.makeDate(this.endDate);
  }

  get canGoPrev(): boolean {
    if (!this.minNavDate) return true;
    const prev = this.addDays(this.selectedDate, -1);
    return prev >= this.stripTime(this.minNavDate);
  }

  get canGoNext(): boolean {
    if (!this.maxNavDate) return true;
    const next = this.addDays(this.selectedDate, 1);
    return next <= this.stripTime(this.maxNavDate);
  }

  onRangeChange(): void {
    if (this.isRangeValid) {
      const start = this.makeDate(this.startDate!);
      if (this.selectedDate < start) this.selectedDate = start;
      const end = this.makeDate(this.endDate!);
      if (this.selectedDate > end) this.selectedDate = end;
    }
  }

  filterBookings(): void {
    if (!this.isRangeValid) return;

    this.selectedDate = this.makeDate(this.startDate!);
  }

  prevDay(): void {
    if (!this.canGoPrev) return;
    this.selectedDate = this.addDays(this.selectedDate, -1);
  }

  nextDay(): void {
    if (!this.canGoNext) return;
    this.selectedDate = this.addDays(this.selectedDate, 1);
  }

  private makeDate(iso: string): Date {
    const d = new Date(iso);
    return this.stripTime(d);
  }

  private stripTime(d: Date): Date {
    return new Date(d.getFullYear(), d.getMonth(), d.getDate());
  }

  private addDays(d: Date, days: number): Date {
    const nd = new Date(d);
    nd.setDate(nd.getDate() + days);
    return this.stripTime(nd);
  }
}
