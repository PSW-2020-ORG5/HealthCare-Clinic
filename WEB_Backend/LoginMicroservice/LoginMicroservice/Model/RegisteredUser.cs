// File:    RegisteredUser.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:16 PM
// Purpose: Definition of Class RegisteredUser

using System;

namespace Model.Users
{
    public class RegisteredUser : Person
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}