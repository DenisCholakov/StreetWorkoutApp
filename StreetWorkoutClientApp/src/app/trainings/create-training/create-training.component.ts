import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-training',
  templateUrl: './create-training.component.html',
  styleUrls: ['./create-training.component.scss'],
})
export class CreateTrainingComponent implements OnInit {
  trainingForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.trainingForm = this.fb.group({
      name: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  create() {}

  getError(fieldName: string) {}
}
