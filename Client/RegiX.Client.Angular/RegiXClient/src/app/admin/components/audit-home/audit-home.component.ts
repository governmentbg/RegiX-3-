import { Component, OnInit } from '@angular/core';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-audit-home',
  templateUrl: './audit-home.component.html',
  styleUrls: ['./audit-home.component.scss']
})
export class AuditHomeComponent {
  public audit = ROUTES.AUDIT;
  public routes = [
    {reference: ROUTES.AUDIT_DATA},
    {reference: ROUTES.SYSTEM_ERRORS},
    {reference: ROUTES.USER_ACTIONS},
    {reference: ROUTES.REPORT_EXECUTIONS}
  ];
}
