import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LaboratoriosPage } from './laboratorios-page';

describe('LaboratoriosPage', () => {
  let component: LaboratoriosPage;
  let fixture: ComponentFixture<LaboratoriosPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LaboratoriosPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LaboratoriosPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
