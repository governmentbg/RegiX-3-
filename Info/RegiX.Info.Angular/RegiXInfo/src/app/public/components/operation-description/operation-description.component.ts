import {
  Component,
  OnInit,
  Input,
  ChangeDetectorRef,
  AfterViewInit
} from '@angular/core';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { OperationPropertyModel } from 'src/app/core/model/regix/operation-property.model';
import { EOperationType } from 'src/app/core/enums/operation-type.enum';
import { ConfigurationService } from '@tl/tl-common';

@Component({
  selector: 'app-operation-description',
  templateUrl: './operation-description.component.html',
  styleUrls: ['./operation-description.component.scss']
})
export class OperationDescriptionComponent implements OnInit, AfterViewInit {
  @Input()
  operationType: EOperationType;
  @Input()
  operation: OperationModel;
  @Input()
  adapter: AdapterModel;
  operationDetail: OperationPropertyModel;

  descriptionHtml: SafeHtml;

  constructor(
    public configurationService: ConfigurationService,
    private sanitizer: DomSanitizer,
    private changeDetector: ChangeDetectorRef
  ) {}

  ngOnInit() {
    if (this.operationType === EOperationType.Request) {
      this.operationDetail = this.operation.request;
    } else if (this.operationType === EOperationType.Response) {
      this.operationDetail = this.operation.response;
    }
    this.createDataStructure();
  }

  ngAfterViewInit() {}

  private createDataStructure() {
    if (this.operationDetail.children) {
      let text = this.buildDescriptionText(this.operationDetail.children);
      if (text === '') {
        text = 'Операцията няма параметри.';
      }
      // text = '<p>' + text + '</p>';
      this.descriptionHtml = this.sanitizer.bypassSecurityTrustHtml(text);
    }
    // this.changeDetector.detectChanges();
  }

  private buildDescriptionText(children: OperationPropertyModel[]): string {
    let text = '';
    if (children && children.length > 0) {
      text = '<ul class="a">';
      children.forEach(c => {
        text +=
          '<li><span><b>' +
          c.name +
          '</b></span> - <span>' +
          c.description +
          '</span></li>';
        if (c.children) {
          const subString = this.buildDescriptionText(c.children);
          text += '' + subString + '';
        }
      });
      text += '</ul>';
    }
    return text;
  }

  isXSDSchemeAvailable(): boolean {
    if (
      (this.operationType === EOperationType.Request &&
        this.operation.xsdRequest) ||
      (this.operationType === EOperationType.Response &&
        this.operation.xsdResponse)
    ) {
      return true;
    }
    return false;
  }

  isCommonAvailable(): boolean {
    if (this.operation.xsdCommon && this.operation.xsdCommon.length > 0) {
      return true;
    }
    return false;
  }

  isSampleDataAvailable(): boolean {
    if (
      (this.operationType === EOperationType.Request &&
        this.operation.requestSampleData) ||
      (this.operationType === EOperationType.Response &&
        this.operation.responseSampleData)
    ) {
      return true;
    }
    return false;
  }

  getSampleText() {
    if (this.operationType === EOperationType.Request) {
      return this.operation.requestSampleData;
    }
    if (this.operationType === EOperationType.Response) {
      return this.operation.responseSampleData;
    }
  }

  getCommonText() {
    let xml = '';
    this.operation.xsdCommon.forEach(x => {
      xml += x;
    });
    return xml;
  }

  getSchemeText() {
    if (this.operationType === EOperationType.Request) {
      return this.operation.xsdRequest;
    }
    if (this.operationType === EOperationType.Response) {
      return this.operation.xsdResponse;
    }
  }
}
