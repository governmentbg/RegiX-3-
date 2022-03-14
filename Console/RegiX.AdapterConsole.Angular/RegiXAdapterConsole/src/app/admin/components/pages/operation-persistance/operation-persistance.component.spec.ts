import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationPersistanceComponent } from './operation-persistance.component';

describe('OperationPersistanceComponent', () => {
  let component: OperationPersistanceComponent;
  let fixture: ComponentFixture<OperationPersistanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationPersistanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationPersistanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
