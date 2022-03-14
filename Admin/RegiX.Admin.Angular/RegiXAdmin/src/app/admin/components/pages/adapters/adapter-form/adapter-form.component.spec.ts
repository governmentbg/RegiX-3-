import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterFormComponent } from './adapter-form.component';

describe('AdapterFormComponent', () => {
  let component: AdapterFormComponent;
  let fixture: ComponentFixture<AdapterFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
