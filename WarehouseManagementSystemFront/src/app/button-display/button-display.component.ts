import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-button-display',
  templateUrl: './button-display.component.html',
  styleUrls: ['./button-display.component.css']
})
export class ButtonDisplayComponent implements OnInit {

  constructor() { }
  isClicked = false;
  log = [];
  i = 0;

  ngOnInit(): void {
  }

  displayDetails()
  {
    this.isClicked = !this.isClicked;
    this.log.push(this.i++);
  }

  setStyle()
  {
    
  }
}
