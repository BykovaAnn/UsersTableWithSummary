import { Component, OnInit } from '@angular/core';
import { UserLoginService } from 'src/app/shared/user-login.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  }

  constructor(private service: UserLoginService,
    private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/all_users');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/all_users');
      },
      err => {
        if (err.status == 400) {
          alert('Incorrect username or password.');
        }
        else
          console.log(err);
      }
    );
  }

}
