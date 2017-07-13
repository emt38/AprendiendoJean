using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;

namespace LeccionMVC.Models
{
    public class Actor
    {
        public void Insertar()
        {
            SqlConnection connection = new SqlConnection("Data Source=MI-AMADISIMA;Initial Catalog=JeanPelis;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = new SqlCommand(String.Format(@"INSERT INTO Actores (Nombre, Apellido, Estatura, FechaNacimiento)
                                                                VALUES ('{0}', '{1}', {2}, '{3}')", Nombre, Apellido, Estatura, FechaNacimiento.ToString("yyyy-MM-dd")), connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            command.Dispose();
            connection.Dispose();
        }

        public static List<Actor> Listar()
        {
            List<Actor> resultado = new List<Actor>();

            SqlConnection connection = new SqlConnection("Data Source=MI-AMADISIMA;Initial Catalog=JeanPelis;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand command = new SqlCommand("SELECT * FROM Actores", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable temp = new DataTable();

            adapter.Fill(temp);

            foreach (DataRow item in temp.Rows)
            {
                Actor nuevo = new Actor()
                {
                    Id = item.Field<int>("Id"),
                    Nombre = item.Field<string>("Nombre"),
                    Apellido = (string)item["Apellido"],
                    Estatura = item.Field<int>("Estatura"),
                    FechaNacimiento = item.Field<DateTime>("FechaNacimiento")
                };
                resultado.Add(nuevo);
            }

            return resultado;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre es muy corto")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido es muy corto")]
        public string Apellido { get; set; }

        [Range(0, int.MaxValue)]
        public int Estatura { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}