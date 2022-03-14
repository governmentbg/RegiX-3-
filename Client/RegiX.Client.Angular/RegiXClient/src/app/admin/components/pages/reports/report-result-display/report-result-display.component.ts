import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  NoOpScrollStrategy,
  VerticalAlignment,
} from 'igniteui-angular';
import { from, Observable } from 'rxjs';

const b64toBlob2 = (base64, type = 'application/octet-stream') =>
  fetch(`data:${type};base64,${base64}`).then((res) => res.blob());

@Component({
  selector: 'app-report-result-display',
  templateUrl: './report-result-display.component.html',
  styleUrls: ['./report-result-display.component.scss'],
})
export class ReportResultDisplayComponent implements OnInit, OnDestroy {
  @Input()
  public html: string;

  @Input()
  public pdf: string;

  public pdfSource: SafeResourceUrl = null;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };

  constructor(private sanitizer: DomSanitizer) {}

  ngOnDestroy(): void {
    if (
      this.pdfSource &&
      this.pdfSource['changingThisBreaksApplicationSecurity']
    ) {
      URL.revokeObjectURL(
        this.pdfSource['changingThisBreaksApplicationSecurity']
      );
    }
  }

  ngOnInit() {
    if (this.pdf) {
      from(
        b64toBlob2(this.pdf, 'application/pdf').then((b) => {
          const url = URL.createObjectURL(b);
          this.pdfSource = this.sanitizer.bypassSecurityTrustResourceUrl(url);
        })
      );
    }
  }
}
