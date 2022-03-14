import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemsFormComponent } from './consumer-systems-form.component';

describe('ConsumerSystemsFormComponent', () => {
  let component: ConsumerSystemsFormComponent;
  let fixture: ComponentFixture<ConsumerSystemsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
