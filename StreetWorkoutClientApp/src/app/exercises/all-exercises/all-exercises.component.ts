import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';

import {
  MuscleGroupsEnum,
  ExerciseLevelEnum,
  IExerciseCardModel,
} from 'src/app/models';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-all-exercises',
  templateUrl: './all-exercises.component.html',
  styleUrls: ['./all-exercises.component.scss'],
})
export class AllExercisesComponent implements OnInit {
  muscleGroups = MuscleGroupsEnum;
  exerciseLevels = ExerciseLevelEnum;
  muscleGroupsKeys: string[] = [];
  exerciseLevelsKeys: any[] = [];
  exercises: IExerciseCardModel[] = [];

  exerciseSearchForm: FormGroup;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private exercisesService: ExercisesService
  ) {
    this.exerciseSearchForm = this.fb.group({
      searchTerm: [''],
      myExercises: [''],
      muscleGroups: [''],
      exerciseLevel: [''],
    });
  }

  ngOnInit(): void {
    this.muscleGroupsKeys = Object.keys(this.muscleGroups);
    this.exerciseLevelsKeys = Object.keys(this.exerciseLevels).filter(Number);

    this.subscriptions.push(
      this.exercisesService
        .getExercises(this.exerciseSearchForm.value)
        .subscribe((x) => (this.exercises = x))
    );
  }
}
