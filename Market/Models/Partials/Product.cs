using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models
{
    public partial class Product
    {
        public string FullName
        {
            get
            {
                return $"Name:{Name}, Description:{Description}";
            }
        }
        public byte[] MainPhoto
        {
            get
            {
                var firstPhoto = this.ProductPhoto.FirstOrDefault();
                if (firstPhoto != null)
                {
                    return firstPhoto.Photo;
                }
                return null ;
            }
        }
    }
}
