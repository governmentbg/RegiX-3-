import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserActionFormComponent } from './user-action-form.component';

describe('UserActionFormComponent', () => {
  let component: UserActionFormComponent;
  let fixture: ComponentFixture<UserActionFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserActionFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserActionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
