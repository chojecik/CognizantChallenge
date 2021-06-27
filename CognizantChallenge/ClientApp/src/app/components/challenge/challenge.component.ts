import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Challenge } from '../../models/challenge';
import { TasksService } from '../../services/tasks.service';
import { ChallengesService } from '../../services/challenges.service';
import { Task } from '../../models/task';
import { Language } from '../../enums/language.enum';
import { Template } from '../../models/template';

@Component({
  selector: 'app-challenge',
  templateUrl: './challenge.component.html',
  styleUrls: ['./challenge.component.css']
})
export class ChallengeComponent extends Template implements OnInit {
  @ViewChild('codeArea', { static: false }) codeArea;
  challengeForm: FormGroup;
  challenge: Challenge;
  tasks: Task[]
  description: string;
  taskId: number;
  language: number;
  keys = Object.keys;
  languages = Language;
  solutionTemplate: string;

  constructor(
    private formBuilder: FormBuilder,
    private tasksService: TasksService,
    private challengesService: ChallengesService) {
      super();
  }

  ngOnInit() {
    this.getTasks();
    this.challengeForm = this.formBuilder.group({
      username: ['', Validators.required],
      taskId: [Validators.required],
      solution: ['', Validators.required],
      language: ['', Validators.required]
    });
  }

  submitChallenge() {
    this.challengeForm.patchValue({ taskId: this.taskId });
    this.challengeForm.patchValue({ language: this.language });
    this.challengesService.submitChallenge(this.challengeForm.value)
      .subscribe(
        response => {
          if (response) {
            this.codeArea.nativeElement.style.background = '#ccffcc'
          }
          else {
            this.codeArea.nativeElement.style.background = '#ff8080'
          }
        },
        error => {
        });
  }

  getTasks() {
    this.tasksService
      .getTasks()
      .subscribe(
        response => {
          this.tasks = response;
        },
        error => {
        });
  }

  taskChanged(id: string) {
    this.taskId = Number(id);
    this.description = this.tasks.find(x => x.id === Number(id)).description;
    this.setSolutionTemplate();
  }

  languageChanged(selectedLanguage: string) {
    this.language = Number(selectedLanguage);
    this.setSolutionTemplate();
  }

  setSolutionTemplate() {
    let taskName = this.tasks.find(x => x.id === Number(this.taskId)).taskName;
    if (this.taskId != undefined && this.language != undefined && this.taskId != null && this.language != null) {
      if (this.language === Language.csharp) {
        switch (taskName) {
          case "Fibonacci sequence":
            this.solutionTemplate = this.fibonacciTemplateCsharp;
            break;
          case "Factorial":
            this.solutionTemplate = this.factorialTemplateCsharp;
            break;
          case "Prime numbers":
            this.solutionTemplate = this.primeNumbersTemplateCsharp;
            break;
          default:
            this.solutionTemplate = "";
            break;
        }
      }
      else if (this.language === Language.java) {

        switch (taskName) {
          case "Fibonacci sequence":
            this.solutionTemplate = this.fibonacciTemplateJava;
            break;
          case "Factorial":
            this.solutionTemplate = this.factorialTemplatJava;
            break;
          case "Prime numbers":
            this.solutionTemplate = this.primeNumbersTemplateJava;
            break;
          default:
            this.solutionTemplate = "";
            break;
        }
      }
    }
  }
}
