import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule, MatCheckboxModule, MatMenuModule, MatCardModule, MatSelectModule} from '@angular/material';

@NgModule({
  imports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatCardModule, MatSelectModule],
  exports: [MatButtonModule, MatCheckboxModule, MatMenuModule, MatCardModule, MatSelectModule],
})

export class NewsMaterialModule { }
