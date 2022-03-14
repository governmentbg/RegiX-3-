import { RegisterListModel } from "./../../../core/model/register-list.model";
import { RestClientRegistersService } from "src/app/core/services/rest/rest-client-register-service";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: "app-administration-details",
  templateUrl: "./administration-details.component.html",
  styleUrls: ["./administration-details.component.scss"],
})
export class AdministrationDetailsComponent implements OnInit {
  public routes = ROUTES;
  
  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;
  pageTitle = "Преглед на регистри";

  registers: RegisterListModel[] = [];

  administrationAcronym: string;
  administrationName: string;

  constructor(
    private registerService: RestClientRegistersService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.administrationAcronym = params["ID"];
      this.administrationName = params["ADMINISTRATION_NAME"];
      this.pageTitle = "Преглед на регистри за: " + this.administrationName;
    });

    this.readRegisters(this.administrationAcronym);
  }

  private readRegisters(administrationAcronym: string) {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.registerService
      .retrieveByAdministration( {key: "acronym", value: this.administrationAcronym})
      .subscribe(
        (data) => {
          this.registers = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        (error) => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage = "Грешка при извличане на данни за регистри.";
        }
      );
  }

}
