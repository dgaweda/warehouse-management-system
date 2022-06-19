import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { Validators } from '@angular/forms';
import {ActivatedRoute, Router} from "@angular/router";
import { filter } from 'rxjs';
import {AuthenticationService} from "../../auth/auth.service";
import {AuthenticateUser, User} from "../../models/user.model";
import {BaseComponent} from "../base.component";

@Component({
  selector: 'app-login-panel',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent {
  loginForm : FormGroup;
  loading: boolean;
  submitted: boolean;
  error: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    super();
    this.loading = false;
    this.submitted = false;
    this.error = '';
    if(this.authenticationService.currentUser) {
      this.router.navigate(['/home']);
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
    this.addSubscription(
      this.authenticationService.login(this.formData)
      .subscribe(
        () => {
          this.router.navigate(['/home']);
          this.loading = false;
        },
        error => {
          console.error(error);
          this.error = `Nieprawdiłowy login lub hasło.`;
          this.loading = false;
        })
    );
  }
}
