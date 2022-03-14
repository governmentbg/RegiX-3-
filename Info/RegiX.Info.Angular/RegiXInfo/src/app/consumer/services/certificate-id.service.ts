import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CertificateIdService {
    private subject = new Subject<any>();

    sendCertificateId(id: number) {
        this.subject.next({ certificateId: id });
    }

    getCertificateId(): Observable<any> {
        return this.subject.asObservable();
    }
}