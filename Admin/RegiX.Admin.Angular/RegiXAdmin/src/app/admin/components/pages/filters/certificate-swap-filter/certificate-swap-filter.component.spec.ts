import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateSwapFilterComponent } from './certificate-swap-filter.component';

describe('CertificateSwapFilterComponent', () => {
  let component: CertificateSwapFilterComponent;
  let fixture: ComponentFixture<CertificateSwapFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CertificateSwapFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CertificateSwapFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
