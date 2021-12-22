import { Component } from '@angular/core';
import { WebApiClientService } from './services/WebApiClientService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularUI';

  constructor(private service: WebApiClientService) {

  }

  public async Greet(name: string): Promise<string> {
    let response = await this.service.SayHello(name);
    return response.message;
  }

}
