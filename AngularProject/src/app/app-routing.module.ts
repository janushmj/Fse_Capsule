import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTaskComponent } from './add-task/add-task.component';
import { ViewTaskComponent } from './view-task/view-task.component';
import { UpdateTaskComponent } from './update-task/update-task.component';
import {AddUserComponent} from './add-user/add-user.component';
import {AddProjectComponent} from './add-project/add-project.component';

const routes: Routes = [
  { path: 'AddTask', component: AddTaskComponent },
  { path: 'ViewTask', component: ViewTaskComponent },
  { path: 'UpdateTask', component: UpdateTaskComponent },
  { path: 'AddUser', component:AddUserComponent },
  { path: 'AddProject', component:AddProjectComponent},
  { path: '**', component: ViewTaskComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
