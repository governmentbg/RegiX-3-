import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EauthLoginComponent } from './eauth-login.component';

describe('EauthLoginComponent', () => {
  let component: EauthLoginComponent;
  let fixture: ComponentFixture<EauthLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EauthLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EauthLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
