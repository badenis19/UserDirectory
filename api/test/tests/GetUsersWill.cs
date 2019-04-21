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
  public class GetUsersWill
  {
    [Fact]
    public void ReturnCorrectPage()
    {
      //Arrange
      var aUser1 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "1");
      var aUser2 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "2");
      var aUser3 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "3");
      var aUser4 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "4");
      var aUser5 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "5");
      var aUser6 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "6");
      var aUser7 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "7");
      var aUser8 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "8");
      var aUser9 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "9");
      var aUser10 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "10");

      var existingRepo = TestHelper.MakeRepo(
        aUser1, aUser2, aUser3, aUser4, aUser5,
        aUser6, aUser7, aUser8, aUser9, aUser10
      );

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new GetUsersHandler(mockRepo.Object);

      //Act
      var response = sut.Handle(new GetUsers()
      {
        Page = 2,
        PageSize = 4,
        OrderingType = OrderingBasis.creationDateAsc
      });

      //Assert
      Assert.Equal(4, response.Payload.Users.Count());
      Assert.Equal(aUser5, response.Payload.Users.First());
      Assert.Equal(aUser8, response.Payload.Users.Last());
    }

    [Fact]
    public void ReturnPageCreationAsc()
    {
      //Arrange
      var aUser1 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "1");
      var aUser2 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "2");
      var aUser3 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "3");
      var aUser4 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "4");
      var aUser5 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "5");
      var aUser6 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "6");
      var aUser7 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "7");
      var aUser8 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "8");
      var aUser9 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "9");
      var aUser10 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "10");

      var existingRepo = TestHelper.MakeRepo(
        aUser1, aUser2, aUser3, aUser4, aUser5,
        aUser6, aUser7, aUser8, aUser9, aUser10
      );

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new GetUsersHandler(mockRepo.Object);

      //Act
      var response = sut.Handle(new GetUsers()
      {
        Page = 1,
        PageSize = 3,
        OrderingType = OrderingBasis.creationDateAsc
      });

      Assert.Equal(aUser1, response.Payload.Users.First());
      Assert.Equal(aUser3, response.Payload.Users.Last());
    }

    [Fact]
    public void ReturnPageCreationDesc()
    {
      //Arrange
      var aUser1 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "1");
      var aUser2 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "2");
      var aUser3 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "3");
      var aUser4 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "4");
      var aUser5 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "5");
      var aUser6 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "6");
      var aUser7 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "7");
      var aUser8 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "8");
      var aUser9 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "9");
      var aUser10 = TestHelper.MakeUser(TestHelper.MakeValidEmail + "10");

      var existingRepo = TestHelper.MakeRepo(
        aUser1, aUser2, aUser3, aUser4, aUser5,
        aUser6, aUser7, aUser8, aUser9, aUser10
      );

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new GetUsersHandler(mockRepo.Object);

      //Act
      var response = sut.Handle(new GetUsers()
      {
        Page = 1,
        PageSize = 3,
        OrderingType = OrderingBasis.creationDateDesc
      });

      Assert.Equal(aUser10, response.Payload.Users.ElementAt(0));
      Assert.Equal(aUser8, response.Payload.Users.ElementAt(2));
    }

    [Fact]
    public void ReturnPageInAlphabeticalAsc()
    {
      //Arrange
      var aUser1 = TestHelper.MakeUser("C" + TestHelper.MakeValidEmail + "1");
      var aUser2 = TestHelper.MakeUser("X" + TestHelper.MakeValidEmail + "2");
      var aUser3 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "3");
      var aUser4 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "4");
      var aUser5 = TestHelper.MakeUser("B" + TestHelper.MakeValidEmail + "5");
      var aUser6 = TestHelper.MakeUser("Y" + TestHelper.MakeValidEmail + "6");
      var aUser7 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "7");
      var aUser8 = TestHelper.MakeUser("Z" + TestHelper.MakeValidEmail + "8");
      var aUser9 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "9");
      var aUser10 = TestHelper.MakeUser("A" + TestHelper.MakeValidEmail + "10");

      var existingRepo = TestHelper.MakeRepo(
        aUser1, aUser2, aUser3, aUser4, aUser5,
        aUser6, aUser7, aUser8, aUser9, aUser10
      );

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new GetUsersHandler(mockRepo.Object);

      //Act
      var response = sut.Handle(new GetUsers()
      {
        Page = 1,
        PageSize = 3,
        OrderingType = OrderingBasis.alphabeticalAsc
      });

      //Assert
      Assert.Equal(aUser10, response.Payload.Users.First());
      Assert.Equal(aUser1, response.Payload.Users.Last());
    }

    [Fact]
    public void ReturnPageInAlphabeticalDesc()
    {
      //Arrange
      var aUser1 = TestHelper.MakeUser("C" + TestHelper.MakeValidEmail + "1");
      var aUser2 = TestHelper.MakeUser("X" + TestHelper.MakeValidEmail + "2");
      var aUser3 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "3");
      var aUser4 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "4");
      var aUser5 = TestHelper.MakeUser("B" + TestHelper.MakeValidEmail + "5");
      var aUser6 = TestHelper.MakeUser("Y" + TestHelper.MakeValidEmail + "6");
      var aUser7 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "7");
      var aUser8 = TestHelper.MakeUser("Z" + TestHelper.MakeValidEmail + "8");
      var aUser9 = TestHelper.MakeUser("F" + TestHelper.MakeValidEmail + "9");
      var aUser10 = TestHelper.MakeUser("A" + TestHelper.MakeValidEmail + "10");

      var existingRepo = TestHelper.MakeRepo(
        aUser1, aUser2, aUser3, aUser4, aUser5,
        aUser6, aUser7, aUser8, aUser9, aUser10
      );

      var mockRepo = new Mock<IEntityRepository<User>>();
      mockRepo.Setup(repo => repo.Entities)
              .Returns(existingRepo);

      var sut = new GetUsersHandler(mockRepo.Object);

      //Act
      var response = sut.Handle(new GetUsers()
      {
        Page = 1,
        PageSize = 3,
        OrderingType = OrderingBasis.alphabeticalDesc
      });

      //Assert
      Assert.Equal(aUser8, response.Payload.Users.First());
      Assert.Equal(aUser2, response.Payload.Users.Last());
    }
  }
}
