import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterOperationsComponent } from './adapter-operations.component';

describe('AdapterOperationsComponent', () => {
  let component: AdapterOperationsComponent;
  let fixture: ComponentFixture<AdapterOperationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterOperationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterOperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
