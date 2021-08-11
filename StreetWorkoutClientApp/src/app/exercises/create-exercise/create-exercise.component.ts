import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MuscleGroupsEnum, ExerciseLevelEnum } from 'src/app/models/enums';
import { EquipmentService, ExercisesService } from 'src/app/services';

@Component({
  selector: 'app-create-exercise',
  templateUrl: './create-exercise.component.html',
  styleUrls: ['./create-exercise.component.scss'],
})
export class CreateExerciseComponent implements OnInit, OnDestroy {
  muscleGroups = MuscleGroupsEnum;
  exerciseLevels = ExerciseLevelEnum;
  muscleGroupsKeys: string[] = [];
  exerciseLevelsKeys: any[] = [];
  neededEquipment: string[] = [];

  exerciseForm: FormGroup;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private equipmentService: EquipmentService,
    private exerciseService: ExercisesService
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
    this.muscleGroupsKeys = Object.keys(this.muscleGroups);
    this.exerciseLevelsKeys = Object.keys(this.exerciseLevels).filter(Number);
    this.subscriptions.push(
      this.equipmentService
        .getAllNames()
        .subscribe((x) => (this.neededEquipment = x))
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
