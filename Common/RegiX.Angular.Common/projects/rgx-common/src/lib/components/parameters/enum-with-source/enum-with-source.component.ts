import { Component, OnInit, Injector } from '@angular/core';
import { EnumLoaderService } from '../../../services/enum-loader.service';
import { ParameterComponent } from '../parameter-component';
@Component({
  selector: 'rgx-enum-with-source',
  templateUrl: './enum-with-source.component.html',
  styleUrls: ['./enum-with-source.component.scss']
})
export class EnumWithSourceComponent extends ParameterComponent {
  public loaded = false;
  public values = [];
  public isLoading: boolean;

  constructor(injector: Injector,private enumLoaderService: EnumLoaderService) {
    super(injector);
  }

  ngOnInitImplementation() {
    const listType = this.parameter.parameterInfo.parameterType.type;
    const splitted = listType.split(':');
    if (splitted.length === 3) {
      this.isLoading = true;
      const operation = splitted[1];
      const hasEmptyValue = "true" === splitted[2];//parse string to boolen
      this.enumLoaderService
      .getEnumValues(operation,hasEmptyValue)
      .subscribe(data => {
        this.isLoading = false;
          this.values = data;
      });
    }
  }
}
