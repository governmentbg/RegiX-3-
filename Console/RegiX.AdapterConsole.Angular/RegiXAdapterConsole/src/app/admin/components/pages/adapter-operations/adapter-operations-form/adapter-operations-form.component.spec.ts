import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterOperationsFormComponent } from './adapter-operations-form.component';

describe('AdapterOperationsFormComponent', () => {
  let component: AdapterOperationsFormComponent;
  let fixture: ComponentFixture<AdapterOperationsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterOperationsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterOperationsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
