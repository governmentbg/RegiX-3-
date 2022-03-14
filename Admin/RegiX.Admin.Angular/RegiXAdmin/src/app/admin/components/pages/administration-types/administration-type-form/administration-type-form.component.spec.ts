import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationTypeFormComponent } from './administration-type-form.component';

describe('AdministrationTypeFormComponent', () => {
  let component: AdministrationTypeFormComponent;
  let fixture: ComponentFixture<AdministrationTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministrationTypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministrationTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
