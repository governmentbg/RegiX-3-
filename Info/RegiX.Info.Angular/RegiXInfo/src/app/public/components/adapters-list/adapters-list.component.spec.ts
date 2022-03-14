import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdaptersListComponent } from './adapters-list.component';

describe('AdaptersListComponent', () => {
  let component: AdaptersListComponent;
  let fixture: ComponentFixture<AdaptersListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdaptersListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdaptersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
