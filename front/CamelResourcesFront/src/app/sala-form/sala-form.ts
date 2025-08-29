import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ResourcesService } from '../services/resourcesService';

@Component({
  selector: 'app-sala-form',
  templateUrl: './sala-form.html',
  styleUrls: ['./sala-form.css'],
  imports: [FormsModule, ReactiveFormsModule],
})
export class SalaForm implements OnInit, OnChanges {
  @Input() recurso: any = null;
  @Output() closeModal = new EventEmitter<void>();
  @Output() refreshRequested = new EventEmitter<void>();

  form!: FormGroup;

  constructor(private fb: FormBuilder, private resourcesService: ResourcesService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      numSala: ['', [Validators.required, Validators.min(1)]],
      numLugares: ['', [Validators.required, Validators.min(1)]],
      projetor: ['N', Validators.required],
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
        numSala: this.recurso.numero,
        numLugares: this.recurso.numLugares,
        projetor: this.recurso.projetor ? 'S' : 'N',
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
      numero: formValue.numSala,
      numLugares: formValue.numLugares,
      projetor: formValue.projetor === 'S',
    };
    if (this.recurso?.id) {
      const id = Number(this.recurso.id);
      console.log('[SalaForm] update payload:', { id, payload });
      this.resourcesService.updateSala(id, payload).subscribe({
        next: () => {
          console.log('Sala atualizada');
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