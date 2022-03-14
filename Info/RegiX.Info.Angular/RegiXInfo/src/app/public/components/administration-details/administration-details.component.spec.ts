import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationDetailsComponent } from './administration-details.component';

describe('AdministrationDetailsComponent', () => {
  let component: AdministrationDetailsComponent;
  let fixture: ComponentFixture<AdministrationDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministrationDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministrationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
