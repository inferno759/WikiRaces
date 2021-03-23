import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';

import { Race } from '../race';
import { RaceService } from '../race.service';


@Component({
  selector: 'app-race-add',
  templateUrl: './race-add.component.html',
  styleUrls: ['./race-add.component.css']
})
export class RaceAddComponent implements OnInit {
  @Input() race?: Race;

  constructor(
    private raceService: RaceService
    ) { }

  ngOnInit(): void {
    this.race = {
      id: 0,
      authorId: 1,  // fill this based on currently logged in user
      raceTitle: "",
      raceType: "",
      timeLimit: 0,
      stepLimit: 0,
      startPage: "",
      endPage: ""
    }
  }

  add(): void{
    console.info(this.race);
    this.raceService.addRace(this.race);
  }

}
