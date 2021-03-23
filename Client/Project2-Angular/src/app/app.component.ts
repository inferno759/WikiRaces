import { Component, OnInit } from '@angular/core';
import { OktaAuthService } from '@okta/okta-angular';
import { Location } from '@angular/common';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Wiki Races';
  isAuthenticated: boolean;
  baseUri: string;

  constructor(public oktaAuth: OktaAuthService) {
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => this.isAuthenticated = isAuthenticated
    );
  }


  async ngOnInit() {
      this.isAuthenticated = await this.oktaAuth.isAuthenticated();
    /*
    this.oktaAuth.isAuthenticated().then((auth) => {
      this.isAuthenticated = auth;

      
    });
    */
  }
  logout() {
    this.oktaAuth.signOut();
  }

  login() {
    this.oktaAuth.isLoginRedirect();
  }
  

}