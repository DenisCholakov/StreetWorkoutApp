import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import * as validationConstants from '../../constants/validation.constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  validations = validationConstants;

  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  register() {
    this.authService.register(this.registerForm.value);
  }

  getError(propertyName: string): string {
    let errors = this.registerForm.get(propertyName)?.errors;

    if (errors?.required) {
      return this.validations.REQUIRED;
    }

    return '';
  }
}
