import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IExerciseDetailsModel } from 'src/app/models';
import { ExercisesService } from 'src/app/services/exercises.service';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss'],
})
export class ExerciseDetailsComponent implements OnInit, OnDestroy {
  exerciseDetails: IExerciseDetailsModel | undefined;

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
        .subscribe((result) => console.log(result))
    );
  }
}
