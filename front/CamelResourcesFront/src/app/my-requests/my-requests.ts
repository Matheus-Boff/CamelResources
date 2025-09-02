import { Component, OnInit, OnDestroy } from '@angular/core';
import { AlocacoesService } from '../services/alocacoesService';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-my-requests',
  imports: [ HttpClientModule, DatePipe ],
  templateUrl: './my-requests.html',
  styleUrl: './my-requests.css'
})
export class MyRequests implements OnInit, OnDestroy {
  alocacoes: any[] = [];
  id : string | null = null;
  private subscription: Subscription = new Subscription();

  constructor(private alocacoesService: AlocacoesService) {  }

  ngOnInit() : void {
    this.loadAlocacoes();
    this.subscription.add(
      this.alocacoesService.refresh$.subscribe(() => {
        this.loadAlocacoes();
      })
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  loadAlocacoes() {
    this.id = localStorage.getItem('funcionarioId');
    if(this.id){
      this.alocacoesService.getAlocacoesById(this.id).subscribe(data => {
        const hoje = new Date();
        hoje.setHours(0, 0, 0, 0);
        this.alocacoes = data.filter(a => new Date(a.dataAlocacao) >= hoje);
      });
    }
}

  onDelete(id: number) {
    this.alocacoesService.deleteAlocacao(id.toString()).subscribe(() => {
        console.log('Reserva deletada');
        this.alocacoes = this.alocacoes.filter(a => a.id !== id);
        this.alocacoesService.notifyRefresh();
    });
}

}
