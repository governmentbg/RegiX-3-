import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerElementAccessComponent } from './consumer-element-access.component';

describe('ElementAccessComponent', () => {
  let component: ConsumerElementAccessComponent;
  let fixture: ComponentFixture<ConsumerElementAccessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerElementAccessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerElementAccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
