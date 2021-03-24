import { Component, OnInit, Input } from '@angular/core';
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
  user? : string;

  constructor(public oktaAuth: OktaAuthService) {
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => this.isAuthenticated = isAuthenticated
    );
  }


  async ngOnInit() {
      this.isAuthenticated = await this.oktaAuth.isAuthenticated();
      const userClaims = await this.oktaAuth.getUser();
      this.user = userClaims.name;
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