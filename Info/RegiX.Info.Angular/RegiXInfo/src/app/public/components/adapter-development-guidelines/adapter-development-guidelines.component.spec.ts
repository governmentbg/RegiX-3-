import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterDevelopmentGuidelinesComponent } from './adapter-development-guidelines.component';

describe('AdapterDevelopmentGuidelinesComponent', () => {
  let component: AdapterDevelopmentGuidelinesComponent;
  let fixture: ComponentFixture<AdapterDevelopmentGuidelinesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterDevelopmentGuidelinesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterDevelopmentGuidelinesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
