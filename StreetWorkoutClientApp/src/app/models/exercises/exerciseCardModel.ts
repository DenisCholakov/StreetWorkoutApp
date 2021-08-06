import { ExerciseLevelEnum } from '../enums/exerciseLevelEnum';

export interface IExerciseCardModel {
  id: number;
  name: string;
  imageUrl: string;
  muscleGroups: string[];
  exerciseLevel: ExerciseLevelEnum;
}
