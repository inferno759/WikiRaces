import { Component, OnInit } from '@angular/core';

import { Race } from '../race';
import { RaceService } from '../race.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  races: Race[] = [];

  constructor(private raceService: RaceService) { }

  ngOnInit(): void {
    this.getRaces();
  }

  getRaces(): void {
    this.raceService.getRaces()
      .subscribe(races => this.races = races.slice(0, 1));
      
  }

}
