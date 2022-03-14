import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesComponent } from './consumer-profiles.component';

describe('ConsumerProfilesComponent', () => {
  let component: ConsumerProfilesComponent;
  let fixture: ComponentFixture<ConsumerProfilesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
