using System;
using SEDC.Loto3000App.Domain.Enums;

namespace SEDC.Loto3000App.Domain.Models
{
    public class Loto : BaseEntity
    {
        public int Numbers { get; set; }

        public Prize Prize { get; set; }

        public Session Session { get; set; }


        public int UserId { get; set; }

        public User User { get; set; }
    }
}

