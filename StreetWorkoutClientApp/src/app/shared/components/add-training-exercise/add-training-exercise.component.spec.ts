import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTrainingExerciseComponent } from './add-training-exercise.component';

describe('AddTrainingExerciseComponent', () => {
  let component: AddTrainingExerciseComponent;
  let fixture: ComponentFixture<AddTrainingExerciseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTrainingExerciseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTrainingExerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
