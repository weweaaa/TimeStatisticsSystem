import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DayWorkResponse } from '../models/DayWorkResponse';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-day-work-forms',
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatFormFieldModule],
  templateUrl: './day-work-forms.component.html',
  styleUrls: ['./day-work-forms.component.css']
})
export class DayWorkFormsComponent {
  public dayWorkData: DayWorkResponse = {
    日期: '',
    開始時間: '',
    主要分類: 0,
    次要分類: 0,
    備註: '',
    花費時間: 0,
    起始結束: '',
  };
}
