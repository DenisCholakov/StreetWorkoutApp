import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent, RegisterComponent } from './authentication';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import {
  AuthService,
  ExercisesService,
  EquipmentService,
  TokenInterceptorService,
} from './services';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { CreateExerciseComponent } from './exercises/create-exercise/create-exercise.component';
import { ExerciseDetailsComponent } from './exercises/exercise-details/exercise-details.component';
import { PageNotFoundComponent } from './handlers/page-not-found/page-not-found.component';
import { CreateEquipmentComponent } from './equipment/create-equipment/create-equipment.component';
import { AllExercisesComponent } from './exercises/all-exercises/all-exercises.component';
import { CreateTrainingComponent } from './trainings/create-training/create-training.component';
import { AddTrainingExerciseComponent } from './shared/components/add-training-exercise/add-training-exercise.component';
import { TrainingDetailsComponent } from './trainings/training-details/training-details.component';
import { AllTrainingsComponent } from './trainings/all-trainings/all-trainings.component';
import { CommonService } from './services/common/common.service';
import { EditExerciseComponent } from './exercises/edit-exercise/edit-exercise.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    HomeComponent,
    CreateExerciseComponent,
    ExerciseDetailsComponent,
    PageNotFoundComponent,
    CreateEquipmentComponent,
    AllExercisesComponent,
    CreateTrainingComponent,
    AddTrainingExerciseComponent,
    TrainingDetailsComponent,
    AllTrainingsComponent,
    EditExerciseComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    HttpClientModule,
  ],
  providers: [
    AuthService,
    ExercisesService,
    EquipmentService,
    CommonService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
