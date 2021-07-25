import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-exercise',
  templateUrl: './create-exercise.component.html',
  styleUrls: ['./create-exercise.component.scss'],
})
export class CreateExerciseComponent implements OnInit {
  exerciseForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.exerciseForm = this.fb.group({
      name: ['', [Validators.required]],
      //add validation for enum
      execiseLevel: ['', [Validators.required]],
      imageUrl: ['', []],
      examleUrl: ['', []],
      //add validation for enum
      muscleGroups: ['', []],
      equipment: ['', []],
    });
  }

  ngOnInit(): void {}

  getError(field: string) {}

  create() {}
}
