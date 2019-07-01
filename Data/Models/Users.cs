using System;

namespace Data.Models
{
    public class Users
    {
        public Users()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public int UyeSapKodu { get; set; }
        public string TokenKey { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}