import { UserInformationRequest } from "./request.model";

export class UserInformationResponse {
    request:         UserInformationRequest;
    vowelsCount:     number;
    consonantsCount: number;
    fullName:        string;
    reverseFullName: string;

    constructor(request: UserInformationRequest, vowelsCount: number, consonantsCount: number, fullName: string, reverseFullName: string){
        this.request = request;
        this.vowelsCount = vowelsCount;
        this.consonantsCount = consonantsCount;
        this.fullName = fullName;
        this.reverseFullName = reverseFullName;
    }
}