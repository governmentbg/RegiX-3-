import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateOperationAccessComponent } from './certificate-operation-access.component';

describe('CertificateOperationAccessComponent', () => {
  let component: CertificateOperationAccessComponent;
  let fixture: ComponentFixture<CertificateOperationAccessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertificateOperationAccessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertificateOperationAccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
