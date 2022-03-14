import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavouriteReportsComponent } from './favourite-reports.component';

describe('FavouriteReportsComponent', () => {
  let component: FavouriteReportsComponent;
  let fixture: ComponentFixture<FavouriteReportsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouriteReportsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouriteReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
