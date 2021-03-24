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

  currentURL: any;
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
        this.raceService.playRace(this.race)
          .subscribe(pageBody => this.pageBody = pageBody);
      });
  }

  onClick(event: Event) {
    event.preventDefault();
    var target = event.target as HTMLElement;
    var href = target.attributes["href"];

    if (href)
    {
      this.raceService.stepRace(this.race, this.currentURL, href.value)
        .subscribe(pageBody => {
          if (pageBody != "") {
            this.currentURL = href.value;
            this.pageBody = pageBody;
          }
        });
    }
  }

}
