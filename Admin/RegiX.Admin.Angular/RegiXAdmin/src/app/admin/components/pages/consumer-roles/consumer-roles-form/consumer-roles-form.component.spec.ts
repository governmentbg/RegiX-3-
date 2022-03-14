import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRolesFormComponent } from './consumer-roles-form.component';

describe('ConsumerRolesFormComponent', () => {
  let component: ConsumerRolesFormComponent;
  let fixture: ComponentFixture<ConsumerRolesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRolesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRolesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
