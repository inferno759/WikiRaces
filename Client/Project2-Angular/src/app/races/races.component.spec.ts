import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RaceService } from '../race.service';

import { RacesComponent } from './races.component';

describe('RacesComponent', () => {

  it('should create', () => {
    const fakehttp = {} as HttpClient;
    const fakeservice = new RaceService(fakehttp);
    const component = new RacesComponent(fakeservice);
    expect(component).toBeTruthy();
  });
});
