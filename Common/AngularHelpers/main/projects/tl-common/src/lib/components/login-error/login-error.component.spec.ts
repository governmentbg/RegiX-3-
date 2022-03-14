import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TLLoginErrorComponent } from './login-error.component';

describe('LoginErrorComponent', () => {
  let component: TLLoginErrorComponent;
  let fixture: ComponentFixture<TLLoginErrorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TLLoginErrorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TLLoginErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
