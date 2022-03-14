import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemCertificatesComponent } from './consumer-system-certificates.component';

describe('ConsumerSystemCertificatesComponent', () => {
  let component: ConsumerSystemCertificatesComponent;
  let fixture: ComponentFixture<ConsumerSystemCertificatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemCertificatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemCertificatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
