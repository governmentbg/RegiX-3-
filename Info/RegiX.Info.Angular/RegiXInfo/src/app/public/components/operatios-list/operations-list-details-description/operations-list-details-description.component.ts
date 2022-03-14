import { Component, OnInit, AfterViewInit, Input, ChangeDetectorRef } from '@angular/core';
import { EOperationType } from 'src/app/core/enums/operation-type.enum';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { OperationPropertyModel } from 'src/app/core/model/regix/operation-property.model';
import { SafeHtml, DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ConfigurationService } from '@tl/tl-common';
import { OperationDetailsModel } from 'src/app/core/model/operation-details.model';

@Component({
  selector: 'app-operations-list-details-description',
  templateUrl: './operations-list-details-description.component.html',
  styleUrls: ['./operations-list-details-description.component.scss']
})
export class OperationsListDetailsDescriptionComponent implements OnInit, AfterViewInit {
  @Input()
  operationType: EOperationType;
  @Input()
  operation: OperationDetailsModel;
  @Input()
  adapter: AdapterModel;
  operationDetail: OperationPropertyModel;

  descriptionHtml: SafeHtml;
  opType = EOperationType;
  visualizationUrl: SafeResourceUrl;

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
    this.visualizationUrl = this.getSafeVisualizationURL();
  }

  ngAfterViewInit() {

  }

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
        this.operation.requestXSD) ||
      (this.operationType === EOperationType.Response &&
        this.operation.responseXSD)
    ) {
      return true;
    }
    return false;
  }

  isCommonAvailable(): boolean {
    if (this.operation.commonXSD && this.operation.commonXSD.length > 0) {
      return true;
    }
    return false;
  }

  isSampleDataAvailable(): boolean {
    if (
      (this.operationType === EOperationType.Request &&
        this.operation.sampleRequestXML) ||
      (this.operationType === EOperationType.Response &&
        this.operation.sampleResponseXML)
    ) {
      return true;
    }
    return false;
  }

  isVisualizationAvailable(): boolean {
    return true;
  }

  getSafeVisualizationURL(): SafeResourceUrl{
    const url =
    this.configurationService.getServiceUrl() +
    '/api/XSLT/sample/' +
    this.operationType.toLowerCase() +
    '/' +
    this.adapter.interface +
    '.' +
    this.operation.fullName +
    '.xml';
    const sanitized = this.sanitizer.bypassSecurityTrustResourceUrl(url);
    return sanitized;
  }

  getSampleText() {
    if (this.operationType === EOperationType.Request) {
      return this.operation.sampleRequestXML;
    }
    if (this.operationType === EOperationType.Response) {
      return this.operation.sampleResponseXML;
    }
  }

  getCommonText() {
    let xml = '';
    this.operation.commonXSD.forEach(x => {
      xml += x;
    });
    return xml;
  }

  getSchemeText() {
    if (this.operationType === EOperationType.Request) {
      return this.operation.requestXSD;
    }
    if (this.operationType === EOperationType.Response) {
      return this.operation.responseXSD;
    }
  }
}
