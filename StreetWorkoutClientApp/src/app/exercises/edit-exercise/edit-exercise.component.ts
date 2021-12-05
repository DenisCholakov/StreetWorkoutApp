import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { IExerciseDetailsModel } from 'src/app/models';
import { ExerciseLevelEnum } from 'src/app/models/enums';
import {
  CommonService,
  EquipmentService,
  ExercisesService,
} from 'src/app/services';

@Component({
  selector: 'app-edit-exercise',
  templateUrl: './edit-exercise.component.html',
  styleUrls: ['./edit-exercise.component.scss'],
})
export class EditExerciseComponent implements OnInit, OnDestroy {
  exerciseId: string = '';
  muscleGroups: string[] = [];
  exerciseLevels = ExerciseLevelEnum;
  exerciseLevelsKeys: any[] = [];
  neededEquipment: string[] = [];

  exerciseForm: FormGroup | undefined;
  subscriptions: Subscription[] = [];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private exercisesService: ExercisesService,
    private equipmentService: EquipmentService,
    private commonService: CommonService
  ) {}

  ngOnInit(): void {
    this.exerciseId = this.route.snapshot.paramMap.get('id') ?? '';
    this.exerciseLevelsKeys = Object.keys(this.exerciseLevels).filter(Number);

    this.subscriptions.push(
      this.exercisesService
        .getExerciseDetails(this.exerciseId)
        .subscribe((result) => this.populateForm(result))
    );

    this.subscriptions.push(
      this.commonService
        .getMuscleGroups()
        .subscribe((result) => (this.muscleGroups = result))
    );

    this.subscriptions.push(
      this.equipmentService
        .getAllNames()
        .subscribe((result) => (this.neededEquipment = result))
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }

  populateForm(exercise: IExerciseDetailsModel) {
    this.exerciseForm = this.fb.group({
      name: [
        exercise.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
        ],
      ],
      description: [
        exercise.description,
        [
          Validators.required,
          Validators.minLength(50),
          Validators.maxLength(600),
        ],
      ],
      // how to get the default value with enum
      exerciseLevel: [exercise.exerciseLevel, [Validators.required]],
      imageUrl: [
        exercise.imageUrl,
        [
          Validators.required,
          Validators.pattern(
            `(http)?s?:?(\/\/[^"']*\.(?:png|jpg|jpeg|gif|png|svg))`
          ),
        ],
      ],
      exampleUrl: [exercise.examleUrl, []],
      muscleGroups: [exercise.muscleGroups, []],
      equipment: [exercise.equipment, []],
    });
  }

  edit() {
    this.exercisesService
      .edit(this.exerciseForm?.value, this.exerciseId)
      .subscribe((exerciseId) =>
        this.router.navigate(['exercise', 'details', `${exerciseId}`])
      );
  }
}
