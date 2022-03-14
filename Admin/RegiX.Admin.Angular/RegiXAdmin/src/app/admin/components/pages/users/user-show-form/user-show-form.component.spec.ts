import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserShowFormComponent } from './user-show-form.component';

describe('UserShowFormComponent', () => {
  let component: UserShowFormComponent;
  let fixture: ComponentFixture<UserShowFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserShowFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserShowFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
