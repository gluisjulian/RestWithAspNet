using RestWithAspNet.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNet.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("price")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Price { get; set; }

        [Column("launch_date")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime LaunchDate { get; set; }
    }
}
