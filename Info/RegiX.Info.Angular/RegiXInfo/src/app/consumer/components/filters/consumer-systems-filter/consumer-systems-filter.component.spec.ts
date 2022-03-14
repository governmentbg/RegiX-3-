import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemsFilterComponent } from './consumer-systems-filter.component';

describe('ConsumerSystemsFilterComponent', () => {
  let component: ConsumerSystemsFilterComponent;
  let fixture: ComponentFixture<ConsumerSystemsFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemsFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemsFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
