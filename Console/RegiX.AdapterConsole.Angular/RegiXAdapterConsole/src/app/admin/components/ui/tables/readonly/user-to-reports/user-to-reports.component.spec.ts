import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserToReportsComponent } from './user-to-reports.component';

describe('UserToReportsComponent', () => {
  let component: UserToReportsComponent;
  let fixture: ComponentFixture<UserToReportsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserToReportsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserToReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
