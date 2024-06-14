import { Component, Input } from '@angular/core';
import { HeroStore } from '../hero.store';

@Component({
  selector: 'app-hero-overview',
  templateUrl: './hero-overview.component.html',
  styleUrl: './hero-overview.component.scss'
})
export class HeroOverviewComponent {
  @Input() heroStore!: HeroStore; // after ngOnInit
}
