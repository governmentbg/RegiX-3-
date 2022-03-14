import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TLLoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: TLLoginComponent;
  let fixture: ComponentFixture<TLLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TLLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TLLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
