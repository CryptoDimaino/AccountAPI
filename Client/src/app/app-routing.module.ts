import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from './content/content.component';
import { ErrorComponent } from './content/error/error.component';

import { WumboComponent } from './wumbo/wumbo.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: ContentComponent
  },
  {
    path: 'wumbo',
    component: WumboComponent
  },
  {
    path: '404',
    component: ErrorComponent
  },
  {
    path: '**',
    redirectTo: '/404',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
