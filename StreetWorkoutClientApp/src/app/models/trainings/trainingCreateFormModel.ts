import { ITrainingExerciseCreateFormModel } from '..';

export interface ITrainingCreateFormModel {
  name: string;
  description: string;
  isIndoor: boolean;
  goalexercise: string;
  cyclesCount: number;
  breakBetweenExercises: string;
  breakBetweenCycles: string;
  trainingLevel: number;
  muscleGroups: string[];
  exercises: ITrainingExerciseCreateFormModel[];
}
