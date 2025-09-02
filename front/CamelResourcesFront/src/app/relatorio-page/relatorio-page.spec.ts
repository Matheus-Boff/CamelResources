import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatorioPage } from './relatorio-page';

describe('RelatorioPage', () => {
  let component: RelatorioPage;
  let fixture: ComponentFixture<RelatorioPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RelatorioPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RelatorioPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
