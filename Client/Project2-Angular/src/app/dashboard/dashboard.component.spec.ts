import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RaceService } from '../race.service';

import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {

  it('should create', () => {
    const fakehttp = {} as HttpClient;
    const fakeservice = new RaceService(fakehttp);
    const component = new DashboardComponent(fakeservice);
    expect(component).toBeTruthy();
  });
});
