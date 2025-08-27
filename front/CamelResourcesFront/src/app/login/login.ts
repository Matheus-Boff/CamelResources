import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FuncionarioService } from './funcionarioService'
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [ HttpClientModule, FormsModule ],
  providers: [ FuncionarioService ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login implements OnInit {
  funcionarios : any[] = [];
  selectedFuncionarioId: number | null = null;

  constructor(
    private router: Router,
    private funcionarioService : FuncionarioService
  ){}

  ngOnInit(): void {
    this.funcionarioService.getFuncionarios().subscribe(data => {
      this.funcionarios = data;
    })
  }

  entrar() {
    if (this.selectedFuncionarioId){
      localStorage.setItem('funcionarioId', this.selectedFuncionarioId.toString());
    }
    console.log('ID: ', this.selectedFuncionarioId);
    
    this.router.navigate(['/home']);
  }
}
