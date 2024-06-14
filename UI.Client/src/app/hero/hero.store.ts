import { Injectable } from '@angular/core';
import { computed, observable } from 'mobx-angular';
import { Hero } from './hero.model';
import { ReferenceData } from '../shared/reference-data.model';
import { action } from 'mobx';

@Injectable({
  providedIn: 'root'
})
export class HeroStore {
  @observable private currentHeroId: number = 0;
  @observable public heroes: Hero[] = [];
  @observable public powers: ReferenceData[] = [];
  @observable public weaknesses: ReferenceData[] = [];

  @action
  public setHeroes(heroes: Hero[]): void {
    this.heroes = heroes;
  }

  @action
  public setPowers(powers: ReferenceData[]): void {
    this.powers = powers;
  }

  @action
  public setWeakness(weaknesses: ReferenceData[]): void {
    this.weaknesses = weaknesses;
  }

  @action
  public setCurrentHeroId(id: number): void {
    this.currentHeroId = id;
  }

  @computed
  public get total(): number {
    return this.heroes.length;
  }

  @computed
  public get currentHero(): Hero | undefined {
    return this.heroes.find(hero => hero.id === this.currentHeroId);
  }
}
