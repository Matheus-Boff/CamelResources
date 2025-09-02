import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AlocacoesService {
    constructor(private http: HttpClient) {}

    private refreshSubject = new BehaviorSubject<void>(undefined);
    public refresh$ = this.refreshSubject.asObservable();

    notifyRefresh(){
        this.refreshSubject.next();
    }

    getAlocacoes(){
        return this.http.get<any[]>('http://localhost:5243/api/alocacao');
    }

    getAlocacoesById(id: string | null) {
    if (id === null) return of(['error']);
    return this.http.get<any[]>('http://localhost:5243/api/alocacao/usuario/' + id);
    }

    addAlocacaoNote(idUsuario: string, idNote: string, data: Date) {
        return this.http.post('http://localhost:5243/api/alocacao', {
            dataAlocacao: data,
            funcionarioId: Number(idUsuario),
            notebookId: Number(idNote)
        });
    }

    addAlocacaoSala(idUsuario : string, idSala : string, data: Date){
        return this.http.post('http://localhost:5243/api/alocacao', {
            dataAlocacao: data,
            funcionarioId: Number(idUsuario),
            salaId: Number(idSala)
        });
    }

    addAlocacaoLab(idUsuario : string, idLab : string, data: Date){
        return this.http.post('http://localhost:5243/api/alocacao', {
            dataAlocacao: data,
            funcionarioId: Number(idUsuario),
            laboratorioId: Number(idLab)
        });
    }

    deleteAlocacao(id: string) {
    return this.http.delete(`http://localhost:5243/api/alocacao/${id}`);
    }
}