import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserInformationRequest } from 'src/models/request.model';
import { SocialAccount } from 'src/models/social-account.model';
import { UserInformationResponse } from 'src/models/user-information-response.model';

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html',
  styleUrls: ['./request-form.component.css']
})
export class RequestFormComponent implements OnInit {
  firstName = '';
  lastName = '';
  socialSkills: string[] = [];
  socialAccounts: SocialAccount[] = [];
  hasResponse = false;
  hasError = false;
  userInformationResponse: UserInformationResponse | undefined;
  errorResponse: any; 
  socialAccountTypes: string[] = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get("http://localhost:5400/socialaccounttypes").subscribe((response) => {
      this.socialAccountTypes = <string[]>response;
    })
  }

  addSocialAccount(socialAccountType: HTMLSelectElement, socialAccountAddress: HTMLInputElement){
    let socialAccount = new SocialAccount(socialAccountType.value, socialAccountAddress.value);
    this.socialAccounts.push(socialAccount);
    socialAccountType.value = 'Twitter';
    socialAccountAddress.value = '';
  }

  addSocialSkill(socialSkill: HTMLInputElement){
    this.socialSkills.push(socialSkill.value);
    socialSkill.value = '';
  }

  sendRequest(){
    let request = new UserInformationRequest(this.firstName, this.lastName, this.socialSkills, this.socialAccounts);
    this.http.post("http://localhost:5400/userinformation", request).subscribe(
      (response) => {
        this.hasResponse = true;
        this.userInformationResponse = <UserInformationResponse> response; //UserInformationResponse.fromJSON(JSON.stringify(response));
      },
      (error) => {
        this.hasError = true;
        this.errorResponse = error;
      }
    )
    this.firstName = '';
    this.lastName = '';
    this.socialSkills = [];
    this.socialAccounts = [];
  }

}
