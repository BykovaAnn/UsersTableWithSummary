import { Component, OnInit } from '@angular/core';
//import { ToastrService } from 'ngx-toastr';
import { UserRegistrationService } from 'src/app/shared/user-registration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserRegistrationService,
    private router: Router) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.router.navigate(['/user/login']);
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                alert('Username is already taken');
                break;

              default:
                alert('Registration failed. Reason: ' + element.description);
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
