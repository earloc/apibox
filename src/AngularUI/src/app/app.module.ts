import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { generate } from 'rxjs';

import { AppComponent } from './app.component';
import { WebApiClientService } from './services/WebApiClientService';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [WebApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
