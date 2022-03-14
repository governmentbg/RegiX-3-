import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterDevelopmentGuidelinesRecursiveComponent } from './adapter-development-guidelines-recursive.component';

describe('AdapterDevelopmentGuidelinesRecursiveComponent', () => {
  let component: AdapterDevelopmentGuidelinesRecursiveComponent;
  let fixture: ComponentFixture<AdapterDevelopmentGuidelinesRecursiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterDevelopmentGuidelinesRecursiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterDevelopmentGuidelinesRecursiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
