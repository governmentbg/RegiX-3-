import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemCertificatesFormComponent } from './consumer-system-certificates-form.component';

describe('ConsumerSystemCertificatesFormComponent', () => {
  let component: ConsumerSystemCertificatesFormComponent;
  let fixture: ComponentFixture<ConsumerSystemCertificatesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemCertificatesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemCertificatesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
