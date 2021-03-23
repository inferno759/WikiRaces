import { TestBed } from '@angular/core/testing';
import {HttpClient} from '@angular/common/http';
import { RaceService } from './race.service';
import { Observable, of } from 'rxjs';
import { Race } from './race';

describe('RaceService', () => {
  

  it('should be created', () => {
    const fakehttp = {} as HttpClient;
    const service = new RaceService(fakehttp);
    expect(service).toBeTruthy();
  });

  it('should get races', () => {
    let passedUrl: string = '';
    const observable: Observable<Race[]> = of([]);
    const fakehttp = {
      get(url: string) {
        passedUrl = url;
        return observable;
      }
    } as HttpClient;
    const service = new RaceService(fakehttp);
    const result = service.getRaces();
    console.log(result);
    expect(passedUrl).toBeTruthy();
  });

});
