import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationTypesComponent } from './administration-types.component';

describe('AdministrationTypesComponent', () => {
  let component: AdministrationTypesComponent;
  let fixture: ComponentFixture<AdministrationTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministrationTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministrationTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
