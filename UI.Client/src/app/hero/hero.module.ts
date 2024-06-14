import { CommonModule } from '@angular/common';
import { NgModule, inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, RouterModule, RouterStateSnapshot, Routes } from "@angular/router";
import { Observable, firstValueFrom, forkJoin, of, take } from "rxjs";
import { HeroDetailComponent } from "./hero-detail/hero-detail.component";
import { HeroOverviewComponent } from "./hero-overview/hero-overview.component";
import { HeroClient } from "./hero.client";
import { HeroStore } from "./hero.store";
import { HeroListComponent } from './hero-list/hero-list.component';

const resolveHeros: ResolveFn<HeroStore> = async (): Promise<HeroStore> => {
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

const resolveHero: ResolveFn<HeroStore> = (router: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<HeroStore> => {
  const heroStore = inject(HeroStore);
  const id = Number(router.params["id"]);

  heroStore.setCurrentHeroId(id);

  return of(heroStore).pipe(take(1));
}

const routes: Routes = [
  {
    path: "",
    resolve: { heroStore: resolveHeros },
    children: [
      {
        path: "",
        component: HeroOverviewComponent
      },
      {
        path: ":id",
        component: HeroDetailComponent,
        resolve: { heroStore: resolveHero }
      }
    ]
  }
];

@NgModule({
  declarations: [
    HeroListComponent,
    HeroDetailComponent,
    HeroOverviewComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class HeroModule { }
