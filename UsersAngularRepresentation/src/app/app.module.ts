import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatDialogModule } from '@angular/material';
import { DialogBodyComponent } from "./dialog-body/dialog-body.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegistrationComponent } from './user/registration/registration.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { LoginComponent } from './user/login/login.component';
import { UsersTableComponent } from './users-table/users-table.component';
import { AuthInterceptor } from './auth/auth.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    DialogBodyComponent,
    RegistrationComponent,
    LoginComponent,
    UsersTableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
  entryComponents: [DialogBodyComponent]
})
export class AppModule { }
