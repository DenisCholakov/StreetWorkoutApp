import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { MuscleGroupsEnum, ExerciseLevelEnum } from 'src/app/models';
import { EquipmentService } from 'src/app/services/equipment.service';
import { ExercisesService } from 'src/app/services/exercises.service';

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
    private equipmentService: EquipmentService,
    private exerciseService: ExercisesService
  ) {
    this.exerciseForm = this.fb.group({
      name: ['', [Validators.required]],
      description: [
        '',
        [
          Validators.required,
          Validators.maxLength(600),
          Validators.minLength(50),
        ],
      ],
      //add validation for enum
      exerciseLevel: ['', [Validators.required]],
      imageUrl: ['', []],
      exampleUrl: ['', []],
      //add validation for enum
      muscleGroups: ['', []],
      equipment: ['', []],
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

  getError(field: string) {}

  create() {
    this.subscriptions.push(
      this.exerciseService.create(this.exerciseForm.value).subscribe()
    );
  }
}
