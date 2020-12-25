// File:    Person.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:45:03 PM
// Purpose: Definition of Class Person
using System;

namespace Model.Users
{
    public class Person 
    {
        #region Attributes

        private int id;
        private string name;
        private string surname;
        private string gender;
        private DateTime _birthday;
        private string _adress;
        private string jmbg;
        private string parentsName;
        private string _biography;
        private string _phoneNumber;
        private string _email;
        #endregion
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Jmbg { get; set; }


        public string ParentsName { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string Biography { get; set; }

        public DateTime Birthday { get; set; }


    }
}