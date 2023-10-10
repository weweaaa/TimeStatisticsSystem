import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { NgIf, NgFor } from '@angular/common';

@Component({
    selector: 'app-fatch-day-work-data',
    templateUrl: './fatch-day-work-data.component.html',
    standalone: true,
    imports: [NgIf, NgFor],
})
export class FatchDayWorkDataComponent {
  public dayWorkDatas: DayWorkResponse[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DayWorkResponse[]>(baseUrl + 'DayWork').subscribe(
      (result) => {
        this.dayWorkDatas = result;
      },
      (error) => console.error(error),
    );
  }
}

interface DayWorkResponse {
  日期: string;
  開始時間: string;
  主要分類: string;
  次要分類: string;
  備註: string;
  花費時間: 0;
  起始結束: string;
}
