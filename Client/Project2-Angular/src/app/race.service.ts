import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Race } from './race';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
  private racesUrl ='https://team4-project2.azurewebsites.net/api/race'; 
  


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    if (location.origin.includes("localhost"))
    {
      this.racesUrl = `${location.origin}/api/race`;
    }
  }


  
  /** GET races from the server */
  getRaces(): Observable<Race[]> {
    return this.http.get<Race[]>(this.racesUrl)
      .pipe(
        tap(_ => this.log('fetched races')),
        catchError(this.handleError<Race[]>('getRaces', []))
      );
  }

  getRaceById(raceId: number): Observable<Race> {
    const url = `${this.racesUrl}/id/${raceId}`;
    return this.http.get<Race>(url)
      .pipe(
        tap(_ => this.log(`fetched race with id ${raceId}`)),
        catchError(this.handleError<Race>(`getRace id=${raceId}`))
      );
  }

  /* GET races whose raceTitle contains search term */
  searchRaces(term: string) {
    if (!term.trim()) {
      // if not search term, return default race array. api/race/title/{raceTitle}
      return this.getRaces();
    }
    return this.http.get<Race[]>(`${this.racesUrl}/title/${term}`).pipe(
      tap(x => x.length ?
        this.log(`found races matching "${term}"`) :
        this.log(`no races matching "${term}"`)),
      catchError(this.handleError<Race[]>('searchRaces', []))
    );
  }

  addRace(race: Race): Observable<Race> {
    return this.http.post<Race>(this.racesUrl, race, this.httpOptions).pipe(
      tap(() => this.log(`added race`)),
      catchError(this.handleError<Race>(`addRace`))
    );
  }


  /* GET race start page content from server by race id */
  playRace(race: Race) {
    return this.http.get(`${this.racesUrl}/play/${race.id}`, {
      responseType: 'text'
    }).pipe(
      tap(body => body ? 
        this.log(`starting race with id ${race.id}`) :
        this.log(`no race with id ${race.id}`)),
      catchError(this.handleError<string>('playRace', `${race.id}`))
    );
  }

  /* GET race next page content from server by user selection */
  stepRace(race: Race, current: string, step: string) {
    return this.http.get(`${this.racesUrl}/play/${race.id}/step?current=${current}&step=${step}`, {
      responseType: 'text'
    }).pipe(
      tap(body => body ? 
        this.log(`stepping from page "${current}" to page "${step}"`) :
        this.log(`step attempt from page "${current}" to page "${step}" failed`)),
      catchError(this.handleError<string>('stepRace', `${current}; ${step}`))
    );
  }


    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
     private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
  
        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead
  
        // TODO: better job of transforming error for user consumption
        this.log(`${operation} failed: ${error.message}`);
  
        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    console.info(message);
    //this.messageService.add(`HeroService: ${message}`);
  }
}
