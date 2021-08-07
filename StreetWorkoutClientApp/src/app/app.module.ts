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
import { AuthService } from './services/auth.service';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { CreateExerciseComponent } from './exercises/create-exercise/create-exercise.component';
import { ExerciseDetailsComponent } from './exercises/exercise-details/exercise-details.component';
import { PageNotFoundComponent } from './handlers/page-not-found/page-not-found.component';
import { ExercisesService } from './services/exercises.service';
import { CreateEquipmentComponent } from './equipment/create-equipment/create-equipment.component';
import { EquipmentService } from './services/equipment.service';
import { TokenInterceptorService } from './services/interceptors/token-interceptor.service';
import { AllExercisesComponent } from './exercises/all-exercises/all-exercises.component';
import { CreateTrainingComponent } from './trainings/create-training/create-training.component';

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
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
