using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    internal class Person
    {
        private string name="Nimetön";
        private string email = "";
        private DateOnly? birthday = null;

        public string Name {
            get 
            {
                return name;
            } 
            set 
            {
                if (string.IsNullOrEmpty(value)) return;
                name = value;
            } 
        }
        public string Email 
        {
            get
            {
                return email;
            }
            set
            {
                if (value != null) email = value;
            }
        }

        public DateOnly? Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                if (!value.HasValue) birthday = null;
                else
                {
                    if (value < DateOnly.FromDateTime(DateTime.Now)) birthday = value;
                }
            }
        }

        public string BirthdayString
        {
            get
            {
                return birthday.ToString();
            }
            set
            {
                if (value == null) birthday = null;
                else birthday = DateOnly.Parse(value);
            }
        }

        public int? Age
        {
            get
            {
                //if (!birthday.HasValue) return null;
                return DateTime.Now.Year - birthday?.Year;
            }
        }
    }
}
