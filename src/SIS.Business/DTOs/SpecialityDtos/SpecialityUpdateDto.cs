using System;
using SIS.Core.Entities;

namespace SIS.Business.DTOs.SpecialityDtos
{
	public class SpecialityUpdateDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SpecialityNo { get; set; }
        public string? Faculty { get; set; }
    }
}

