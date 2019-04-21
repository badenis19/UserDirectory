using System;
using App.Library.CodeStructures.Behavioural;

namespace UserApi.UseCases
{
  public class EmailIsNotSpecified : AResponseErrorMessage
  {
    public override string Message => nameof(EmailIsNotSpecified);
  }

  public class EmailLacksAtCharacter : AResponseErrorMessage
  {
    public override string Message => nameof(EmailLacksAtCharacter);
  }

  public class PasswordIsTooShort : AResponseErrorMessage
  {
    public override string Message => nameof(PasswordIsTooShort);
  }

  public class PasswordLacksUpperCaseCharacter : AResponseErrorMessage
  {
    public override string Message => nameof(PasswordLacksUpperCaseCharacter);
  }

  public class PasswordLacksLowerCaseCharacter : AResponseErrorMessage
  {
    public override string Message => nameof(PasswordLacksLowerCaseCharacter);
  }

  public class PasswordLacksDigitCharacter : AResponseErrorMessage
  {
    public override string Message => nameof(PasswordLacksDigitCharacter);
  }

  public class PasswordLacksSpecialCharacter : AResponseErrorMessage
  {
    public override string Message => nameof(PasswordLacksSpecialCharacter);
  }
}
