import { ITrainingCardModel } from './trainingCardModel';

export interface IFilteredTrainingsResponse {
  trainings: ITrainingCardModel[];
  allTrainingsCount: number;
}
