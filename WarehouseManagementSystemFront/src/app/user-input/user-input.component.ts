import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-input',
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.css']
})
export class UserInputComponent implements OnInit {

  constructor() { 
  }
  userName = "";
  isEmpty = true;
  isCleared = false;

  ngOnInit(): void {
  }

  checkIfEmpty(){
    this.isEmpty = this.userName === "";
  }

  clearInput(){
    this.userName = "";
    this.isEmpty = true;
    this.isCleared = true;

    setTimeout(() => {
      this.isCleared = false;
    }, 3000);
  }
}
