import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { UserService } from './user.service';

describe('UserService', () => {

  it('should be created', () => {
    const fakehttp = {} as HttpClient;
    const service = new UserService(fakehttp);
    expect(service).toBeTruthy();
  });
});
