import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroVersionModule } from './hero-version/hero-version.module';
import { HeroModule } from './hero/hero.module';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "hero-version"
  },
  {
    path: "hero-version",
    loadChildren: () => HeroVersionModule
  },
  {
    path: "hero-version/:id",
    loadChildren: () => HeroModule
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    bindToComponentInputs: true
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
