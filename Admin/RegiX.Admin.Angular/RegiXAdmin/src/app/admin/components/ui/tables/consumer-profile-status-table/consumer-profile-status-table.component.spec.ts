import { ConsumerProfileStatusTableComponent } from './../consumer-profile-status-table/consumer-profile-status-table.component';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';


describe('ConsumerProfileStatusComponent', () => {
  let component: ConsumerProfileStatusTableComponent;
  let fixture: ComponentFixture<ConsumerProfileStatusTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfileStatusTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfileStatusTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
