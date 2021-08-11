import { Component, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-add-training-exercise',
  templateUrl: './add-training-exercise.component.html',
  styleUrls: ['./add-training-exercise.component.scss'],
})
export class AddTrainingExerciseComponent implements OnInit {
  @Input() allExercises: string[] = [];

  filteredExercises!: Observable<string[]>;

  exerciseForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.exerciseForm = this.fb.group({
      exerciseName: ['', [Validators.required]],
      reps: [0, Validators.required],
    });
  }

  ngOnInit(): void {
    const exerciseFormControl = <FormControl>(
      this.exerciseForm.get('exerciseName')
    );

    this.filteredExercises = exerciseFormControl.valueChanges.pipe(
      startWith(''),
      map((value) => this.filter(value))
    );
  }

  private filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.allExercises.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }
}
