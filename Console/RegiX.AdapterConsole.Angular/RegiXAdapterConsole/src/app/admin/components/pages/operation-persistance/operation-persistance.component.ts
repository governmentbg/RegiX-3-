import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { OperationPersistanceService } from 'src/app/core/services/rest/operation-persistance.service';
import { OperationPersistanceModel } from 'src/app/core/models/dto/operation-persistance.model';

@Component({
  selector: 'app-operation-persistance',
  templateUrl: './operation-persistance.component.html',
  styleUrls: ['./operation-persistance.component.scss']
})
export class OperationPersistanceComponent  extends RemoteComponentWithForm<
OperationPersistanceModel,
OperationPersistanceService
> {
  public routes = ROUTES;
  currentObjectId: number;

  constructor(service: OperationPersistanceService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  onShowMenuSelected(event) {}

  downloadContent(obj: OperationPersistanceModel){
    const fileText = obj.rawUnsignedResult;
    const fileName = 'ResponseForSignature.xml';
    this.saveTextAsFile(fileText, fileName);
  }

  onFileSelectionChange() {
    const input = <HTMLInputElement>document.getElementById('fileChooserInput');
    // this.pickFiles(input.files);
    const numFiles = input.files ? input.files.length : 1;
    if (numFiles === 1) {
      this.pickFile(input.files);
    }
  }
  private pickFile(fileList: FileList) {
    const file = fileList[0];
    const extension = file.name.substring(file.name.lastIndexOf('.') + 1);
    if (extension.toUpperCase() === 'XML') {
      this.getFileText(file).then((data: string) => {
        const fileName = file.name;
        this.service.update(this.currentObjectId,
          new OperationPersistanceModel({
              id: this.currentObjectId,
              rawResult: data
            }
          )
        ).subscribe(
          r => this.readData(),
          e => this.logger.error(e)
        );
      });
    }
  }

  private getFileText(file) {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsText(file);
      reader.onload = () => {
        const text = reader.result.toString().trim();
        resolve(text);
      };
      reader.onerror = (error) => reject(error);
    });
  }

  uploadContent(obj: OperationPersistanceModel) {
    const btn = document.getElementById(
      'fileChooserInput'
    ) as HTMLButtonElement;
    this.currentObjectId = obj.id;
    btn.click();
  }

  private saveTextAsFile(data, filename) {
    if (!data) {
      console.error('Console.save: No data');
      return;
    }

    if (!filename) {
      filename = 'console.json';
    }

    var blob = new Blob([data], { type: 'text/plain' }),
      e = document.createEvent('MouseEvents'),
      a = document.createElement('a');
    // FOR IE:

    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
      window.navigator.msSaveOrOpenBlob(blob, filename);
    } else {
      var e = document.createEvent('MouseEvents'),
        a = document.createElement('a');

      a.download = filename;
      a.href = window.URL.createObjectURL(blob);
      a.dataset.downloadurl = ['text/plain', a.download, a.href].join(':');
      e.initEvent('click', true, false);
      a.dispatchEvent(e);
    }
  }
}
