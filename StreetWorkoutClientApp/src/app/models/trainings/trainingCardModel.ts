export interface ITrainingCardModel {
  id: number;
  name: string;
  trainingLevel: number;
  goalExerciseName: string;
  isIndoor: boolean;
  muscleGroups: string[];
  includedExerciseNames: string[];
}
