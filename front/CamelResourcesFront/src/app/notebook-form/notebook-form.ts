import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-notebook-form',
  templateUrl: './notebook-form.html',
  styleUrls: ['./notebook-form.css'],
  imports: [ReactiveFormsModule],
})
export class NotebookForm implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nroPatrimonio: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]],
      dataAquisicao: ['', Validators.required],
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