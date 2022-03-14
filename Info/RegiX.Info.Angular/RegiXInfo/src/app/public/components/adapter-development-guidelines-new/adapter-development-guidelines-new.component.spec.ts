import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapterDevelopmentGuidelinesNewComponent } from './adapter-development-guidelines-new.component';

describe('AdapterDevelopmentGuidelinesNewComponent', () => {
  let component: AdapterDevelopmentGuidelinesNewComponent;
  let fixture: ComponentFixture<AdapterDevelopmentGuidelinesNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdapterDevelopmentGuidelinesNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapterDevelopmentGuidelinesNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
