import { Component, OnInit } from '@angular/core';
import * as feather from 'feather-icons';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  constructor() {
  }

  ngOnInit() {
    feather.replace();
  }
}
