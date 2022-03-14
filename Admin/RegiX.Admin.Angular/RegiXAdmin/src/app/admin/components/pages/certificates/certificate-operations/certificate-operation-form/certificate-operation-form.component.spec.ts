import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateOperationFormComponent } from './certificate-operation-form.component';

describe('CertificateOperationFormComponent', () => {
  let component: CertificateOperationFormComponent;
  let fixture: ComponentFixture<CertificateOperationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertificateOperationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertificateOperationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
