import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesFormComponent } from './consumer-profiles-form.component';

describe('ConsumerProfilesFormComponent', () => {
  let component: ConsumerProfilesFormComponent;
  let fixture: ComponentFixture<ConsumerProfilesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
