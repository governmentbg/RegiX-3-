import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesToReportComponent } from './roles-to-report.component';

describe('RolesToReportComponent', () => {
  let component: RolesToReportComponent;
  let fixture: ComponentFixture<RolesToReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RolesToReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesToReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
