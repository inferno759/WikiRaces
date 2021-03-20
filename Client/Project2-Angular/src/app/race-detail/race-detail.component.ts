import { Component, OnInit, Input } from '@angular/core';
import { Race } from '../race';
import { LeaderboardLine } from '../leaderboardLine';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { RaceService } from '../race.service';
import { LeaderboardService } from '../leaderboard.service';

@Component({
  selector: 'app-race-detail',
  templateUrl: './race-detail.component.html',
  styleUrls: ['./race-detail.component.css']
})
export class RaceDetailComponent implements OnInit {

  @Input() race? : Race;
  @Input() leaderboardLines? : LeaderboardLine[];

  constructor(
    private route: ActivatedRoute,
    private raceService: RaceService,
    private leaderboardService: LeaderboardService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getRace();
    this.getLeaderboardLines();
  }

  getRace(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.raceService.getRaceById(id)
      .subscribe(race => this.race = race);
  }

  getLeaderboardLines(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.leaderboardService.getLeaderboardLinesByRaceId(id)
      .subscribe(lines => this.leaderboardLines = lines);
  }

  goBack(): void{
    this.location.back();
  }

}
