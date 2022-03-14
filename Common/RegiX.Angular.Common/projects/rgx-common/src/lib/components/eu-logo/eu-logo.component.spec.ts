import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EuLogoComponent } from './eu-logo.component';

describe('EuLogoComponent', () => {
  let component: EuLogoComponent;
  let fixture: ComponentFixture<EuLogoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EuLogoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EuLogoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
