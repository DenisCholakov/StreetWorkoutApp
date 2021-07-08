import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import * as validationConstants from '../../constants/validation.constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  validations = validationConstants;

  loginForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  login() {
    console.log(this.loginForm);
  }

  getError(propertyName: string): string {
    let errors = this.loginForm.get(propertyName)?.errors;

    if (errors?.required) {
      return this.validations.REQUIRED;
    }

    return '';
  }
}
