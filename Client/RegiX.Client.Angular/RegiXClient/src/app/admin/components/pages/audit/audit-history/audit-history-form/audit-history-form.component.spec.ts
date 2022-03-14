import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditHistoryFormComponent } from './audit-history-form.component';

describe('AuditHistoryFormComponent', () => {
  let component: AuditHistoryFormComponent;
  let fixture: ComponentFixture<AuditHistoryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuditHistoryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditHistoryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
