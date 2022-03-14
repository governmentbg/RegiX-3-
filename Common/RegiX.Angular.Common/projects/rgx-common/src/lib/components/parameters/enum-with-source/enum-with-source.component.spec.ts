import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnumWithSourceComponent } from './enum-with-source.component';

describe('EnumWithSourceComponent', () => {
  let component: EnumWithSourceComponent;
  let fixture: ComponentFixture<EnumWithSourceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnumWithSourceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnumWithSourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
