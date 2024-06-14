import { Injectable } from '@angular/core';
import { Observable, delay, of } from 'rxjs';
import { ReferenceData } from '../shared/reference-data.model';
import { Hero } from './hero.model';

@Injectable({
  providedIn: 'root'
})
export class HeroClient {

  constructor() { }

  public getHeroes(): Observable<Hero[]> {
    return of([
      { id: 0, name: 'Quantum Knight' },
      { id: 1, name: 'Mystic Blaze' },
      { id: 2, name: 'Shadow Vanguard' },
      { id: 3, name: 'Eclipse Sentinel' },
      { id: 4, name: 'Galactic Guardian' }
    ]).pipe(delay(500));
  }

  public getReferenceData(type: "powers" | "weakness"): Observable<ReferenceData[]> {
    return type === "powers"
      ? of([
        { key: "flight", type: "powers", displayName: "Flight" },
        { key: "invisibility", type: "powers", displayName: "Invisibility" },
        { key: "superStrength", type: "powers", displayName: "Super Strength" },
        { key: "telepathy", type: "powers", displayName: "Telepathy" },
        { key: "timeTravel", type: "powers", displayName: "Time Travel" }
      ])
    : of([
      { key: "kryptonite", type: "weakness", displayName: "Kryptonite" },
      { key: "magic", type: "weakness", displayName: "Magic" },
      { key: "soundFrequency", type: "weakness", displayName: "Sound Frequency" },
      { key: "water", type: "weakness", displayName: "Water" },
      { key: "fire", type: "weakness", displayName: "Fire Weakness" }
    ]).pipe(delay(1000));
  }
}
