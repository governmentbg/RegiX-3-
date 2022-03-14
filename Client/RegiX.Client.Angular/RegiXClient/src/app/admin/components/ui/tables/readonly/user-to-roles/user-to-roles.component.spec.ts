import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserToRolesComponent } from './user-to-roles.component';

describe('UserToRolesComponent', () => {
  let component: UserToRolesComponent;
  let fixture: ComponentFixture<UserToRolesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserToRolesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserToRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
