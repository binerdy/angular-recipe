import 'zone.js/dist/zone';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { bootstrapApplication } from '@angular/platform-browser';
import { DatePipeLocaleRecipe } from './recipe/date-pipe-locale-recipe.component';

@Component({
  selector: 'recipe-app',
  standalone: true,
  imports: [CommonModule, DatePipeLocaleRecipe],
  template: `
    <h1>Date Pipe Locale Recipe</h1>
    <date-pipe-locale-recipe />
  `,
})
export class App {
  locale = navigator.language;
  now = new Date();
}

bootstrapApplication(App);
