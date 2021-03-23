import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

import { Race } from '../race';
import { RaceService } from '../race.service';

@Component({
  selector: 'app-race-play',
  templateUrl: './race-play.component.html',
  styleUrls: ['./race-play.component.css']
})
export class RacePlayComponent implements OnInit {
  @Input() race? : Race;
  pageBody: string;

  currentURL: SafeUrl;
  randomURL = "https://en.wikipedia.org/wiki/Russia";

  constructor(
    private route: ActivatedRoute,
    private raceService: RaceService,
  ) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.raceService.getRaceById(id)
      .subscribe(race => {
        this.race = race;
        this.currentURL = this.race.startPage;
        let result = this.raceService.playRace(this.race);
        result.subscribe(pageBody => this.pageBody = pageBody);
      });
  }

  onClick() {
    console.info("User clicked!");
  }

}
