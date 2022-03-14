import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdministrationsService } from 'src/app/core/services/rest/administrations.service';
import { SearchResult } from 'src/app/core/model/search-result.model';
import { ROUTES } from '../../routes/static-routes';
import { TlRouteArguments } from '@tl/tl-common';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss'],
})
export class SearchResultsComponent implements OnInit {
  originalItems: any[];
  items: any[] = [];
  term: string;
  isDataLoading = false;
  searchTypeKeys = [];
  rl = [];
  searchTypes =
  {
    All:
    {
      icon: 'done_all',
      enabled: true,
      title: 'Всички',
      hidden: true
    },
    Administration:
    {
      icon: ROUTES.ADMINISTRATIONS.icon,
      enabled: false,
      title: 'Администрации',
      hidden: true
    },
    Register: {
      icon: ROUTES.REGISTRIES.icon,
      enabled: false,
      title: 'Регистри',
      hidden: true
    },
    Adapter: {
      icon: 'developer_board',
      enabled: false,
      title: 'Адаптери',
      hidden: true
    },
    Operation: {
      icon: 'receipt',
      enabled: false,
      title: 'Операции',
      hidden: true
    },
    CommonXSD: {
      icon: 'article',
      enabled: false,
      title: 'Споделени XSD схеми',
      hidden: true
    },
    Request: {
      icon: 'send',
      enabled: false,
      title: 'XSD на заявка',
      hidden: true
    },
    Response: {
      icon: 'reply',
      enabled: false,
      title: 'XSD на отговор',
      hidden: true
    },
    marked: {
      icon: ROUTES.GUIDES.icon,
      enabled: false,
      title: ROUTES.GUIDES.title,
      hidden: true
    }
  };

  constructor(
    public activatedRoute: ActivatedRoute,
    public administrationServices: AdministrationsService
  ) {
    this.searchTypeKeys = Object.keys(this.searchTypes);
  }

  filterItems(searchTypeKey: string) {
    this.searchTypeKeys.forEach( key => {
      this.searchTypes[key].enabled = (searchTypeKey === key);
      }
    );
    this.items.length = 0;
    this.originalItems.forEach( i => {
      if (this.searchTypes['All'].enabled  ||
          this.searchTypes[i.type].enabled) {
        this.items.push(i);
      }
    });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.term = params['TERM'];
      this.isDataLoading = true;
      this.administrationServices.search(this.term).subscribe((items) => {
        this.searchTypeKeys.forEach(k => {
            this.searchTypes[k].enabled = false;
            this.searchTypes[k].hidden = true;
          }
        );
        this.searchTypes.All.hidden = (items.length === 0);
        this.searchTypes.All.enabled = (items.length !== 0);
        this.originalItems = items.map((i) => {
          let routeReference;
          let argumentsObj: TlRouteArguments;
          let aIcon;
          switch (i.type) {
            case 'Administration':
              this.searchTypes.Administration.hidden = false;
              aIcon = ROUTES.ADMINISTRATIONS.icon;
              routeReference = ROUTES.REGISTRIES;
              argumentsObj = { ':ADM_CODE': i.arguments[0] };
              break;
            case 'Register':
              this.searchTypes.Register.hidden = false;
              aIcon = ROUTES.REGISTRIES.icon;
              routeReference = ROUTES.REGISTRIES;
              argumentsObj = { ':ADM_CODE': i.arguments[0] };
              break;
            case 'Adapter':
              aIcon = 'developer_board';
              this.searchTypes.Adapter.hidden = false;
              routeReference = ROUTES.REGISTRIES;
              argumentsObj = { ':ADM_CODE': i.arguments[0] };
              break;
            case 'Operation':
              this.searchTypes.Operation.hidden = false;
              aIcon = 'receipt';
              routeReference = ROUTES.OPERATIONS_VIEW;
              argumentsObj = {
                ':ADM_CODE': i.arguments[0],
                ':INTERFACE': i.arguments[1],
                ':OPERATION_NAME': i.arguments[2],
              };
              break;
            case 'CommonXSD':
              this.searchTypes.CommonXSD.hidden = false;
              aIcon = 'article';
              routeReference = ROUTES.OPERATIONS_VIEW;
              argumentsObj = {
                ':ADM_CODE': i.arguments[0],
                ':INTERFACE': i.arguments[1],
                ':OPERATION_NAME': i.arguments[2],
              };
              break;
            case 'Request':
              this.searchTypes.Request.hidden = false;
              aIcon = 'send';
              routeReference = ROUTES.OPERATIONS_VIEW;
              argumentsObj = {
                ':ADM_CODE': i.arguments[0],
                ':INTERFACE': i.arguments[1],
                ':OPERATION_NAME': i.arguments[2],
              };
              break;
            case 'Response':
              this.searchTypes.Response.hidden = false;
              aIcon = 'reply';
              routeReference = ROUTES.OPERATIONS_VIEW;
              argumentsObj = {
                ':ADM_CODE': i.arguments[0],
                ':INTERFACE': i.arguments[1],
                ':OPERATION_NAME': i.arguments[2],
              };
              break;
            case 'marked':
              this.searchTypes.marked.hidden = false;
              aIcon = ROUTES.GUIDES.icon;
              routeReference = ROUTES.GUIDES;
              argumentsObj = {
                ':MARKED': i.arguments[0]
              };
              break;
          }
          return {
            reference: routeReference,
            args: argumentsObj,
            title: i.displayName,
            type: i.type,
            permissions: [],
            icon: aIcon,
          };
        });
        this.filterItems('All');
        this.isDataLoading = false;
      });
    });
  }
}
