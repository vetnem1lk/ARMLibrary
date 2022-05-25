using System;
using System.Collections.Generic;

#nullable disable

namespace ARMLibrary
{
    public partial class Reader
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private static Reader _reader;

        public static Reader CreateBook(string lastName, string firstName, string birthday, string phone, string email)
        {
            _reader = new Reader
            {
                LastName = lastName,
                FirstName = firstName,
                Birthday = birthday,
                Email = email,
                Phone = phone
            };
            return _reader;
        }
    }
}
