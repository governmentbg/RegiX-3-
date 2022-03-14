import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent implements OnInit {
  items: any[];
  term: string;
  isDataLoading = false;

  constructor(
    public activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
  }
}
