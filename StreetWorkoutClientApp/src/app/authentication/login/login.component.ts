import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService, ValidationErrorsService } from 'src/app/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private validationErrorService: ValidationErrorsService
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginForm.value).subscribe((data) => {
      this.authService.saveToken(data['token']);
    });
    this.router.navigate(['home']);
  }

  getError(errors: ValidationErrors | null): string {
    return this.validationErrorService.getLoginValidationError(errors);
  }
}
