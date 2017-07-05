using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeccionMVC.Models
{
    public class Persona
    {
        public override string ToString()
        {
            return string.Format("Nombre: {0}\nApellido: {1}\nFecha de Nacimiento: {2}\nEdad: {3}",
                                  Nombre, Apellido, FechaNacimiento, Edad);
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
        public int Edad
        {
            get
            {
                int temp = DateTime.Now.Year - FechaNacimiento.Year - 1;

                if (DateTime.Now.Month > FechaNacimiento.Month
                  || DateTime.Now.Month == FechaNacimiento.Month && DateTime.Now.Day >= FechaNacimiento.Day)
                    return temp++;

                return temp;
            }
        }
    }


}