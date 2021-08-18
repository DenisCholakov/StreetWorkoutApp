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
  equipment: string[] = [];
  exerciseLevels = ExerciseLevelEnum;
  exerciseId: string = '';

  subscriptions: Subscription[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private exercisesService: ExercisesService
  ) {}

  ngOnInit(): void {
    this.exerciseId = this.route.snapshot.paramMap.get('id') ?? '';

    this.getExerciseDetails();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  deleteExercise() {
    debugger;
    if (this.exerciseId === '') {
      this.router.navigate(['exercise', 'all']);
    }

    this.subscriptions.push(
      this.exercisesService
        .delete(this.exerciseId)
        .subscribe((result) => console.log(result))
    );

    this.router.navigate(['exercise', 'all']);
  }

  private getExerciseDetails() {
    // check if needed
    if (this.exerciseId === '') {
      this.router.navigate(['exercise', 'all']);
    }
    this.subscriptions.push(
      this.exercisesService
        .getExerciseDetails(this.exerciseId)
        .subscribe((result) => {
          this.exerciseDetails = result;
          this.equipment = result.equipment.map((x) => x.name);
        })
    );
  }
}
