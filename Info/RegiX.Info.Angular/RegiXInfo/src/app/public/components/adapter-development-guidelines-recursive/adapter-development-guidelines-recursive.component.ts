import { MarkdownModel } from './../../models/markdown.model';
import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { ClickerService } from '../services/clicker.service';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';

@Component({
  selector: 'app-adapter-development-guidelines-recursive',
  templateUrl: './adapter-development-guidelines-recursive.component.html',
  styleUrls: ['./adapter-development-guidelines-recursive.component.scss'],
  animations: [
    trigger('indicatorRotate', [
      state('collapsed', style({ transform: 'rotate(0deg)' })),
      state('expanded', style({ transform: 'rotate(180deg)' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
      ),
    ]),
  ],
})
export class AdapterDevelopmentGuidelinesRecursiveComponent implements OnInit {
  @Input()
  mdFiles: MarkdownModel[];

  constructor(private clickerService: ClickerService) {}

  ngOnInit(): void {}

  expanded = {};

  public navigate(item: MarkdownModel) {
    this.clickerService.clicked(item.fileName);
    if (item.subMarkdowns && item.subMarkdowns.length) {
      this.expanded[item.id] = !this.expanded[item.id];
    }
  }
}
