import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EquipmentService } from 'src/app/services/equipment.service';

@Component({
  selector: 'app-create-equipment',
  templateUrl: './create-equipment.component.html',
  styleUrls: ['./create-equipment.component.scss'],
})
export class CreateEquipmentComponent implements OnInit {
  equipmentForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private equipmentService: EquipmentService
  ) {
    this.equipmentForm = fb.group({
      name: ['', [Validators.required]],
      imageUrl: [
        '',
        [
          Validators.pattern(
            `(http)?s?:?(\/\/[^"']*\.(?:png|jpg|jpeg|gif|png|svg))`
          ),
        ],
      ],
    });
  }

  ngOnInit(): void {}

  create() {
    this.equipmentService
      .create(this.equipmentForm.value)
      .subscribe((x) => console.log(x));
  }
}
