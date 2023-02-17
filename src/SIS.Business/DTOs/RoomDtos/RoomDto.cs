using System;
namespace SIS.Business.DTOs.RoomDtos
{
	public class RoomDto
	{
        public int Id { get; set; }
        public int? RoomNo { get; set; }
        public int? Floor { get; set; }
        public int? Capacity { get; set; }
    }
}

