import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationsListDetailsComponent } from './operations-list-details.component';

describe('OperationsListDetailsComponent', () => {
  let component: OperationsListDetailsComponent;
  let fixture: ComponentFixture<OperationsListDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationsListDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationsListDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
