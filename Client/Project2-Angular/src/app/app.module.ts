import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { RacesComponent } from './races/races.component';
import { LoginComponent } from './login/login.component';
import { RaceDetailComponent } from './race-detail/race-detail.component';
import { RacePlayComponent } from './race-play/race-play.component';
import { RaceAddComponent } from './race-add/race-add.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    RacesComponent,
    LoginComponent,
    RaceDetailComponent,
    RacePlayComponent,
    RaceAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
