import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
  FormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-sala-form',
  templateUrl: './sala-form.html',
  styleUrls: ['./sala-form.css'],
  imports: [FormsModule, ReactiveFormsModule],
})
export class SalaForm implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      numSala: ['', Validators.required],
      numLugares: ['', Validators.required],
      projetor: ['S', Validators.required],
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
