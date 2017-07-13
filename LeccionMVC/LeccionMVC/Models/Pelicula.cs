using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagnaDB;
using System.ComponentModel.DataAnnotations;

namespace LeccionMVC.Models
{
    public class Pelicula : TableModel<Pelicula>
    {
        [Key]
        [Identity]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre de la Película es muy corto")]
        [DuplicationColumn]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaPublicacion { get; set; }

        protected override string TableName
        {
            get
            {
                return "Peliculas";
            }
        }

        protected override string ConnectionString
        {
            get
            {
                return MvcApplication.connectionString;
            }
        }

        protected override MagnaKey Key
        {
            get
            {
                return this.MakeKey(model => model.Id);
            }
        }
    }
}