import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatiosListComponent } from './operatios-list.component';

describe('OperatiosListComponent', () => {
  let component: OperatiosListComponent;
  let fixture: ComponentFixture<OperatiosListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperatiosListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperatiosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
