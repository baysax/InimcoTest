namespace InimcoTestBackend.Application.Exceptions;

public class SocialSkillsNullException: AApplicationException
{
    public SocialSkillsNullException(): base(ResponseCode.SocialSkillsNull){}
}