import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-login-panel',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;

  constructor() {
    this.loginForm = new FormGroup({
      login: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  ngOnInit() {
  }

  onSubmit(): void {

  }

}
