import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component'
import { FormComponent } from './form/form.component'
import { ResetComponent } from './reset/reset.component'


const routes: Routes = [
  {path:'', component:HomeComponent },
  {path:'form', component:FormComponent },
  {path:'reset', component:ResetComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }