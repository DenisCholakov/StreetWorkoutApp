import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ITrainingDetailsModel } from 'src/app/models';
import { TrainingLevelEnum } from 'src/app/models/enums';
import { TrainingsService } from 'src/app/services';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss'],
})
export class TrainingDetailsComponent implements OnInit, OnDestroy {
  trainingDetails!: ITrainingDetailsModel;
  trainingLevel = '';

  subscriptions: Subscription[] = [];

  constructor(
    private trainingsService: TrainingsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const trainingId = this.route.snapshot.paramMap.get('id') ?? '';

    this.subscriptions.push(
      this.trainingsService
        .getTrainingDetails(trainingId)
        .subscribe((result) => {
          this.trainingDetails = result;
          this.trainingLevel = TrainingLevelEnum[result.trainingLevel];
        })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((x) => x.unsubscribe);
  }
}
