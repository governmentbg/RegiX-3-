import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReportsSelectComponent } from './reports-select.component';


describe('OperationsComponent', () => {
  let component: ReportsSelectComponent;
  let fixture: ComponentFixture<ReportsSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportsSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportsSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
