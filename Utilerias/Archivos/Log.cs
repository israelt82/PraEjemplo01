using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Praxis.Archivos
{
    public class Log
    {
        #region Metodos Publicos
        /// <summary>
        /// Permite escribir en el log de la aplicación, no importa el tipo de aplicación.
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="mensaje"></param>
        static public void Escribir(string modulo, string mensaje)
        {
            string path = "";
            try
            { path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); }
            catch
            { path = HttpContext.Current.Server.MapPath("~"); }
            finally { }
            Escribe(path, modulo, mensaje);
        }
        #endregion

        #region Metodos Privados
        static private void Escribe(string path, string modulo, string mensaje)
        {
            try
            {
                bool flag = Convert.ToBoolean(ConfigurationManager.AppSettings["USA_LOG"]);
                if (flag)
                {
                    mensaje = mensaje.Replace("\n", "");
                    mensaje = mensaje.Replace("\r", "");
                    string directorio = path + "\\LogFile\\";
                    string archivo = "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                    bool flag2 = !Directory.Exists(directorio);
                    if (flag2)
                        Directory.CreateDirectory(directorio);

                    StreamWriter streamWriter = new StreamWriter(directorio + archivo, true);
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    string filaArchivo = string.Format("{0} | {1} | {2} ", hora.PadRight(20), modulo.PadRight(50), mensaje);
                    streamWriter.WriteLine(filaArchivo);
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { }
        }
        #endregion
    }
}
