import { Component, OnInit } from '@angular/core';
import { Race } from '../race';
import { RaceService } from '../race.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-race-add',
  templateUrl: './race-add.component.html',
  styleUrls: ['./race-add.component.css']
})
export class RaceAddComponent implements OnInit {

  constructor(
    private raceService: RaceService,
    private location: Location) { }

  ngOnInit(): void {
  }

  add(race: Race): void{
    this.raceService.addRace(race);
  }

}
