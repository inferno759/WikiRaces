import { Component, OnInit } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Wiki Races';
  isAuthenticated: boolean;

  constructor(public oktaAuth: OktaAuthService) {
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => this.isAuthenticated = isAuthenticated
    );
  }


  ngOnInit() {
    this.oktaAuth.isAuthenticated().then((auth) => {
      this.isAuthenticated = auth;
    });
  }

  login() {
    this.oktaAuth.isLoginRedirect();
  }
  

}