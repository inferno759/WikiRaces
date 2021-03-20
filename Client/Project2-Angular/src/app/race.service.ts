import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Race } from './race';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
  private racesUrl = 'https://team4-project2.azurewebsites.net/api/race';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }


  
  /** GET races from the server */
  getRaces(): Observable<Race[]> {
    return this.http.get<Race[]>(this.racesUrl)
      .pipe(
        tap(_ => this.log('fetched races')),
        catchError(this.handleError<Race[]>('getRaces', []))
      );
  }

  getRaceById(id: number): Observable<Race> {
    const url = `${this.racesUrl}/id/${id}`;
    return this.http.get<Race>(url)
      .pipe(
        tap(_ => this.log(`fetched race with id ${id}`)),
        catchError(this.handleError<Race>(`getRace id=${id}`))
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
    //this.messageService.add(`HeroService: ${message}`);
  }
}
