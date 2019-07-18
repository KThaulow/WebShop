import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-imagegrid',
  templateUrl: './imagegrid.component.html',
  styleUrls: ['./imagegrid.component.css']
})
export class ImagegridComponent implements OnInit {
  images: Image[];

  constructor() { }

  ngOnInit() {
    this.images = [];
    this.images.push(new Image("Image 1", "/assets/gridimages/8XkyqQcliZs.jpg"));
    this.images.push(new Image("Image 2", "/assets/gridimages/AnaJ1ayu8B4.jpg"));
    this.images.push(new Image("Image 3", "/assets/gridimages/bfwA-BcD2L8.jpg"));
    this.images.push(new Image("Image 4", "/assets/gridimages/efoqp1uxrk4.jpg"));
    this.images.push(new Image("Image 5", "/assets/gridimages/eZTKitkTfAw.jpg"));
    this.images.push(new Image("Image 6", "/assets/gridimages/HBAdcw7hRdY.jpg"));
    this.images.push(new Image("Image 7", "/assets/gridimages/qttaGEhPyfU.jpg"));
    this.images.push(new Image("Image 8", "/assets/gridimages/Roq0u4MHbVU.jpg"));
    this.images.push(new Image("Image 9", "/assets/gridimages/Xf2h7jBeKIU.jpg"));
    this.images.push(new Image("Image 10", "/assets/gridimages/xkU-FYXiRQU.jpg"));
  }
}

class Image {

  public image: string;
  public title: string;

  constructor(title: string, image: string) {
    this.title = title;
    this.image = image;
  }

}
