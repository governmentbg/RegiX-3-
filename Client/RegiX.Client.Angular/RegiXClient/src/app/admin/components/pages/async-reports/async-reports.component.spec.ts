import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsyncReportsComponent } from './async-reports.component';

describe('AsyncReportsComponent', () => {
  let component: AsyncReportsComponent;
  let fixture: ComponentFixture<AsyncReportsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsyncReportsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsyncReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
