import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-fullscreen-button',
  templateUrl: './fullscreen-button.component.html',
  styleUrls: ['./fullscreen-button.component.css']
})

export class FullscreenButtonComponent implements OnInit {
  isFullscreen = false;
  elem: any;
  constructor(@Inject (DOCUMENT) private document: any) {
  
   }

  ngOnInit(): void {
    this.elem = document.documentElement;
  }

  setScreen()
  {
    this.isFullscreen ? this.exitFullscreen() : this.setFullscreen();
  }

  setFullscreen(){
    this.elem.requestFullscreen()
    this.isFullscreen = true;
  }

  exitFullscreen()
  {
    this.document.exitFullscreen()
    this.isFullscreen = false;
  }
}
