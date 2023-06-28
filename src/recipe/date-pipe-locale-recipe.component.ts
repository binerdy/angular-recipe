import { Component, LOCALE_ID } from '@angular/core';
import { CommonModule, DATE_PIPE_DEFAULT_OPTIONS } from '@angular/common';
import { registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';

registerLocaleData(localeDe);

@Component({
  selector: 'date-pipe-locale-recipe',
  standalone: true,
  imports: [CommonModule],
  providers: [
    {
      provide: DATE_PIPE_DEFAULT_OPTIONS,
      useValue: {
        dateFormat: 'shortDate',
        timezone: navigator.language,
      },
    },
    {
      provide: LOCALE_ID,
      useValue: navigator.language,
    },
  ],
  template: `
    <p>Browser locale: {{locale}}</p>
    <p>Date: {{now | date}}</p>
  `,
})
export class DatePipeLocaleRecipe {
  locale = navigator.language;
  now = new Date();
}
