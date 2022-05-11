using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UserServiceShould
{
    [Test]
    public void GivenUserId_ReturnAnUserAccount()
    {
        UserService uService = new UserService();
        
        int id = 2;

        User user = uService.GetUser(id);

        Assert.IsNotNull(user);
    }

}



internal class UserService
{
    public UserService()
    {
    }

    internal User GetUser(int userId)
    {
        
        return new User(userId);
    }

    
}