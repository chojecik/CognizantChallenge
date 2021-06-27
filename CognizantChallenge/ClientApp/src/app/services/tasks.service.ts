import { Injectable } from '@angular/core';
import { Task } from '../models/task';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  apiUrl = "api/tasks";

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]> {
    let url = this.apiUrl + "/tasks";

    return this.http.get<Task[]>(url);
   }
 }

