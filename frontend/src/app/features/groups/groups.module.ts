import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupFormComponent } from './group-form/group-form.component';

const routes: Routes = [
  { path: '', component: GroupListComponent }
];

@NgModule({
  declarations: [
    GroupListComponent,
    GroupFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    InputTextareaModule
  ]
})
export class GroupsModule { }
