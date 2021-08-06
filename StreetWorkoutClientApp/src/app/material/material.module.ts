import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [],
  imports: [
    MatFormFieldModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatToolbarModule,
    MatIconModule,
    MatSelectModule,
    MatMenuModule,
    MatCheckboxModule,
    MatPaginatorModule,
  ],
  exports: [
    MatFormFieldModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatToolbarModule,
    MatIconModule,
    MatSelectModule,
    MatMenuModule,
    MatCheckboxModule,
    MatPaginatorModule,
  ],
})
export class MaterialModule {}
