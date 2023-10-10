import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { NgIf, NgFor } from '@angular/common';
import { getBaseUrl } from 'src/main';
import { DayWorkResponse } from '../models/DayWorkResponse';
import { DayWorkFormsComponent } from '../day-work-forms/day-work-forms.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-fatch-day-work-data',
  templateUrl: './fatch-day-work-data.component.html',
  standalone: true,
  imports: [NgIf, NgFor, MatDialogModule],
  providers: [
    HttpClient,
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  ],
})
export class FatchDayWorkDataComponent {
  public dayWorkDatas: DayWorkResponse[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, public dialog: MatDialog) {
    http.get<DayWorkResponse[]>(baseUrl + 'DayWork').subscribe(
      (result) => {
        this.dayWorkDatas = result;
      },
      (error) => console.error(error),
    );
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DayWorkFormsComponent, {
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
