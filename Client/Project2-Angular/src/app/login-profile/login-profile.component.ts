import { getSafePropertyAccessString } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';


@Component({
  selector: 'app-login-profile',
  templateUrl: './login-profile.component.html',
  styleUrls: ['./login-profile.component.css']
})
export class LoginProfileComponent implements OnInit {

  @Input() users? : User[] = [];
  @Input() friends? : User[] = [];

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() : void {
    this.userService.getUsers()
    .subscribe(users => this.users = users);
  }

  addFriend() : void {
    
  }





}
