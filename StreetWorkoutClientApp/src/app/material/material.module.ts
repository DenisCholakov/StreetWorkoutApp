import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input'

@NgModule({
  declarations: [],
  imports: [MatFormFieldModule, MatCardModule, MatButtonModule, MatInputModule],
  exports: [MatFormFieldModule, MatCardModule, MatButtonModule, MatInputModule],
})
export class MaterialModule {}
