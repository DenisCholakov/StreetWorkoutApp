import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { ExerciseLevelEnum } from 'src/app/models/enums';
import { IExerciseDetailsModel } from 'src/app/models';
import { ExercisesService } from 'src/app/services';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss'],
})
export class ExerciseDetailsComponent implements OnInit, OnDestroy {
  exerciseDetails: IExerciseDetailsModel | undefined;
  exerciseLevels = ExerciseLevelEnum;

  subscriptions: Subscription[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private exercisesService: ExercisesService
  ) {}

  ngOnInit(): void {
    this.getExerciseDetails();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  private getExerciseDetails() {
    const exerciseId: string = this.route.snapshot.paramMap.get('id') ?? '';

    // check if needed
    if (exerciseId === '') {
      this.router.navigate(['exercise', 'all']);
    }
    this.subscriptions.push(
      this.exercisesService
        .getExerciseDetails(exerciseId)
        .subscribe((result) => {
          this.exerciseDetails = result;
          console.log(result);
        })
    );
  }
}
