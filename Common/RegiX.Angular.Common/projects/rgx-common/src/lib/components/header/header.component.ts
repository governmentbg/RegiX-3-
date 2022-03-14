import { Component } from '@angular/core';

@Component({
  selector: 'rgx-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent{

  public projectText = 'Надграждане на хоризонталните и централни системи на електронното управление във връзка с "Единния модел за заявяване, заплащане и предоставяне на електронни административни услуги" по процедура BG05SFOP001-1.004 "Надграждане на хоризонталните и централни системи за електронното управление" по Оперативна програма "Добро управление"';

  constructor() { }
}
