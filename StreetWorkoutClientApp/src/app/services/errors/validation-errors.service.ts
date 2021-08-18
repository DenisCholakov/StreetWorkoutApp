import { Injectable } from '@angular/core';
import { ValidationErrors } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ValidationErrorsService {
  constructor() {}
  getLoginValidationError(errors: ValidationErrors | null): string {
    return '';
  }

  getExerciseValidationError() {}

  getTrainingValidationError() {}
}
