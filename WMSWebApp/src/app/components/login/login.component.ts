import { Component, OnInit } from '@angular/core';
import {UntypedFormGroup, UntypedFormControl} from '@angular/forms';
import { Validators } from '@angular/forms';
import {ActivatedRoute, Router} from "@angular/router";
import { filter } from 'rxjs';
import {AuthenticationService} from "../../auth/auth.service";
import {AuthenticateUser, User} from "../../models/user.model";
import {BaseComponent} from "../../common/components/base.component";

@Component({
  selector: 'app-login-panel',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent {
  loginForm : UntypedFormGroup;
  submitted: boolean;
  error: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    super();
    this.submitted = false;
    this.error = '';
    console.log(`Test user`,this.authenticationService.currentUser);
    // if(this.authenticationService.currentUser) {
    this.router.navigate(['/home']);
    // }

    this.loginForm = new UntypedFormGroup({
      username: new UntypedFormControl('', Validators.required),
      password: new UntypedFormControl('', Validators.required),
    });
  }

  get formData() {
    return this.loginForm.value
  }

  onSubmit(): void {
    console.log(`onSubmit`);
    this.submitted = true;
    if(this.loginForm.invalid) {
      return;
    }

    this.subscribe(
      this.authenticationService.login(this.formData), {
        next: () => {
        this.router.navigate(['/home']);
        },
        error: (error) => {
        console.error(error);
        this.error = `Nieprawdiłowy login lub hasło.`;
        }
    });
  }
}

