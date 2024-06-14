import { Component, Input } from '@angular/core';
import { HeroStore } from '../hero.store';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrl: './hero-list.component.scss'
})
export class HeroListComponent {
  @Input() public heroStore!: HeroStore;
}
