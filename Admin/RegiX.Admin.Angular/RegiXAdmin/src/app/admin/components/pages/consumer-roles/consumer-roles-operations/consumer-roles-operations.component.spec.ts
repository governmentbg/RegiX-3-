import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRolesOperationsComponent } from './consumer-roles-operations.component';

describe('ConsumerRolesOperationsComponent', () => {
  let component: ConsumerRolesOperationsComponent;
  let fixture: ComponentFixture<ConsumerRolesOperationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRolesOperationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRolesOperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
