import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationsFilterComponent } from './administrations-filter.component';

describe('AdministrationsFilterComponent', () => {
  let component: AdministrationsFilterComponent;
  let fixture: ComponentFixture<AdministrationsFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministrationsFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministrationsFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
