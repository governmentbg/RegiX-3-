import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRolesComponent } from './consumer-roles.component';

describe('ConsumerRolesComponent', () => {
  let component: ConsumerRolesComponent;
  let fixture: ComponentFixture<ConsumerRolesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRolesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
