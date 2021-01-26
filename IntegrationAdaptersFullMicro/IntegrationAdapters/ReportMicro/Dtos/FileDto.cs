using IntegrationAdapters.Models;
using System;

namespace IntegrationAdapters.Dtos
{
    public class FileDto : ValueObject
    {
        public string Bytes { get; set; }
        public string Title { get; set; }


        public FileDto() 
        { 

        }

        public FileDto(string bytes, string title)
        {
            Bytes = bytes;
            Title = title;

            Validate();
        }

     
        protected override void Validate()
        {
            if (Title == "" || Bytes == "")
            {
                throw new Exception("Error, empty strings!");
            }
        }

        protected override bool EqualsValue(object o)
        {
            FileDto other = (FileDto)o;

            return other.Bytes == this.Bytes && other.Title == this.Title;
        }

        protected override string PrintObject()
        {
            string ret = "Bytes: " + Bytes + "\n";
            ret += "Title: " + Title;

            return ret;
        }
    }
}
