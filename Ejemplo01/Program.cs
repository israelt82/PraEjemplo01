using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo01.Escuela;

namespace Ejemplo01
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Problemas al procesar la solicitud";
            try
            {
                int opcion = 0;
                int opcionSub = 0;
                Alumno alumno = new Alumno();
                Alumnos alumnos = new Alumnos();
                do
                {
                    opcion = Menu();
                    switch (opcion)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                opcionSub = SubMenu(1);
                                switch (opcionSub)
                                {
                                    case 1:
                                        alumno= new Alumno();
                                        alumno.Nombre = Console.ReadLine();
                                        alumno.APaterno = Console.ReadLine();
                                        alumno.Edad = Convert.ToInt32(Console.ReadLine());
                                        alumno.Guardar(alumno);
                                        alumnos.Add(alumno);
                                        break;
                                    case 2:
                                        foreach (var item in alumnos)
                                        {
                                            Console.WriteLine(String.Format("{0} {1} {2}", item.Nombre, item.APaterno, item.Edad));
                                        }
                                        Console.WriteLine("Continuar..");
                                        Console.ReadKey();
                                        break;
                                    default:
                                        break;
                                }

                            } while (opcionSub!=3);
                            break;
                        case 2:
                            Console.Clear();
                            SubMenu(2);
                            break;
                        case 3:
                            Console.Clear();
                            System.Console.WriteLine("Adios");
                            break;
                        default:
                            Console.Clear();
                            System.Console.WriteLine("La opcion no existe, favor de volver a intentar, presiona una tecla para continuar..");
                            Console.ReadKey();
                            break;
                    }
                } while (opcion != 3);
                msg = "Correcto.";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }

            System.Console.WriteLine(msg);
            System.Console.ReadKey();
        }

        static int Menu()
        {
            try
            {
                System.Console.WriteLine("Menu principal");
                System.Console.WriteLine("1) Alumnos");
                System.Console.WriteLine("2) Profesores");
                System.Console.WriteLine("3) Salir");

                return Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception)
            {
                return 99;
            }
            finally { }

        }

        static int SubMenu(int tipo)
        {
            System.Console.Clear();
            System.Console.WriteLine(String.Format("Sub-Menu {0}", tipo == 1 ? "Alumno" : "Profesor"));
            try
            {
                System.Console.WriteLine("1) Alta");
                System.Console.WriteLine("2) Imprimir todos");
                System.Console.WriteLine("3) Salir");

                return Convert.ToInt32(System.Console.ReadLine());
            }
            catch (Exception)
            {
                return 99;
            }
            finally { }
        }
    }

}




