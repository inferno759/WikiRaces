import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { User } from './user';

import { UserService } from './user.service';

describe('UserService', () => {
  let passedUrl = '';
  const fakehttp = {
    get(url: string) {
      passedUrl = url;
      return of([]);
    }
  } as HttpClient;
  const service = new UserService(fakehttp);


  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get users', () => {
    const result = service.getUsers();
    expect(result).toBeTruthy();
  });

  it('should get user by ID', () => {
    const observable: Observable<User> = of();

    const spyClient = jasmine.createSpyObj('HttpClient', ['get']);
    spyClient.get.and.returnValue(observable);

    const service = new UserService(spyClient);
    const id = 1;
    const result = service.getUserById(id);

    expect(spyClient.get).toHaveBeenCalledWith(
      `${location.origin}/api/user/id/${id}`
    );
    expect(result).toBeTruthy();
  });

  it('should get user by username', () => {
    const observable: Observable<User> = of();

    const spyClient = jasmine.createSpyObj('HttpClient', ['get']);
    spyClient.get.and.returnValue(observable);

    const service = new UserService(spyClient);
    const username = 'trevor';
    const result = service.getUserByUsername(username);

    expect(spyClient.get).toHaveBeenCalledWith(
      `${location.origin}/api/user/${username}`
    );
    expect(result).toBeTruthy();
  });
});
