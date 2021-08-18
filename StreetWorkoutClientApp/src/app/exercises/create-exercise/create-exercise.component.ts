import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ExerciseLevelEnum } from 'src/app/models/enums';
import {
  EquipmentService,
  ExercisesService,
  CommonService,
} from 'src/app/services';

@Component({
  selector: 'app-create-exercise',
  templateUrl: './create-exercise.component.html',
  styleUrls: ['./create-exercise.component.scss'],
})
export class CreateExerciseComponent implements OnInit, OnDestroy {
  muscleGroups: string[] = [];
  exerciseLevels = ExerciseLevelEnum;
  exerciseLevelsKeys: any[] = [];
  neededEquipment: string[] = [];

  exerciseForm: FormGroup;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private equipmentService: EquipmentService,
    private exerciseService: ExercisesService,
    private commonService: CommonService
  ) {
    this.exerciseForm = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
        ],
      ],
      description: [
        '',
        [
          Validators.required,
          Validators.minLength(50),
          Validators.maxLength(600),
        ],
      ],
      exerciseLevel: ['', [Validators.required]],
      imageUrl: [
        '',
        [
          Validators.required,
          Validators.pattern(
            `(http)?s?:?(\/\/[^"']*\.(?:png|jpg|jpeg|gif|png|svg))`
          ),
        ],
      ],
      exampleUrl: ['', []],
      muscleGroups: ['', []],
      equipment: [[], []],
    });
  }
  ngOnInit(): void {
    this.exerciseLevelsKeys = Object.keys(this.exerciseLevels).filter(Number);
    this.subscriptions.push(
      this.equipmentService
        .getAllNames()
        .subscribe((x) => (this.neededEquipment = x))
    );

    this.subscriptions.push(
      this.commonService
        .getMuscleGroups()
        .subscribe((result) => (this.muscleGroups = result))
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  logErrors() {
    console.log(this.exerciseForm.controls.name.errors);
  }

  create() {
    this.subscriptions.push(
      this.exerciseService
        .create(this.exerciseForm.value)
        .subscribe((exerciseId) =>
          this.router.navigate(['exercise', 'details', `${exerciseId}`])
        )
    );
  }
}
