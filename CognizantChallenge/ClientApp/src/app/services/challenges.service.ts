import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../models/result';
import { Challenge } from '../models/challenge';

@Injectable({
  providedIn: 'root'
})
export class ChallengesService {
  apiUrl: string = "api/challenges";

  constructor(private http: HttpClient) { }

  submitChallenge(challenge: Challenge): Observable<any> {

    return this.http.post<Challenge>(this.apiUrl, challenge).pipe();
  }
}
