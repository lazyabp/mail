import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { MailingComponent } from './mailing.component';

describe('MailingComponent', () => {
  let component: MailingComponent;
  let fixture: ComponentFixture<MailingComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MailingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MailingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
