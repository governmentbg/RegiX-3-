import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessRequestsFormComponent } from './access-requests-form.component';

describe('AccessRequestsFormComponent', () => {
  let component: AccessRequestsFormComponent;
  let fixture: ComponentFixture<AccessRequestsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccessRequestsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessRequestsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
