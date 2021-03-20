import { getSafePropertyAccessString } from '@angular/compiler';
import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() users? : User[] = [];
  @Input() currentUser? : User;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private location: Location
    ) { }

  ngOnInit(): void {
    this.getUsers();
    this.getUserById();
  }

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

  goBack(): void{
    this.location.back();
  }

}
