import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent, RegisterComponent } from './authentication';
import { CreateEquipmentComponent } from './equipment/create-equipment/create-equipment.component';
import { AllExercisesComponent } from './exercises/all-exercises/all-exercises.component';
import { CreateExerciseComponent } from './exercises/create-exercise/create-exercise.component';
import { ExerciseDetailsComponent } from './exercises/exercise-details/exercise-details.component';
import { PageNotFoundComponent } from './handlers/page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './services';
import { CreateTrainingComponent } from './trainings/create-training/create-training.component';

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
    canActivate: [AuthGuardService],
  },
  {
    path: 'exercise',
    children: [
      {
        path: 'create',
        component: CreateExerciseComponent,
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
