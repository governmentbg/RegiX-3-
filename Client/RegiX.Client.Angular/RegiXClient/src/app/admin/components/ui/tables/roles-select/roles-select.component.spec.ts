import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesSelectComponent } from './roles-select.component';

describe('RolesForUserComponent', () => {
  let component: RolesSelectComponent;
  let fixture: ComponentFixture<RolesSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RolesSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
