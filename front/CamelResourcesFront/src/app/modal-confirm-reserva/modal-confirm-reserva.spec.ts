import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalConfirmReserva } from './modal-confirm-reserva';

describe('ModalConfirmReserva', () => {
  let component: ModalConfirmReserva;
  let fixture: ComponentFixture<ModalConfirmReserva>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalConfirmReserva]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalConfirmReserva);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
