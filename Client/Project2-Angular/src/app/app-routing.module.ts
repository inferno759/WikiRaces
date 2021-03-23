import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { RacesComponent } from './races/races.component';
import { RaceDetailComponent } from './race-detail/race-detail.component';
import { RacePlayComponent } from './race-play/race-play.component';
import { RaceAddComponent } from './race-add/race-add.component';
import { OktaAuthGuard, OktaCallbackComponent } from '@okta/okta-angular';

const CALLBACK_PATH = 'login/callback';

const routes: Routes = [
  { path: CALLBACK_PATH, component: OktaCallbackComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent, canActivate: [OktaAuthGuard] },
  { path: 'races', component: RacesComponent },
  { path: 'races/add', component: RaceAddComponent },
  { path: 'races/detail/:id', component: RaceDetailComponent },
  { path: 'races/detail/:id/play', component: RacePlayComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
