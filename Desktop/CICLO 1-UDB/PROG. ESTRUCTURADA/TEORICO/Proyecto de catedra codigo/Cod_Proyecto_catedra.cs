using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Cátedra
{
    public class Program
    {
        string[,] productos;
        static void Main(string[] args)
        {
            Proyecto_Catedra();
        }

        static void Proyecto_Catedra()
        {
            Console.Title = "Proyecto de Catedra";
            string usuario, contraseña;
            string[,] productos = new string[11, 4];
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
            do
            {
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
                        string cliente, DUI, codigo_Prod;
                        string[,] Factura = new string[13, 5];
                        Factura[0, 0] = "Codigo";
                        Factura[0, 1] = "Descripcion";
                        Factura[0, 2] = "Precio";
                        Factura[0, 3] = "Cantidad";
                        Factura[0, 4] = "Subtotal";
                        string decision, nombre, existencia, precio;
                        int contador = 0, cantidad = 0, contador2 = 0;
                        double subtotal = 0, total = 0;
                        Console.WriteLine("Registrar factura");
                        Console.WriteLine("\n");
                        Console.Write("Digite el nombre del cliente: ");
                        cliente = Console.ReadLine();
                        Console.Write("Digite el DUI del cliente: ");
                        DUI = Console.ReadLine();
                        do
                        {
                            contador2 = contador2 + 1;
                            Console.WriteLine($"\nDigitar el codigo del producto numero#{contador2}: ");
                            codigo_Prod = Console.ReadLine();
                            nombre = Datos_Producto(codigo_Prod, 1, productos);
                            if (nombre == "*")
                            {
                                Console.WriteLine("El codigo del producto no existe");
                            }
                            else
                            {

                                Console.WriteLine($"El producto con codigo {codigo_Prod} es {nombre}");
                                Console.WriteLine($"\nDigitar la cantidad que desea llevar: ");
                                cantidad = int.Parse(Console.ReadLine());
                                existencia = Datos_Producto(codigo_Prod, 3, productos);
                                if (cantidad > int.Parse(existencia))
                                {
                                    Console.WriteLine("\ncantidad no disponible en inventario");
                                }
                                else
                                {
                                    contador = contador + 1;
                                    precio = Datos_Producto(codigo_Prod, 2, productos);
                                    subtotal = cantidad * double.Parse(precio);
                                    Console.WriteLine($"\nEl precio es de ${precio}");
                                    Console.WriteLine($"El subtotal es de ${subtotal}");
                                    descontar_inventario(codigo_Prod, cantidad, ref productos);
                                    total = total + subtotal;
                                    Factura[contador, 0] = codigo_Prod;
                                    Factura[contador, 1] = nombre;
                                    Factura[contador, 2] = precio;
                                    Factura[contador, 3] = cantidad.ToString();
                                    Factura[contador, 4] = subtotal.ToString();
                                }
                            }
                            Console.WriteLine("\n--->Desea continuar con la factura?");
                            Console.WriteLine("--->Digitar S(si) o digitar N(no): ");
                            decision = Console.ReadLine();
                        } while (decision == "S" || decision == "s");
                        contador += 1;
                        Factura[contador, 0] = "";
                        Factura[contador, 1] = "";
                        Factura[contador, 2] = "";
                        Factura[contador, 3] = "";
                        Factura[contador, 4] = "---------";
                        contador += 1;
                        Factura[contador, 0] = "";
                        Factura[contador, 1] = "";
                        Factura[contador, 2] = "";
                        Factura[contador, 3] = "Total: ";
                        Factura[contador, 4] = total.ToString();
                        Registrar_Venta(cliente, DUI, Factura, contador);
                        modificar_archivo(ref productos);
                        Console.WriteLine("\nFactura generada");
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

        static void Mostrar_Productos(ref string[,] M_Prod)
        {
            StreamReader A_Productos = new StreamReader("C:\\Users\\ialva\\Desktop\\CICLO 1-UDB\\PROG. ESTRUCTURADA\\TEORICO\\Proyecto de catedra codigo\\productos.csv");
            string Linea;
            string[] valores;
            int filas = 0;
            Linea = A_Productos.ReadLine();
            while (Linea != null)
            {
                valores = Linea.Split(',').ToArray();
                Linea = A_Productos.ReadLine();
                M_Prod[filas, 0] = valores[0];
                M_Prod[filas, 1] = valores[1];
                M_Prod[filas, 2] = valores[2];
                M_Prod[filas, 3] = valores[3];
                filas += 1;
            }
            A_Productos.Close();
        }

        static void Registrar_Venta(string cliente, string DUI, string[,] Matriz_fac, int Cantidad_Prod)
        {
            int i;
            string ruta_archivo;
            ruta_archivo = "R_Ventas_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt";
            StreamWriter factura = new StreamWriter(ruta_archivo);
            factura.WriteLine($"FACTURA N#{DateTime.Now.ToString("ddMMyyyyhhmmss")}\n");
            factura.WriteLine($"Nombre del cliente: {cliente}");
            factura.WriteLine($"DUI del cliente: {DUI}\n");
            for (i = 0; i <= Cantidad_Prod; i++)
            {
                factura.WriteLine($"{Matriz_fac[i, 0].Trim().PadRight(10, ' ')}  {Matriz_fac[i, 1].Trim().PadRight(23, ' ')} {Matriz_fac[i, 2].Trim().PadRight(11, ' ')} {Matriz_fac[i, 3].Trim().PadRight(11, ' ')} {Matriz_fac[i, 4].Trim()}");
            }
            factura.Close();
        }

        static string Datos_Producto(string cod_Prod, int tipo, string[,] prod_m)
        {
            string valor;
            int f;
            valor = "*";

            for (f = 0; f < 11; f++)
            {
                if (prod_m[f, 0].Trim() == cod_Prod.Trim())
                {
                    switch (tipo)
                    {
                        case 1: //retorna nombre del producto
                            valor = prod_m[f, 1];
                            break;
                        case 2: //retorna precio del producto
                            valor = prod_m[f, 2];
                            break;
                        case 3: //retorna inventario del producto
                            valor = prod_m[f, 3];
                            break;
                    }

                }
            }
            return valor;
        }

        static void descontar_inventario(string Cod_prod, int cantidad, ref string[,] prod_m)
        {
            int f, Resultado = 0;
            string existencia = "";


            for (f = 0; f < 11; f++)
            {
                if (prod_m[f, 0].Trim() == Cod_prod.Trim())
                {
                    existencia = prod_m[f, 3];
                    Resultado = int.Parse(existencia) - cantidad;
                    prod_m[f, 3] = Resultado.ToString();
                }
            }
        }

        static void modificar_archivo(ref string[,] M_Prod)
        {
            int x;
            string oldName = "C:\\Users\\ialva\\Desktop\\CICLO 1-UDB\\PROG. ESTRUCTURADA\\TEORICO\\Proyecto de catedra codigo\\productos.csv";
            string newName = "C:\\Users\\ialva\\Desktop\\CICLO 1-UDB\\PROG. ESTRUCTURADA\\TEORICO\\Proyecto de catedra codigo\\productos_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".csv";
            System.IO.File.Move(oldName, newName);
            StreamWriter f_productos = new StreamWriter(oldName);
            for (x = 0; x < 11; x++)
            {
                f_productos.WriteLine($"{M_Prod[x, 0].Trim()},{M_Prod[x, 1].Trim()},{M_Prod[x, 2].Trim()},{M_Prod[x, 3].Trim()}");
            }
            f_productos.Close();
        }
    }

}
