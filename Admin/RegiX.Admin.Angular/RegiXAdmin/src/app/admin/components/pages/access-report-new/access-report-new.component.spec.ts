import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessReportNewComponent } from './access-report-new.component';

describe('AccessReportNewComponent', () => {
  let component: AccessReportNewComponent;
  let fixture: ComponentFixture<AccessReportNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccessReportNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessReportNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
