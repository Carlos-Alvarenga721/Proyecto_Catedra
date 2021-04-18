using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Cátedra
{
    class Program
    {
        static void Main(string[] args)
        {
            Proyecto_Catedra();
        }

        static void Proyecto_Catedra()
        {
            Console.Title = "Proyecto de Catedra";
            string usuario, contraseña;
            string [,] productos = new string [11,4];
            double opcion;
            bool valida = false;
            do
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Ingrese su usuario: ");
                usuario = Console.ReadLine();
                Console.Write("Ingrese su contraseña: ");
                contraseña = Console.ReadLine();
                Console.Clear();
                if (usuario != "carlos")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("El usuario no es valido");
                    Console.WriteLine("\n");
                    valida = false;
                }
                else
                {
                    if (contraseña != "123")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("La contraseña no es valida");
                        Console.WriteLine("\n");
                        valida = false;
                    }
                    else
                        valida = true;
                }          
            } while (valida == false);
            Console.WriteLine("Su usuario y contraseña son correctos");
            Console.WriteLine("\n");
            Console.WriteLine("********************************************************");
            Console.WriteLine($"***               Bienvenido {usuario}                  ***");
            Console.WriteLine("********************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("--> Presione ENTER para pasar a la siguiente pantalla:");
            Mostrar_Productos(ref productos);
            Console.ReadKey();
            do { 
            Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("***                MENU PRINCIPAL                   ***");
                Console.WriteLine("********************************************************");
                Console.WriteLine("*                                                      *");
                Console.WriteLine("*      1> Mostrar en pantalla todos los productos      *");
                Console.WriteLine("*      2> Buscar producto por código                   *");
                Console.WriteLine("*      3> Registrar venta                              *");
                Console.WriteLine("*      4> Salir del programa                           *");
                Console.WriteLine("*                                                      *");
                Console.WriteLine("********************************************************");
                Console.WriteLine("\n");
                Console.Write($"---> Digite una opcion entre (1...4): ");
                opcion = double.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                switch (opcion)
                {
                    case 1:
                        Mostrar_Productos(ref productos);
                        Console.Clear();
                        int f;
                        Console.WriteLine("********************************************************");
                        Console.WriteLine("***       Lista de productos en inventario:          ***");
                        Console.WriteLine("********************************************************");
                        Console.WriteLine("\n");

                                Console.WriteLine("===================================================================");
                        for (f = 0; f < 11; f++)
                        {
                            if (f == 0)
                            {
                                Console.WriteLine($"{productos[f, 0].Trim().PadRight(10, ' ')}  {productos[f, 1].Trim().PadRight(25, ' ')}  {productos[f, 2].Trim().PadRight(10, ' ')}  {productos[f, 3].Trim().PadLeft(10, ' ')}");
                                Console.WriteLine("===================================================================");
                            }
                            else
                                Console.WriteLine($"{productos[f, 0].Trim().PadRight(10, ' ')}  {productos[f, 1].Trim().PadRight(25, ' ')}  {$"${productos[f, 2].Trim().PadRight(10, ' ')}"}  {productos[f, 3].Trim().PadLeft(10, ' ')}");
                                Console.WriteLine("-------------------------------------------------------------------");
                        }
                        break;
                    case 2:
                        string cod_buscar;
                        Console.Clear();
                        Console.WriteLine("Digitar el codigo del producto a solicitar:");
                        cod_buscar = Console.ReadLine();
                        Console.WriteLine("\n");
                        int x;
                        bool encontrado = false;
                        for (x = 0; x < 11; x++)
                        {
                            if (cod_buscar == productos[x, 0])
                            {
                                    Console.WriteLine($"{productos[0, 0].Trim().PadRight(10, ' ')}  {productos[0, 1].Trim().PadRight(25, ' ')}  {productos[0, 2].Trim().PadRight(10, ' ')}  {productos[0, 3].Trim().PadLeft(10, ' ')}");
                                    Console.WriteLine("===================================================================");
                                    Console.WriteLine($"{productos[x, 0].Trim().PadRight(10, ' ')}  {productos[x, 1].Trim().PadRight(25, ' ')}  {$"${productos[x, 2].Trim().PadRight(10, ' ')}"}  {productos[x, 3].Trim().PadLeft(10, ' ')}");
                                    Console.WriteLine("-------------------------------------------------------------------");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("--> Presione ENTER para regresar al menu principal:");
                                    encontrado = true;
                            }                                                                                                                 
                        }
                        if (encontrado == false)
                        {
                            Console.WriteLine("El codigo del producto no existe");
                            Console.WriteLine("\n");
                            Console.WriteLine("--> Presione ENTER para regresar al menu principal:");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        string cliente, DUI;
                        Console.WriteLine("Registrar factura");
                        Console.WriteLine("\n");
                        Console.Write("Digite el nombre del cliente: ");
                        cliente = Console.ReadLine();
                        Console.Write("Digite el DUI del cliente: ");
                        DUI = Console.ReadLine();
                        Registrar_Venta(cliente,DUI);
                        Console.WriteLine("Factura generada");
                        break;
                    case 4:
                        Console.Write("---> Fin del programa ");
                        break;                 
                    default:
                            Console.WriteLine("Digito una opcion fuera del rango indicado, intentelo nuevamente");
                        break;
                }
                Console.ReadKey();
                Console.Clear(); 
            } while (opcion != 4); 
        }

        static void Mostrar_Productos(ref string[,] M_Prod ) 
        {
            StreamReader A_Productos = new StreamReader ("C:\\Users\\ialva\\Desktop\\CICLO 1-UDB\\PROG. ESTRUCTURADA\\TEORICO\\Proyecto de catedra codigo\\productos.csv");
            string Linea;
            string[] valores;
            int filas=0;
            Linea = A_Productos.ReadLine();          
            while (Linea != null)
            {                   
                valores = Linea.Split(',').ToArray();
                Linea = A_Productos.ReadLine();
                M_Prod[filas,0] = valores[0];
                M_Prod[filas, 1] = valores[1];
                M_Prod[filas, 2] = valores[2];
                M_Prod[filas, 3] = valores[3];
                filas += 1;
            }
        }

        static void Registrar_Venta(string cliente, string DUI)
        {
            string ruta_archivo;
            ruta_archivo = "R_Ventas_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt";
            StreamWriter factura = new StreamWriter(ruta_archivo);
            factura.WriteLine($"FACTURA N#{DateTime.Now.ToString("ddMMyyyyhhmmss")}");
            Console.WriteLine("\n");
            factura.WriteLine(cliente);
            factura.WriteLine(DUI);
            factura.Close();         
        }
    }
    
}
