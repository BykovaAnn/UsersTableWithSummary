import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UserService } from '../shared/user.service';
import { User } from '../model/user';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DialogBodyComponent } from '../dialog-body/dialog-body.component';
import { UsersSummaryService } from '../shared/users-summary.service';
import { UsersSummary } from '../model/users-summary';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {

  users: User[];
  _user: User;
  userSummary: UsersSummary;

  constructor(private service: UserService,
    private matDialog: MatDialog,
    private serviceSummary: UsersSummaryService,
    private router: Router) { }

  ngOnInit() {
    this.service.getUsers().subscribe(res => {
      this.users = res;
    });
    if (localStorage.getItem('token') != null) {
      console.log(localStorage.getItem('token'));
    }
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = "some data";
    this.matDialog.open(DialogBodyComponent, dialogConfig);
  }

  updateUserActive(userID: string, userName: string, userActive: boolean) {
    console.log(event);
    this._user = this.users.find(user => user.id == userID);
    this.service.putUser(this._user);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    if (localStorage.getItem('token') == null) {
      console.log('We are logging out');
    }
  }

}



