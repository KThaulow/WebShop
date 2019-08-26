import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { LikeChangedEventArgs } from './likechangedeventargs';

@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.css']
})
export class LikeComponent implements OnInit {

  @Input("isLiked")
  isLiked: boolean = false;

  @Input("likesCount")
  likesCount: number = 0;

  @Output("change")
  changeEvent = new EventEmitter<LikeChangedEventArgs>();

  constructor() { }

  ngOnInit() {
  }

  clicked() {
    this.isLiked = !this.isLiked;
    this.likesCount = this.isLiked ? this.likesCount + 1 : this.likesCount - 1;
    this.changeEvent.emit(new LikeChangedEvent(this.likesCount, this.isLiked));
  }
}

class LikeChangedEvent implements LikeChangedEventArgs {
  constructor(public likesCount: number, public isLiked: boolean) {
  }
}


