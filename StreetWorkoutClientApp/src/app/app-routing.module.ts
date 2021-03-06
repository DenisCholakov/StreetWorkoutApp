import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent, RegisterComponent } from './authentication';
import { CreateEquipmentComponent } from './equipment/create-equipment/create-equipment.component';
import { AllExercisesComponent } from './exercises/all-exercises/all-exercises.component';
import { CreateExerciseComponent } from './exercises/create-exercise/create-exercise.component';
import { EditExerciseComponent } from './exercises/edit-exercise/edit-exercise.component';
import { ExerciseDetailsComponent } from './exercises/exercise-details/exercise-details.component';
import { PageNotFoundComponent } from './handlers/page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './services';
import { TrainerGuardService } from './services/authentication/trainer-guard.service';
import { AllTrainingsComponent } from './trainings/all-trainings/all-trainings.component';
import { CreateTrainingComponent } from './trainings/create-training/create-training.component';
import { TrainingDetailsComponent } from './trainings/training-details/training-details.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home',
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'equipment-create',
    component: CreateEquipmentComponent,
    canActivate: [AuthGuardService, TrainerGuardService],
  },
  {
    path: 'exercise',
    children: [
      {
        path: 'create',
        component: CreateExerciseComponent,
        canActivate: [TrainerGuardService],
      },
      {
        path: 'edit/:id',
        component: EditExerciseComponent,
      },
      {
        path: 'details/:id',
        component: ExerciseDetailsComponent,
      },
      {
        path: 'all',
        component: AllExercisesComponent,
      },
    ],
    canActivate: [AuthGuardService],
  },
  {
    path: 'training',
    children: [
      {
        path: 'create',
        component: CreateTrainingComponent,
        canActivate: [TrainerGuardService],
      },
      {
        path: 'details/:id',
        component: TrainingDetailsComponent,
      },
      {
        path: 'all',
        component: AllTrainingsComponent,
      },
    ],
    canActivate: [AuthGuardService],
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
