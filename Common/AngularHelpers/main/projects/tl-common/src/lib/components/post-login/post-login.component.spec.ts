import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TLPostLoginComponent } from './post-login.component';

describe('PostLoginComponent', () => {
  let component: TLPostLoginComponent;
  let fixture: ComponentFixture<TLPostLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TLPostLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TLPostLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
