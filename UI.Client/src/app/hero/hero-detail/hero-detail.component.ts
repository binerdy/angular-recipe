import { Component, Input } from '@angular/core';
import { HeroStore } from '../hero.store';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrl: './hero-detail.component.scss'
})
export class HeroDetailComponent {
  @Input() public heroStore!: HeroStore;
}
