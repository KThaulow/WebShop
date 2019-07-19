import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-carousel',
  templateUrl: './image-carousel.component.html',
  styleUrls: ['./image-carousel.component.css']
})
export class ImageCarouselComponent implements OnInit {

  images: EImage[];

  constructor() { }

  ngOnInit() {
    this.images = [];
    this.images.push(new EImage("Image 1", "/assets/gridimages/8XkyqQcliZs.jpg"));
    this.images.push(new EImage("Image 2", "/assets/gridimages/AnaJ1ayu8B4.jpg"));
    this.images.push(new EImage("Image 3", "/assets/gridimages/bfwA-BcD2L8.jpg"));
    this.images.push(new EImage("Image 4", "/assets/gridimages/efoqp1uxrk4.jpg"));
    this.images.push(new EImage("Image 5", "/assets/gridimages/eZTKitkTfAw.jpg"));
    this.images.push(new EImage("Image 6", "/assets/gridimages/HBAdcw7hRdY.jpg"));
    this.images.push(new EImage("Image 7", "/assets/gridimages/qttaGEhPyfU.jpg"));
    this.images.push(new EImage("Image 8", "/assets/gridimages/Roq0u4MHbVU.jpg"));
    this.images.push(new EImage("Image 9", "/assets/gridimages/Xf2h7jBeKIU.jpg"));
    this.images.push(new EImage("Image 10", "/assets/gridimages/xkU-FYXiRQU.jpg"));
  }
}
