import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerAccessFormComponent } from './consumer-access-form.component';

describe('AccessFormComponent', () => {
  let component: ConsumerAccessFormComponent;
  let fixture: ComponentFixture<ConsumerAccessFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerAccessFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerAccessFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
