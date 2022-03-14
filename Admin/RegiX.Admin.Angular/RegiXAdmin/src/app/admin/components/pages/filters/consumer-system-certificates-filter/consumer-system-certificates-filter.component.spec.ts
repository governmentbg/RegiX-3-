import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemCertificatesFilterComponent } from './consumer-system-certificates-filter.component';

describe('ConsumerSystemCertificatesFilterComponent', () => {
  let component: ConsumerSystemCertificatesFilterComponent;
  let fixture: ComponentFixture<ConsumerSystemCertificatesFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemCertificatesFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemCertificatesFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
