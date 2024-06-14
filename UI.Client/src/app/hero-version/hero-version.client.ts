import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HeroVersion } from './hero-version.model';

@Injectable({
  providedIn: 'root'
})
export class HeroClient {

  constructor() { }

  public getHeroVersions(): Observable<HeroVersion[]> {
    return of([
      { id: "a1", displayName: 'British Heroes' },
      { id: "b2", displayName: 'Canadian Heroes' },
      { id: "c3", displayName: 'Swiss Heroes' },
      { id: "d4", displayName: 'German Heroes' },
      { id: "e5", displayName: 'Japanese Heroes' }
    ]);
  }
}
