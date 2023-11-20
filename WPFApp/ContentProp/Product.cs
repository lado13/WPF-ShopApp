using System.Collections.Generic;

namespace WPFApp
{
    public  class  Product
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }     
        public List<string> Images { get; set; }
        public override string ToString()
        {
            return $"Id:{Id} Title:{Title} Price:{Price} Image:{Images}";
        }

    }
}
