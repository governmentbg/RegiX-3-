import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRolesOperationsFormComponent } from './consumer-roles-operations-form.component';

describe('ConsumerRolesOperationsFormComponent', () => {
  let component: ConsumerRolesOperationsFormComponent;
  let fixture: ComponentFixture<ConsumerRolesOperationsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRolesOperationsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRolesOperationsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
