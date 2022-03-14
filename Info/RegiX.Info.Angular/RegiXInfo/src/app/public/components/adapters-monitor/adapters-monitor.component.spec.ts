import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdaptersMonitorComponent } from './adapters-monitor.component';

describe('AdaptersMonitorComponent', () => {
  let component: AdaptersMonitorComponent;
  let fixture: ComponentFixture<AdaptersMonitorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdaptersMonitorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdaptersMonitorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
