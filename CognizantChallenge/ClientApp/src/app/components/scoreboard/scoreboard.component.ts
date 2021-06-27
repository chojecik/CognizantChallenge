import { Component, OnInit } from '@angular/core';
import { ResultsService } from '../../services/results.service';
import { Result } from '../../models/result';
import { flash } from 'ng-animate';
import { trigger, transition, useAnimation } from '@angular/animations';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css'],
  animations: [
    trigger('flash', [transition('* => *', useAnimation(flash))])
  ]
})
export class ScoreboardComponent implements OnInit {
  results: Result[] = [];
  tempInfo: string = "Loading...";

  constructor(private resultsService: ResultsService) { }

  ngOnInit() {
    this.resultsService.getScoreboard()
      .subscribe(
        response => {
          if (response.length === 0) {
            this.tempInfo = "No data"
          }
          this.results = response;
        },
        error => {
        }

      )
  }

}
