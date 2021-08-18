import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';

import { IFilteredTrainingsResponse } from 'src/app/models';
import { TrainingLevelEnum } from 'src/app/models/enums';
import { ExercisesService, TrainingsService } from 'src/app/services';
import { CommonService } from 'src/app/services/common/common.service';

@Component({
  selector: 'app-all-trainings',
  templateUrl: './all-trainings.component.html',
  styleUrls: ['./all-trainings.component.scss'],
})
export class AllTrainingsComponent implements OnInit, OnDestroy {
  muscleGroups: string[] = [];
  trainingLevels = TrainingLevelEnum;
  trainingLevelsKeys: any[] = [];
  allExercises: string[] = [];

  trainingSearchForm: FormGroup;
  pageSize = 6;
  currentPage = 0;

  trainingsRepsone: IFilteredTrainingsResponse | undefined;

  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private exercisesService: ExercisesService,
    private trainingsService: TrainingsService,
    private commonService: CommonService
  ) {
    this.trainingSearchForm = this.fb.group({
      searchTerm: [''],
      isIndoor: [null],
      goalExerciseName: [''],
      myTrainings: [false],
      muscleGroups: [[]],
      trainingLevel: [null],
    });
  }

  ngOnInit(): void {
    this.trainingLevelsKeys = Object.keys(this.trainingLevels).filter(Number);

    this.subscriptions.push(
      this.exercisesService
        .getAllExerciseNames()
        .subscribe((result) => (this.allExercises = result))
    );

    this.subscriptions.push(
      this.commonService
        .getMuscleGroups()
        .subscribe((result) => (this.muscleGroups = result))
    );

    this.GetTrainings();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  changePageOptions(event: PageEvent): void {
    if (
      event.pageIndex !== this.currentPage ||
      event.pageSize !== this.pageSize
    ) {
      this.pageSize = event.pageSize;
      this.currentPage = event.pageIndex;

      this.GetTrainings();
    }
  }

  filterExrcises() {}

  private GetTrainings() {
    this.subscriptions.push(
      this.trainingsService
        .getFilteredTrainings(
          this.trainingSearchForm.value,
          `${this.currentPage}`,
          `${this.pageSize}`
        )
        .subscribe((result) => (this.trainingsRepsone = result))
    );
  }
}
