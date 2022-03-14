import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerSystemsComponent } from './consumer-systems.component';

describe('ConsumerSystemsComponent', () => {
  let component: ConsumerSystemsComponent;
  let fixture: ComponentFixture<ConsumerSystemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerSystemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerSystemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
