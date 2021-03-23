import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { LeaderboardService } from './leaderboard.service';

describe('LeaderboardService', () => {

  it('should be created', () => {
    const fakehttp = {} as HttpClient;
    const service = new LeaderboardService(fakehttp);
    expect(service).toBeTruthy();
  });
});
