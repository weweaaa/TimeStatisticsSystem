import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DayWorkResponse } from '../models/DayWorkResponse';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';
import { MainCategory } from '../models/MainCategory';
import { SubCategory } from '../models/SubCategory';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-day-work-forms',
  standalone: true,
  imports: [
    CommonModule, FormsModule,
    MatDialogModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatDatepickerModule, MatNativeDateModule
  ],
  templateUrl: './day-work-forms.component.html',
  styleUrls: ['./day-work-forms.component.css'],
  providers: [
    MatDatepickerModule,
  ],
})
export class DayWorkFormsComponent {
  public mainCategory_enum: MainCategory = MainCategory.請選擇;
  public subCategory_enum: SubCategory = SubCategory.請選擇;

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
