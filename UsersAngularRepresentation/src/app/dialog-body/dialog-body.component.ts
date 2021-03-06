import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UsersSummaryService } from '../shared/users-summary.service';
import { UsersSummary } from '../model/users-summary';

@Component({
  selector: 'app-dialog-body',
  templateUrl: './dialog-body.component.html',
  styleUrls: ['./dialog-body.component.css']
})
export class DialogBodyComponent implements OnInit {

  usersSummary: UsersSummary;
  //usersCount: number;
  //usersActive: number;

  constructor(public dialogRef: MatDialogRef<DialogBodyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: UsersSummaryService) {
    //this.usersCount = data.usersCount;
    //this.usersActive = data.usersActive;
  }

  ngOnInit() {
    //getting data for popup from service method
    this.service.getUsersSummary().subscribe(res => {
      this.usersSummary = res;
    });
  }

  close() {
    //close popup without actions and changes
    this.dialogRef.close();
  }

}
