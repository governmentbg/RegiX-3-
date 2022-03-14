import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationsListDetailsDescriptionComponent } from './operations-list-details-description.component';

describe('OperationsListDetailsDescriptionComponent', () => {
  let component: OperationsListDetailsDescriptionComponent;
  let fixture: ComponentFixture<OperationsListDetailsDescriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationsListDetailsDescriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationsListDetailsDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
