import { inject } from "@angular/core";
import { ResolveFn } from "@angular/router";
import { firstValueFrom, forkJoin } from "rxjs";
import { HeroStore } from "../hero/hero.store";
import { HeroClient } from "./hero-version.client";

const heroVersionResolver: ResolveFn<HeroStore> = async (): Promise<HeroStore> => {
  const heroStore = inject(HeroStore);
  const heroClient = inject(HeroClient);

  const data = await firstValueFrom(forkJoin({
    heroes: heroClient.getHeroes(),
    powers: heroClient.getReferenceData("powers"),
    weakness: heroClient.getReferenceData("weakness")
  }));

  heroStore.setHeroes(data.heroes);
  heroStore.setPowers(data.powers);
  heroStore.setWeakness(data.weakness);

  return heroStore;
}