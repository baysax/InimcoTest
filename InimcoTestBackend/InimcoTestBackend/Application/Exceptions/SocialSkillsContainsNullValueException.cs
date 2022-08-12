namespace InimcoTestBackend.Application.Exceptions;

public class SocialSkillsContainsNullValueException: AApplicationException
{
    public SocialSkillsContainsNullValueException(): base(ResponseCode.SocialSkillsContainsNullValue){}
}