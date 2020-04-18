using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imdossin.Models
{
    public class Product
    {
        [Key]
        public int Prod_ID { get; set; }
        [Required]
        public string Prod_Name { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; } //Số lượng
        public string Supplier { get; set; } //Nhà cung cấp
        public DateTime Date { get; set; }
        public string Description { get; set; } //Mô tả sp
        public byte[] Image { get; set; } //Hình ảnh sp
        public string UrlImage { get; set; }//Đường dẫn hình ảnh
        public int Status_ID { get; set; }
    }
}


