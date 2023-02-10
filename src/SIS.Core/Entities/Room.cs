using System;
using SIS.Core.Interfaces;

namespace SIS.Core.Entities
{
	public class Room:IEntity
	{
        public int Id { get ; set ; }
        public int? RoomNo { get; set; }
        public int? Floor { get; set; }
        public int? Capacity { get; set; }
    }
}

