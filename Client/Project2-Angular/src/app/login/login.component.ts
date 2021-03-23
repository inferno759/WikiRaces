import { getSafePropertyAccessString } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { OktaAuthService } from '@okta/okta-angular';


@Component({
  selector: 'app-login',
  //template: `<button *ngIf= "!isAuthenticated" (click)="login()"> Login </button>`,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  isAuthenticated: boolean;

  @Input() users? : User[] = [];
  @Input() currentUser? : User;
  @Input() isRegister? : boolean = false;


  constructor(public oktaAuth: OktaAuthService,
      private userService: UserService,
      private route: ActivatedRoute,
      private location: Location) {
    // Subscribe to authentication state changes
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => this.isAuthenticated = isAuthenticated
    );
  }

  async ngOnInit() {
    if( this.isAuthenticated == false)
    {
      await this.oktaAuth.isAuthenticated();
    }
    else
    {
      this.logout();
    } 
    
  }

  login() {
    this.oktaAuth.signInWithRedirect({
      originalUri: './dashboard'
    });    
  }
  
  logout() {
    this.oktaAuth.signOut();
  }
}


/*

  getUsers() : void {
    this.userService.getUsers()
    .subscribe(users => this.users = users);
  }


  getUserById() : void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.userService.getUserById(id)
      .subscribe(user => this.currentUser = user);
  }
  getUserByUsername() : void {
    const username = this.route.snapshot.paramMap.get('username');
    this.userService.getUserByUsername(username)
      .subscribe(user => this.currentUser = user);
  }
  displayRegister() : void {
    this.isRegister = true;
  }

  goBackToLogin(): void{
    this.isRegister = false;
  }
*/
