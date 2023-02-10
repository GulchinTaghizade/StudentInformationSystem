using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
    public class Speciality:IEntity
    {
        public int Id { get ; set ; }
        public string? Name { get; set; }
        public string? SpecialityNo { get; set; }
        public Faculty? Faculty { get; set; }
    }
}

