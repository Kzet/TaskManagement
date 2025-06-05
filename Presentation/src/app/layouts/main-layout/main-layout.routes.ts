import { Routes } from '@angular/router';
import { MainLayoutComponent } from './main-layout.component';
import { KanbanComponent } from '../../pages/kanban/kanban.component';
import { CalendarComponent } from '../../pages/calendar/calendar.component';
import { ProjectsComponent } from '../../pages/projects/projects.component';

export const MAIN_ROUTES: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'main',
        pathMatch: 'full',
      },
      {
        path: 'main',
        component: KanbanComponent
      },
      {
        path: 'projects',
        component: ProjectsComponent
      },
      {
        path: 'calendar',
        component: CalendarComponent
      },
    ],
  },
];
