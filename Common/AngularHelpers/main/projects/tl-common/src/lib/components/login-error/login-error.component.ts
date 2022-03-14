import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AUTH_PATHS } from '../../modules/auth-paths';

@Component({
  selector: 'tl-login-error',
  templateUrl: './login-error.component.html',
  styleUrls: ['./login-error.component.scss']
})
export class TLLoginErrorComponent implements OnInit {
  public error: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.error = new URL(location.href).searchParams.get('error');
  }

  getOrigin(): string{
    return window.location.origin;
  }
}
