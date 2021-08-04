import { ExerciseLevelEnum } from '../enums/exerciseLevelEnum';

export interface IExerciseDetailsModel {
  name: string;
  examleUrl: string;
  imageUrl: string;
  exerciseLevel: ExerciseLevelEnum;
  trainingsForAcheiving: string[];
  trainingsIncludedIn: string[];
  muscleGroups: string[];
  equipmentNeeded: string[];
}
