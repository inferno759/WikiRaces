import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormControl } from '@angular/forms';

import { Race } from '../race';
import { RaceService } from '../race.service';


@Component({
  selector: 'app-race-add',
  templateUrl: './race-add.component.html',
  styleUrls: ['./race-add.component.css']
})
export class RaceAddComponent implements OnInit {
  @Input() race?: Race;
  raceForm = new FormGroup({
    raceTitle: new FormControl(''),
    raceType: new FormControl(''),
    timeLimit: new FormControl(0),
    stepLimit: new FormControl(0),
    startPage: new FormControl(''),
    endPage: new FormControl(''),
  });
  successMessage: string;

  constructor(
    private raceService: RaceService
    ) { }

  ngOnInit(): void {
    this.race = {
      id: 0,
      authorId: 1,
      raceTitle: '',
      raceType: '',
      timeLimit: 0,
      stepLimit: 0,
      startPage: '',
      endPage: ''
    };
  }

  add(): void{
    this.race.raceTitle = this.raceForm.value.raceTitle;
    this.race.raceType = this.raceForm.value.raceType;
    this.race.timeLimit = this.raceForm.value.timeLimit;
    this.race.stepLimit = this.raceForm.value.stepLimit;
    let start = this.raceForm.value.startPage.match('\/wiki\/.+')[0];
    let end = this.raceForm.value.endPage.match('\/wiki\/.+')[0];
    this.race.startPage = start;
    this.race.endPage = end;
    console.info(this.race);
    this.raceService.addRace(this.race)
    .subscribe(() => this.successMessage = 'Race added!');
  }

  get raceTitle() { return this.raceForm.get('raceTitle'); }

  get raceType() { return this.raceForm.get('raceType'); }

  get timeLimit() { return this.raceForm.get('timeLimit'); }

  get stepLimit() { return this.raceForm.get('stepLimit'); }

  get startPage() { return this.raceForm.get('startPage'); }

  get endPage() { return this.raceForm.get('endPage'); }


}
