import { Component, OnInit } from '@angular/core';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent {
  settingsRoute = ROUTES.SETTINGS;
  public routes = [
    {reference: ROUTES.ADMINISTRATIONS},
    {reference: ROUTES.USERS},
    {reference: ROUTES.ROLES},
    {reference: ROUTES.REPORTS},
    {reference: ROUTES.FAVOURITES}
  ];
}
