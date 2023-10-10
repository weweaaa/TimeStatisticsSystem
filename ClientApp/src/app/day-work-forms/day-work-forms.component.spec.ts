import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DayWorkFormsComponent } from './day-work-forms.component';

describe('DayWorkFormsComponent', () => {
  let component: DayWorkFormsComponent;
  let fixture: ComponentFixture<DayWorkFormsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [DayWorkFormsComponent]
    });
    fixture = TestBed.createComponent(DayWorkFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
