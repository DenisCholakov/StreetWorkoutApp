import { ArrayType } from '@angular/compiler';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { TrainingLevelEnum, MuscleGroupsEnum } from 'src/app/models/enums';
import { ExercisesService, TrainingsService } from 'src/app/services';

@Component({
  selector: 'app-create-training',
  templateUrl: './create-training.component.html',
  styleUrls: ['./create-training.component.scss'],
})
export class CreateTrainingComponent implements OnInit, OnDestroy {
  exercisesFormArray: ArrayType[] = [];

  allExercises: string[] = [];
  filteredExercises!: Observable<string[]>;
  trainingLevels = TrainingLevelEnum;
  muscleGroups = MuscleGroupsEnum;
  // find a way to remove any
  trainingLevelKeys: any[] = [];
  muscleGroupKeys: any[] = [];

  trainingControls: ArrayType[] = [];
  trainingForm: FormGroup;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private exercisesService: ExercisesService,
    private trainingsService: TrainingsService
  ) {
    this.trainingForm = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(30),
        ],
      ],
      description: [
        '',
        [
          Validators.required,
          Validators.minLength(50),
          Validators.maxLength(1000),
        ],
      ],
      isIndoor: [false, [Validators.required]],
      goalexercise: [''],
      cyclesCount: [
        1,
        [Validators.required, Validators.max(10), Validators.min(1)],
      ],
      breakBetweenExercises: [
        '',
        [Validators.required, Validators.pattern('[0-3]:[0-5][0-9]')],
      ],
      breakBetweenCycles: [
        '',
        [Validators.required, Validators.pattern('[0-3]:[0-5][0-9]')],
      ],
      trainingLevel: [0, [Validators.required]],
      muscleGroups: [[]],
      exercises: this.fb.array([this.createExercise()]),
    });
  }

  get exercises(): FormArray {
    return <FormArray>this.trainingForm.get('exercises');
  }

  ngOnInit(): void {
    this.trainingLevelKeys = Object.keys(this.trainingLevels).filter(Number);
    this.muscleGroupKeys = Object.keys(this.muscleGroups);

    this.subscriptions.push(
      this.exercisesService
        .getAllExerciseNames()
        .subscribe((result) => (this.allExercises = result))
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  addExerciseInput(): void {
    const exercises = <FormArray>this.trainingForm.get('exercises');
    exercises.push(this.createExercise());
  }

  removeInput(index: number): void {
    const exercises = <FormArray>this.trainingForm.get('exercises');
    exercises.removeAt(index);
  }

  create() {
    this.trainingsService
      .create(this.trainingForm.value)
      .subscribe((id) =>
        this.router.navigate(['training', 'details', `${id}`])
      );
  }

  private createExercise(): FormGroup {
    return this.fb.group({
      exerciseName: ['', [Validators.required]],
      reps: [0, Validators.required],
    });
  }
}
