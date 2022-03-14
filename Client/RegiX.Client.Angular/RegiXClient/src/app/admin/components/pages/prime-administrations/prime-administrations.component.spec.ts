import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimeAdministrationsComponent } from './prime-administrations.component';

describe('PrimeAdministrationsComponent', () => {
  let component: PrimeAdministrationsComponent;
  let fixture: ComponentFixture<PrimeAdministrationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrimeAdministrationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrimeAdministrationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
