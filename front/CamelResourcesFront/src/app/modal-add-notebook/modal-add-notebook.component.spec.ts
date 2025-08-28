import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ModalAddNotebookComponent } from './modal-add-notebook.component';

describe('ModalAddNotebookComponent', () => {
  let component: ModalAddNotebookComponent;
  let fixture: ComponentFixture<ModalAddNotebookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalAddNotebookComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalAddNotebookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
