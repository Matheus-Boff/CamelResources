import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-lab-form',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './lab-form.html',
  styleUrl: './lab-form.css',
})
export class LabForm {
  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required]],
      qtdComputadores: ['', Validators.required, Validators.maxLength(1)],
      descricao: ['', Validators.maxLength(200)],
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    console.log('Valores do formulário:', this.form.value);
  }
}
