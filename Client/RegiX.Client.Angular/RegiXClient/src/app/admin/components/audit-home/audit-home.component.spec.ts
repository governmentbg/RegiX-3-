import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditHomeComponent } from './audit-home.component';

describe('AuditHomeComponent', () => {
  let component: AuditHomeComponent;
  let fixture: ComponentFixture<AuditHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuditHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
