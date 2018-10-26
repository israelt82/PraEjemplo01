using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo01.Escuela
{
    public class Alumno : Persona
    {
        #region Variables Locales
        Alumnos LstAlumnos = new Alumnos();
        #endregion

        #region Propiedad
        #endregion

        #region Contructores
        public Alumno() {}
        public Alumno(int calificacion)
        {
        }
        #endregion

        #region Metodos Publicos
        public bool Guardar(Alumno alumno)
        {
            try
            {
                LstAlumnos.Add(alumno);
            }
            catch (Exception ex)
            {
                string log = "Alumno.Guardar " + ex.Message;
                throw ex;
            }
            finally { }
            
            return true;
        }

        public Alumno PorId(int id)
        {
            return new Alumno();
        }

        public Alumnos Todo() {
            return LstAlumnos; 
        }
        #endregion
    }

    public class Alumnos : List<Alumno>
    {
    }
}
