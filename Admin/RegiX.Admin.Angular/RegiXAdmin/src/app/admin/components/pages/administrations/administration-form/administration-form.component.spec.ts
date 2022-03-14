import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationFormComponent } from './administration-form.component';

describe('AdministrationFormComponent', () => {
  let component: AdministrationFormComponent;
  let fixture: ComponentFixture<AdministrationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministrationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministrationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
