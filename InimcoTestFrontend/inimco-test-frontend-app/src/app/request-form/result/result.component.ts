import { Component, Input, OnInit } from '@angular/core';
import { UserInformationRequest } from 'src/models/request.model';
import { UserInformationResponse } from 'src/models/user-information-response.model';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  @Input() userInformationResponse: UserInformationResponse | undefined;
  @Input() errorResponse: any
  constructor() { }

  ngOnInit(): void {
  }

  getTextAreaContent(): string{
    if(this.userInformationResponse != undefined){
      return `
      The number of vowels: ${this.userInformationResponse.vowelsCount}
      The number of consonants: ${this.userInformationResponse.consonantsCount}
      The firstName + lastName entered: ${this.userInformationResponse.fullName}
      The reverse version of the firstname and lastname: ${this.userInformationResponse.reverseFullName}
      The JSON format of the entire object: ${JSON.stringify(this.userInformationResponse.request, null, '\t')}
      `;
    }
    return JSON.stringify(this.errorResponse, null, '\t');
  }
}
