import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsufficientPrivilegesComponent } from './insufficient-privileges.component';

describe('InsufficientPrivilegesComponent', () => {
  let component: InsufficientPrivilegesComponent;
  let fixture: ComponentFixture<InsufficientPrivilegesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsufficientPrivilegesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsufficientPrivilegesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
