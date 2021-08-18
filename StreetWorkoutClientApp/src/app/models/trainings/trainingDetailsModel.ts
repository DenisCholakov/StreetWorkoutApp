import { ITrainingExerciseDetailsModel } from './trainingExerciseDetailsModel';

export interface ITrainingDetailsModel {
  name: string;
  description: string;
  isIndoor: boolean;
  goalexercise: string;
  cyclesCount: number;
  breakBetweenExercises: string;
  breakBetweenCycles: string;
  trainingLevel: number;
  muscleGroups: string[];
  exercises: ITrainingExerciseDetailsModel[];
}
