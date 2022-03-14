import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessEditFormComponent } from './access-edit-form.component';

describe('AccessFormComponent', () => {
  let component: AccessEditFormComponent;
  let fixture: ComponentFixture<AccessEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccessEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
