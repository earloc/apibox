import * as generated from './WebApiClient'
import { Injectable } from '@angular/core';

@Injectable()
export class WebApiClientService {

  private client: generated.WebApiClient;

  constructor() {
    this.client = new generated.WebApiClient("https://localhost:5001");
  }

  public async SayHello(name: string): Promise<generated.GreetingResponse> {
    return await this.client.greeting(name);
  }
}
