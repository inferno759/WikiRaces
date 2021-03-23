import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { LeaderboardLine } from './leaderboardLine';

@Injectable({
  providedIn: 'root'
})
export class LeaderboardService {
  private leaderboardUrl = 'https://team4-project2.azurewebsites.net/api/leaderboard';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    if (location.origin.includes("localhost"))
    {
      this.leaderboardUrl = `${location.origin}/api/leaderboard`;
    }
  }

  getLeaderboardLinesByRaceId(raceId: number): Observable<LeaderboardLine[]> {
    return this.http.get<LeaderboardLine[]>(`${this.leaderboardUrl}/race/${raceId}`)
      .pipe(
        tap(_ => this.log('fetched leaderboard')),
        catchError(this.handleError<LeaderboardLine[]>('getLeaderboardLines', []))
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
