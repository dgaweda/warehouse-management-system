import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'success-alert',
  template: `<h4 class="alert alert-success">success-alert works!</h4>`,
})
export class SuccessAlertComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
