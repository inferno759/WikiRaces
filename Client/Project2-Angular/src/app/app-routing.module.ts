import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { RacesComponent } from './races/races.component';
import { RaceDetailComponent } from './race-detail/race-detail.component';
import { RacePlayComponent } from './race-play/race-play.component';



const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'races', component: RacesComponent },
  { path: 'races/detail/:id', component: RaceDetailComponent },
  { path: 'races/detail/:id/play', component: RacePlayComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }