import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';

import { LoginProfileComponent } from './login-profile.component';

describe('LoginProfileComponent', () => {

  it('should create', () => {
    const fakehttp = {} as HttpClient;
    const fakeservice = new UserService(fakehttp);
    const fakeroute = {} as ActivatedRoute;
    const component = new LoginProfileComponent(fakeroute, fakeservice);
    expect(component).toBeTruthy();
  });
});
