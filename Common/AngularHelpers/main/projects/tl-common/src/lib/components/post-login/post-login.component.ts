import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AUTH_PATHS } from '../../modules/auth-paths';

@Component({
  selector: 'tl-post-login',
  templateUrl: './post-login.component.html',
  styleUrls: ['./post-login.component.css']
})
export class TLPostLoginComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    const error = new URL(location.href).searchParams.get('error');
    if (error) {
      this.router.navigate([`/${AUTH_PATHS.MAIN}`]);
    }
  }
}
