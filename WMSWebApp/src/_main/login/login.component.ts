import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, FormBuilder} from '@angular/forms';
import { Validators } from '@angular/forms';
import {ActivatedRoute, Router} from "@angular/router";
import {AuthenticationService} from "../_service/_auth/auth.service";
import {first} from "rxjs";

@Component({
  selector: 'app-login-panel',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm : FormGroup;
  loading: boolean;
  submitted: boolean;
  error: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.loading = false;
    this.submitted = false;
    this.error = '';
    if(this.authenticationService.userValue) {
      this.router.navigate(['/']);
    }

    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  get formData() {
    return this.loginForm.value
  }

  onSubmit(): void {
    this.submitted = true;
    if(this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.formData.username, this.formData.password)
      .pipe(first())
      .subscribe(
        () => {
          this.router.navigate(['/deliveries']);
        },
        (error: string) => {
          this.error = error;
          this.loading = false;
        });
  }
}