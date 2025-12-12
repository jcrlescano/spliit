import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/groups', pathMatch: 'full' },
  {
    path: 'groups',
    loadChildren: () => import('./features/groups/groups.module').then(m => m.GroupsModule)
  },
  {
    path: 'expenses',
    loadChildren: () => import('./features/expenses/expenses.module').then(m => m.ExpensesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
