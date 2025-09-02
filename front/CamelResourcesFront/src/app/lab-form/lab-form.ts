import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ResourcesService } from '../services/resourcesService';

@Component({
  selector: 'app-lab-form',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './lab-form.html',
  styleUrl: './lab-form.css',
})
export class LabForm implements OnInit, OnChanges {
  @Input() recurso: any = null;
  @Output() closeModal = new EventEmitter<void>();
  @Output() refreshRequested = new EventEmitter<void>();

  form!: FormGroup;

  constructor(private fb: FormBuilder, private resourcesService : ResourcesService) {}

  ngOnInit(): void {
  this.form = this.fb.group({
    nome: ['', [Validators.required]],
    qtdComputadores: [0, [Validators.required, Validators.max(99)]], // Corrigido
    descricao: ['', Validators.maxLength(200)],
  });
  this.populateForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['recurso']) {
      this.populateForm();
    }
  }

  private populateForm(): void {
    if (this.recurso) {
      this.form.patchValue({
        nome: this.recurso.nome,
        qtdComputadores: this.recurso.numComputadores,
        descricao: this.recurso.descricao,
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const formValue = this.form.value;
    const payload = {
      nome: formValue.nome,
      numComputadores: formValue.qtdComputadores,
      descricao: formValue.descricao,
    };
    if (this.recurso?.id) {
      const id = Number(this.recurso.id);
      console.log('[LabForm] update payload:', { id, payload });
      this.resourcesService.updateLaboratorio(id, payload).subscribe({
        next: () => {
          console.log('Laboratório atualizado');
          this.closeModal.emit();
          this.refreshRequested.emit();
        },
        error: (err : any) => {
          console.error('Erro ao atualizar:', err);
          alert('Erro: ' + (err.error?.message || 'Erro desconhecido'));
        }
      });
    }
  }
}