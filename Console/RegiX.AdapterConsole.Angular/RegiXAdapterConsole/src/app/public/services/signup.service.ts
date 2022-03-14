import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AccountSignup } from "../models/account-signup";
import { ConfigurationService } from '@tl/tl-common';

@Injectable({
  providedIn: "root"
})
export class SignupService {

    authApiURI = '';
    clientId = '';

  constructor(
    configureService: ConfigurationService,
    private http: HttpClient) {
      this.authApiURI = configureService.getStsServiceUrl();
      this.clientId = configureService.getClientId();
    }

  register(userRegistration: any) {
    return this.http.post(
      `${this.authApiURI}/api/account/${this.clientId}`,
      userRegistration
    );
  }
}
