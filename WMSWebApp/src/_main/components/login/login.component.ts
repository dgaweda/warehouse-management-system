import { Component } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { Validators } from '@angular/forms';
import {ActivatedRoute, Router} from "@angular/router";
import {AuthenticationService} from "../../_auth/auth.service";

@Component({
  selector: 'app-login-panel',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent{
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
    if(this.authenticationService.currentUser) {
      this.router.navigate(['/delivery']);
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
      .subscribe(
        () => {
          this.router.navigate(['/order']);
          this.loading = false;
        },
        () => {
          this.error = `Nieprawdiłowy login lub hasło.`;
          this.loading = false;
        });
  }
}
