import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserService } from '../shared/user.service';
import { User } from '../model/user';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DialogBodyComponent } from '../dialog-body/dialog-body.component';
import { UsersSummaryService } from '../shared/users-summary.service';
import { UsersSummary } from '../model/users-summary';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: User[];
  _user: User; 
  userSummary: UsersSummary;

  constructor(private service: UserService, 
    private matDialog: MatDialog,
    private serviceSummary: UsersSummaryService) { }

  ngOnInit() {
    //getting Users Data for table
    this.service.getUsers().subscribe( res => {
      this.users = res;
    })
  }

  //opening pop-up with total user count and active user count on button click
  openDialog() {
    const dialogConfig = new MatDialogConfig();
    //this.serviceSummary.getUsersSummary().subscribe(res => {
    //  this.userSummary = res;
    //});
    //dialogConfig.data = { 
    //  usersCount: this.userSummary.usersCount,
    //  usersActive: this.userSummary.usersActive
    //};
    dialogConfig.data = "some data";
    this.matDialog.open(DialogBodyComponent, dialogConfig);
  }

  //handler for checking/unchecking Active column
  updateUserActive(userID:string, userName: string, userActive: boolean) {
    console.log(event);
    this._user = this.users.find( user => user.id == userID);
    this.service.putUser(this._user);
  }

}
