using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo01.Escuela
{
    public abstract class Persona
    {
        #region Propiedad
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public int Edad { get; set; }
        #endregion
    }
}
