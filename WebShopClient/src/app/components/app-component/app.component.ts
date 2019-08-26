import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { User } from '../../models/user';
import { LikeChangedEventArgs } from '../like/likechangedeventargs';

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {

  tweet = {
    body: "This is the body...",
    isLiked: true,
    likesCount: 15
  }


  constructor(private router: Router) {
  }

  hasChanged(args: LikeChangedEventArgs) {
    console.log(args);
  }
}