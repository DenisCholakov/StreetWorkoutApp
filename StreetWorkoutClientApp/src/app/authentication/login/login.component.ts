import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

import * as validationConstants from '../../constants/validation.constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  validations = validationConstants;

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginForm.value).subscribe((data) => {
      console.log(data);
    });
  }

  getError(propertyName: string): string {
    let errors = this.loginForm.get(propertyName)?.errors;

    if (errors?.required) {
      return this.validations.REQUIRED;
    }

    return '';
  }
}
