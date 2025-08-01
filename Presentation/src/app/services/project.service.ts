import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from "@angular/core";
import { Project } from '../models/project/project.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class ProjectService {

  constructor(
    private http: HttpClient,
    @Inject('API_URL') private apiUrl: string) {

  }

  getProjectsByStatus(statusId: number): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl + '/Project/GetProjectsByStatus',{
      params: {
        statusId: statusId,
      },
    });
  }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl + '/Project/GetProjects');
  }

}
