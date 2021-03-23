import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { User } from './user';

 @Injectable({
  providedIn: 'root'
})
export class UserService {
  private userUrl = 'https://team4-project2.azurewebsites.net/api/user';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {
    if (location.origin.includes("localhost"))
    {
      this.userUrl = `${location.origin}/api/user`;
    }
  }


  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.userUrl)
      .pipe(
        tap(_ => this.log('fetched users')),
        catchError(this.handleError<User[]>('getUsers', []))
      );
  }

  getUserById(userId: number): Observable<User> {
    const url = `${this.userUrl}/id/${userId}`;
    return this.http.get<User>(url)
      .pipe(
        tap(_ => this.log(`fetched user with id ${userId}`)),
        catchError(this.handleError<User>(`getUser id=${userId}`))
      );
  }

  getUserByUsername(username: string): Observable<User> {
    const url = `${this.userUrl}/${username}`;
    return this.http.get<User>(url)
      .pipe(
        tap(_ => this.log(`fetched user with name ${username}`)),
        catchError(this.handleError<User>(`getUser name=${username}`))
      );
  

  }


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

  private log(message: string){

  }


}


