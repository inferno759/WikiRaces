import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RaceService } from '../race.service';

import { RaceAddComponent } from './race-add.component';

describe('RaceAddComponent', () => {

  it('should create', () => {
    const fakehttp = {} as HttpClient;
    const fakeservice = new RaceService(fakehttp);
    const component = new RaceAddComponent(fakeservice);
    expect(component).toBeTruthy();
  });
});
