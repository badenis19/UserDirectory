using System;
using System.Collections.Generic;
using System.Linq;
using App.Library.CodeStructures.Behavioural;
using App.Library.Persistence;
using Moq;
using UserApi.Models;
using UserApi.UseCases;
using Xunit;

namespace test
{
  public class RegisterUserWill
  {
    [Fact]
    public void AllowValidEmail()
    {
      //Arrange
      var aUser = TestHelper.MakeUser(TestHelper.MakeValidEmail);

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(!response.HasErrors());
    }

    [Fact]
    public void NotAllowEmptyEmail()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("");

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<EmailIsNotSpecified>());
    }

    [Fact]
    public void NotAllowEmailWithout_At()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat.com");

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<EmailLacksAtCharacter>());
    }

    [Fact]
    public void AllowValidPassword()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com", TestHelper.MakeValidPassword);

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(!response.HasErrors());
    }

    [Fact]
    public void NotAllowTooShortPassword()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com", TestHelper.MakeValidPassword.Substring(0, 7));

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<PasswordIsTooShort>());
    }

    [Fact]
    public void NotAllowPasswordWithoutAtLeastOneUpperCase()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com", TestHelper.MakeValidPassword.ToLower());

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<PasswordLacksUpperCaseCharacter>());
    }

    [Fact]
    public void NotAllowPasswordWithoutAtLeastOneLowerCase()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com", TestHelper.MakeValidPassword.ToUpper());

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<PasswordLacksLowerCaseCharacter>());
    }

    [Fact]
    public void NotAllowPasswordWithoutAtLeastOneDigit()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com",
                                      TestHelper.MakeValidPassword.Replace(
                                        TestHelper.Digit,
                                        TestHelper.SpecialChar
                                      )
      );

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<PasswordLacksDigitCharacter>());
    }

    [Fact]
    public void NotAllowPasswordWithoutAtLeastOneSpecial()
    {
      //Arrange
      var aUser = TestHelper.MakeUser("mat@ma.com",
                                      TestHelper.MakeValidPassword.Replace(
                                        TestHelper.SpecialChar,
                                        TestHelper.Digit
                                      )
      );

      var existingRepo = TestHelper.MakeRepo();

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new RegisterUserHandler(mockRepo.Object);

      var registerUser = new RegisterUser(aUser.Email, aUser.Password);

      //Act
      var response = sut.Handle(registerUser);

      //Assert
      Assert.True(response.HasErrors());
      Assert.True(response.HasMessage<PasswordLacksSpecialCharacter>());
    }
  }
}
