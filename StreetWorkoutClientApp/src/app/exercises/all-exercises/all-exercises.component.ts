import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';

import {
  MuscleGroupsEnum,
  ExerciseLevelEnum,
  IFilteredExercisesResponse,
} from 'src/app/models';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-all-exercises',
  templateUrl: './all-exercises.component.html',
  styleUrls: ['./all-exercises.component.scss'],
})
export class AllExercisesComponent implements OnInit, OnDestroy {
  muscleGroups = MuscleGroupsEnum;
  exerciseLevels = ExerciseLevelEnum;
  muscleGroupsKeys: string[] = [];
  exerciseLevelsKeys: any[] = [];
  exercisesResponse: IFilteredExercisesResponse = {
    exercises: [],
    allExercisesCount: 0,
  };
  pageSize = 6;
  currentPage = 0;

  exerciseSearchForm: FormGroup;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private exercisesService: ExercisesService
  ) {
    this.exerciseSearchForm = this.fb.group({
      searchTerm: [''],
      myExercises: [false],
      muscleGroups: [[]],
      exerciseLevel: [0],
    });
  }

  ngOnInit(): void {
    this.muscleGroupsKeys = Object.keys(this.muscleGroups);
    this.exerciseLevelsKeys = Object.keys(this.exerciseLevels).filter(Number);
    this.getCurrentExercises();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe());
  }

  changePageOptions(event: PageEvent): void {
    if (
      event.pageIndex !== this.currentPage ||
      event.pageSize !== this.pageSize
    ) {
      this.pageSize = event.pageSize;
      this.currentPage = event.pageIndex;

      this.getCurrentExercises();
    }
  }

  private getCurrentExercises() {
    this.subscriptions.push(
      this.exercisesService
        .getExercises(
          this.exerciseSearchForm.value,
          `${this.pageSize}`,
          `${this.currentPage}`
        )
        .subscribe((result) => {
          this.exercisesResponse = result;
          console.log(result);
        })
    );
  }
}
