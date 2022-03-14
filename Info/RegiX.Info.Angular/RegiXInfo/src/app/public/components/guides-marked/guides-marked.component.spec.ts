import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GuidesMarkedComponent } from './guides-marked.component';

describe('GuidesMarkedComponent', () => {
  let component: GuidesMarkedComponent;
  let fixture: ComponentFixture<GuidesMarkedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GuidesMarkedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GuidesMarkedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
