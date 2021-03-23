import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { RaceService } from '../race.service';

import { RacePlayComponent } from './race-play.component';

describe('RacePlayComponent', () => {

  it('should create', () => {
    const fakehttp = {} as HttpClient;
    const fakeservice = new RaceService(fakehttp);
    const fakeroute = {} as ActivatedRoute;
    const component = new RacePlayComponent(fakeroute, fakeservice);
    expect(component).toBeTruthy();
  });
});
