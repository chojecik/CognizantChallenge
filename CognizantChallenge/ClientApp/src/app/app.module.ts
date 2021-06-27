import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ScoreboardComponent } from './components/scoreboard/scoreboard.component';
import { ListToStringPipe } from './pipes/list-to-string.pipe';
import { ChallengeComponent } from './components/challenge/challenge.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutosizeModule } from 'ngx-autosize';
import { EnumKeyValueListPipe } from './pipes/enum-key-value-list.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ScoreboardComponent,
    ListToStringPipe,
    ChallengeComponent,
    EnumKeyValueListPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AutosizeModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'scoreboard', pathMatch: 'full' },
      { path: 'scoreboard', component: ScoreboardComponent },
      { path: 'solve', component: ChallengeComponent },
      { path: '**', redirectTo: 'scoreboard' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
