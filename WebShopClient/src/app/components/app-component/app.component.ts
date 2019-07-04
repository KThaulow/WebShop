import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { User } from '../../models/user';

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
  }
}