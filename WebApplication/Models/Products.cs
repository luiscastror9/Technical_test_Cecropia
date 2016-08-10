using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Products
    {
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the estado id.
        /// </summary>
        /// <value>
        /// The estado user.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Brand { get; set; }
        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        /// <value>
        /// The coduser.
        /// </value>
        public decimal Size { get; set; }
        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        /// <value>
        /// The cantidadoperacion.
        /// </value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        public int Quantity_in_stock { get; set; }
        /// <summary>
        /// Gets or sets the Quantity_in_stock.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        public DateTime Created_date { get; set; }
        /// <summary>
        /// Gets or sets the Created_date.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        public DateTime Updated_date { get; set; }
        /// <summary>
        /// Gets or sets the Updated_date.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
      
    }
}