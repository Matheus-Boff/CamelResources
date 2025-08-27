import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourcesBoard } from './resources-board';

describe('ResourcesBoard', () => {
  let component: ResourcesBoard;
  let fixture: ComponentFixture<ResourcesBoard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ResourcesBoard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResourcesBoard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
