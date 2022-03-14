import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateOperationsComponent } from './certificate-operations.component';

describe('CertificateOperationsComponent', () => {
  let component: CertificateOperationsComponent;
  let fixture: ComponentFixture<CertificateOperationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertificateOperationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertificateOperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
