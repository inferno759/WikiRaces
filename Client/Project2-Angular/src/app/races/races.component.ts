import { getSafePropertyAccessString } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';

import { Race } from '../race';
import { RaceService } from '../race.service';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.css']
})
export class RacesComponent implements OnInit {

  races$: Observable<Race[]>;
  private searchTerms = new Subject<string>();
  private searchInit = true;

  constructor(private raceService : RaceService) { }


  // Push a search term into the observable stream.
  search(term: string): void {
    if (this.searchInit)
    {
      this.races$ = this.searchTerms.pipe(
        // wait 300ms after each keystroke before considering the term
        debounceTime(300),
  
        // ignore new term if same as previous term
        distinctUntilChanged(),
  
        // switch to new search observable each time the term changes
        switchMap((term: string) => this.raceService.searchRaces(term)),
      );
      this.searchInit = false;
    }
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.getRaces();
  }

  getRaces() : void {
    this.races$ = this.raceService.getRaces()
  }

}
