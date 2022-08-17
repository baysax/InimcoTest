import { SocialAccount } from "./social-account.model";

export class UserInformationRequest {
    firstName:      string;
    lastName:       string;
    socialSkills:   string[];
    socialAccounts: SocialAccount[];

    constructor(firstName: string, lastName: string, socialSkills: string[], socialAccounts: SocialAccount[]) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.socialSkills = socialSkills;
        this.socialAccounts = socialAccounts;
    }
}