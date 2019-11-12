import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from '../user/user.component';
import { RegistrationComponent } from '../user/registration/registration.component';

const routes: Routes = [
  {path:'',redirectTo:'/auth/registration',pathMatch:'full'},
  {
    path: 'auth', component: RegistrationComponent,
    children: [
      { path: 'registration', component: UserComponent  }
    ]
  },
  {path:'all_users', component: UserComponent},
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
