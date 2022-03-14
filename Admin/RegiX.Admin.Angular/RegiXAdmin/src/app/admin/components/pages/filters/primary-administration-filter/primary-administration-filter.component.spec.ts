import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimaryAdministrationFilterComponent } from './primary-administration-filter.component';

describe('PrimaryAdministrationFilterComponent', () => {
  let component: PrimaryAdministrationFilterComponent;
  let fixture: ComponentFixture<PrimaryAdministrationFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrimaryAdministrationFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrimaryAdministrationFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
