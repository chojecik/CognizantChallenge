import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root'
})
export class ResultsService {
  apiUrl = "api/results"
  constructor(private http: HttpClient) { }

  getScoreboard(): Observable<Result[]> {
    let url = this.apiUrl + "/results";
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.get<Result[]>(url, httpOptions)
      .pipe();
  }
}
