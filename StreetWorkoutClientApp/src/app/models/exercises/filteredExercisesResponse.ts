import { IExerciseCardModel } from './exerciseCardModel';

export interface IFilteredExercisesResponse {
  exercises: IExerciseCardModel[];
  allExercisesCount: number;
}
