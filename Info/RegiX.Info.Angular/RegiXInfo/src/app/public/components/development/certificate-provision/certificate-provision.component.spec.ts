import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateProvisionComponent } from './certificate-provision.component';

describe('CertificateProvisionComponent', () => {
  let component: CertificateProvisionComponent;
  let fixture: ComponentFixture<CertificateProvisionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertificateProvisionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertificateProvisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
