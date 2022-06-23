using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class UserServiceShould
{
    IUserRepository repoSubstitute;
    UserService uService;

    [SetUp]
    public void SetUp()
    {
        repoSubstitute = Substitute.For<IUserRepository>();

        uService = new UserService(repoSubstitute);
    }

    [Test]
    public void GivenUserId_ReturnAnUserAccount()
    {
        int id = 2;

        uService.GetUserById(id);

        repoSubstitute.Received().GetUser(id);
    }

    [Test]
    public void GivenAnEmail_CreateUserAccount()
    {
        string email = "test@quark.com.ar";

        uService.CreateUser(email);

        repoSubstitute.Received().CreateUser(Arg.Is<string>(email => email.Contains('@') && email.Contains(".com")));
    }

    [Test]
    public void GivenAUser_UpdateUserAccount()
    {
        User user = new User(3, "Juancito");

        uService.UpdateUser(user);

        repoSubstitute.Received().UpdateUser(Arg.Is<User>(user));
    }
}