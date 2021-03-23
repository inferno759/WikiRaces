import { HttpClient } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { LeaderboardService } from '../leaderboard.service';
import { RaceService } from '../race.service';

import { RaceDetailComponent } from './race-detail.component';

// describe('RaceDetailComponent', () => {

//   it('should create', () => {
//     const fakehttp = {} as HttpClient;
//     const fakeservice = new RaceService(fakehttp);
//     const fakeservice2 = new LeaderboardService(fakehttp);
//     const fakeroute = {} as ActivatedRoute;
//     const component = new RaceDetailComponent(fakeroute, fakeservice, fakeservice2, new Location());
//     expect(component).toBeTruthy();
//   });
// });
