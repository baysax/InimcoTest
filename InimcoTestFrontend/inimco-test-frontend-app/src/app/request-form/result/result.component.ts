import { Component, Input, OnInit } from '@angular/core';
import { UserInformationRequest } from 'src/models/request.model';
import { UserInformationResponse } from 'src/models/user-information-response.model';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  @Input() userInformationResponse: UserInformationResponse = new UserInformationResponse(new UserInformationRequest('', '', [], []), 0, 0, '', '');
  constructor() { }

  ngOnInit(): void {
  }

  getJsonStringOfRequest(): string{
    let res = JSON.stringify(this.userInformationResponse.request, null, '\t');
    console.log(res);
    return res;
  }

}
