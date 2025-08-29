import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class ResourcesService {
    constructor(private http: HttpClient) {}

    getNotebooks() : Observable<any[]>{
        return this.http.get<any[]>('http://localhost:5243/api/notebook');
    }

    getSalas() : Observable<any[]>{
        return this.http.get<any[]>('http://localhost:5243/api/sala');
    }

    getLaboratorios() : Observable<any[]>{
        return this.http.get<any[]>('http://localhost:5243/api/laboratorio');
    }

    getAvailableNotebooks(date: Date): Observable<any[]> {
        const dateStr = date.toISOString().split('T')[0]; // Formato yyyy-MM-dd
        return this.http.get<any[]>('http://localhost:5243/api/status/Notebook?date=' + dateStr);
    }

    getAvailableSalas(date: Date): Observable<any[]> {
        const dateStr = date.toISOString().split('T')[0];
        return this.http.get<any[]>('http://localhost:5243/api/status/Sala?date=' + dateStr);
    }

    getAvailableLaboratorios(date: Date): Observable<any[]> {
        const dateStr = date.toISOString().split('T')[0];
        return this.http.get<any[]>('http://localhost:5243/api/status/Lab?date=' + dateStr);
    }

    createNotebook(notebook: { nroPatrimonio: string; dataAquisicao: string; descricao: string }) {
    return this.http.post('http://localhost:5243/api/notebook', {
        nroPatrimonio: notebook.nroPatrimonio,
        dataAquisicao: new Date(notebook.dataAquisicao),
        descricao: notebook.descricao
    });
}

    /* getAlocacoes(){
        return this.http.get<any[]>('http://localhost:5243/api/alocacao');
    }

    getAlocacoesById(id: string | null) {
    if (id === null) return of(['error']); // Retorna um Observable
    return this.http.get<any[]>('http://localhost:5243/api/alocacao/usuario/' + id);
} */
}