import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ResourcesService } from '../services/resourcesService';

@Component({
  selector: 'app-notebook-form',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './notebook-form.html',
  styleUrl: './notebook-form.css',
})
export class NotebookForm implements OnInit, OnChanges {
  @Input() recurso: any = null;
  @Output() closeModal = new EventEmitter<void>();
  @Output() refreshRequested = new EventEmitter<void>();

  form!: FormGroup;

  constructor(private fb: FormBuilder, private resourcesService: ResourcesService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      nroPatrimonio: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(5)]],
      dataAquisicao: ['', Validators.required],
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
        nroPatrimonio: this.recurso.nroPatrimonio,
        dataAquisicao: this.recurso.dataAquisicao ? new Date(this.recurso.dataAquisicao).toISOString().split('T')[0] : '',
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
    if (this.recurso?.id) {
      const id = Number(this.recurso.id);
      console.log('[NotebookForm] update payload:', { id, formValue });
      this.resourcesService.updateNotebook(id, formValue).subscribe({
        next: () => {
          console.log('Notebook atualizado');
          this.closeModal.emit();
          this.refreshRequested.emit();
        },
        error: (err: any) => {
          console.error('Erro ao atualizar:', err);
          alert('Erro: ' + (err.error?.message || 'Erro desconhecido'));
        }
      });
    } else {
      console.log('[NotebookForm] create payload:', formValue);
      this.resourcesService.createNotebook(formValue).subscribe({
        next: () => {
          console.log('Notebook criado');
          this.closeModal.emit();
          this.refreshRequested.emit();
        },
        error: (err: any) => {
          console.error('Erro ao criar:', err);
          alert('Erro: ' + (err.error?.message || 'Erro desconhecido'));
        }
      });
    }
  }

  OnDelete() {
    if (!this.recurso?.id) return;
    
    const id = Number(this.recurso.id);
    if (confirm('Tem certeza que deseja excluir este notebook?')) {
      this.resourcesService.deleteNotebook(id).subscribe({
        next: () => {
          console.log('Notebook excluído');
          this.closeModal.emit();
          this.refreshRequested.emit();
        },
        error: (err: any) => {
          console.error('Erro ao excluir:', err);
          alert('Erro: ' + (err.error?.message || 'Erro desconhecido'));
        }
      });
    }
  }
}