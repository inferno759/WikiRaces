import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { RacesComponent } from './races/races.component';
import { LoginComponent } from './login/login.component';
import { RaceDetailComponent } from './race-detail/race-detail.component';
import { RacePlayComponent } from './race-play/race-play.component';
import { RaceAddComponent } from './race-add/race-add.component';
import { LoginProfileComponent } from './login-profile/login-profile.component';
import { OKTA_CONFIG, OktaAuthModule,
         OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';
import { RouterModule } from '@angular/router';
import { OktaConfig } from '@okta/okta-angular';



// Okta dynamic environment config

const config: OktaConfig = {
  clientId: '0oacai6gk38wXie3v5d6',
  issuer: 'https://dev-50964723.okta.com/oauth2/default',
  redirectUri: 'https://team4-project2-client.azurewebsites.net/dashboard',
  scopes: ['openid', 'profile', 'email'],
  pkce: true
};


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    RacesComponent,
    LoginComponent,
    RaceDetailComponent,
    RacePlayComponent,
    RaceAddComponent,
    LoginProfileComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    OktaAuthModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: OKTA_CONFIG, useValue: config },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
