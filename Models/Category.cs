using System;
using System.ComponentModel.DataAnnotations;

namespace UserApp3_1.Models
{
	public class Category
	{

		public int Id { get; set; }
		public string Name { get; set; }
		[Range(1,100, ErrorMessage ="Order must be between 1 and 100")]
		public int DisplayOrder { get; set; }
		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
		public string Adress { get; set; }
        public string? PhoneNumber { get; set; }

    }
}

