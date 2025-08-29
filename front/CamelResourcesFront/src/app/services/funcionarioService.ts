import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class FuncionarioService {
    constructor(private http: HttpClient) {}

    getFuncionarios(){
        return this.http.get<any[]>('http://localhost:5243/api/funcionario');
    }
}