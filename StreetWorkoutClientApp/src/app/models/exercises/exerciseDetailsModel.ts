import { ExerciseLevelEnum } from '../enums/exerciseLevelEnum';
import { IEquipment } from '../equipment';

export interface IExerciseDetailsModel {
  name: string;
  description: string;
  examleUrl: string;
  imageUrl: string;
  exerciseLevel: ExerciseLevelEnum;
  trainingsForAcheiving: string[];
  trainingsIncludedIn: string[];
  muscleGroups: string[];
  equipment: IEquipment[];
}
