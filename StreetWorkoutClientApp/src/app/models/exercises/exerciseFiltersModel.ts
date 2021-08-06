export interface IExercisesFilterModel {
  searchTerm: string;
  myExercises: boolean;
  muscleGroups: string[];
  exerciseLevel: string;
  resultsPerPage: number;
  pageNumber: number;
}
