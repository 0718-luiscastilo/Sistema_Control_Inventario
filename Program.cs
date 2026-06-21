using System;

public class Program{
    public static int SolicitarCantidadProductos(){
        int cantidad;
        do{
            Console.Write("Ingrese la cantidad de productos: ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0){
                return cantidad;
            }
        
        Console.WriteLine("Error: Debe ingresar un número entero mayor que 0.");

        } while (true);
    }
    public static void MostrarTodosLosProductos(string[] nombresProductos, int[] cantidadesProductos, double[] preciosProductos){
        Console.WriteLine("\n===== INVENTARIO COMPLETO =====");
        for (int i = 0; i < nombresProductos.Length; i++){
            double valorTotalProducto = cantidadesProductos[i] * preciosProductos[i];
            Console.WriteLine( "Producto: " + nombresProductos[i] + " | Cantidad: " + cantidadesProductos[i] +
            " | Precio: $" + preciosProductos[i] +
            " | Valor Total: $" + valorTotalProducto);
        }
    }
    public static void BuscarProductoPorNombre(string[] nombresProductos, int[] cantidadesProductos,double[] preciosProductos){
        Console.Write("\nIngrese el nombre del producto a buscar: ");
        string nombreBuscado = Console.ReadLine();
        bool encontrado = false;
        for (int i = 0; i < nombresProductos.Length; i++){
            if (nombresProductos[i].Equals(nombreBuscado,StringComparison.OrdinalIgnoreCase)){
                double valorTotal = cantidadesProductos[i] * preciosProductos[i];
                Console.WriteLine("\n===== PRODUCTO ENCONTRADO =====");
                Console.WriteLine("Nombre: " + nombresProductos[i]);
                Console.WriteLine("Cantidad: " + cantidadesProductos[i]);
                Console.WriteLine("Precio: $" + preciosProductos[i]);
                Console.WriteLine("Valor Total: $" + valorTotal);
                encontrado = true;
                break;
            }
        }
        if (!encontrado){
            Console.WriteLine("El producto no existe en el inventario.");
        }
    }
    public static void MostrarProductosBajoInventario(string[] nombresProductos,int[] cantidadesProductos, double[] preciosProductos){
        Console.WriteLine("\n===== PRODUCTOS CON BAJO INVENTARIO =====");
        bool hayProductos = false;
        for (int i = 0; i < nombresProductos.Length; i++){
            if (cantidadesProductos[i] < 5){
                Console.WriteLine( "Producto: " + nombresProductos[i] + " | Cantidad: " + cantidadesProductos[i] +
                " | Precio: $" + preciosProductos[i]);
                hayProductos = true;
            }
        }
        if (!hayProductos){
            Console.WriteLine("No hay productos con bajo inventario.");
        }
    }
    public static void MostrarProductosAgotados(string[] nombresProductos, int[] cantidadesProductos, double[] preciosProductos){
        Console.WriteLine("\n===== PRODUCTOS AGOTADOS =====");
        bool hayAgotados = false;
        for (int i = 0; i < nombresProductos.Length; i++) {
            if (cantidadesProductos[i] == 0){
                Console.WriteLine( "Producto: " + nombresProductos[i] + " | Cantidad: " + cantidadesProductos[i] +
                " | Precio: $" + preciosProductos[i]);
                hayAgotados = true;
            }
        }
        if (!hayAgotados){
            Console.WriteLine("No hay productos agotados.");
        }
    }
    public static double CalcularValorTotalInventario(int[] cantidadesProductos,double[] preciosProductos){
        double valorTotal = 0;
        for (int i = 0; i < cantidadesProductos.Length; i++){
            valorTotal += cantidadesProductos[i] * preciosProductos[i];
        }
        return valorTotal;
    }
    public static void MostrarProductoMasCaro(string[] nombresProductos, int[] cantidadesProductos, double[] preciosProductos){
        int indiceMasCaro = 0;
        for (int i = 1; i < preciosProductos.Length; i++){
            if (preciosProductos[i] > preciosProductos[indiceMasCaro]){
                indiceMasCaro = i;
            }
        }
        Console.WriteLine("\n===== PRODUCTO MÁS CARO =====");
        Console.WriteLine("Nombre: " + nombresProductos[indiceMasCaro]);
        Console.WriteLine("Cantidad: " + cantidadesProductos[indiceMasCaro]);
        Console.WriteLine("Precio: $" + preciosProductos[indiceMasCaro]);
    }
    public static void MostrarProductoMayorCantidad(string[] nombresProductos, int[] cantidadesProductos, double[] preciosProductos){
        int indiceMayorCantidad = 0;
        for (int i = 1; i < cantidadesProductos.Length; i++){
            if (cantidadesProductos[i] > cantidadesProductos[indiceMayorCantidad]){
                indiceMayorCantidad = i;
            }
        }
        Console.WriteLine("\n===== PRODUCTO CON MAYOR CANTIDAD DISPONIBLE =====");
        Console.WriteLine("Nombre: " + nombresProductos[indiceMayorCantidad]);
        Console.WriteLine("Cantidad: " + cantidadesProductos[indiceMayorCantidad]);
        Console.WriteLine("Precio: $" + preciosProductos[indiceMayorCantidad]);
    }


    public static int MostrarMenu(){
        int opcion;
        do{
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Mostrar todos los productos");
            Console.WriteLine("2. Buscar producto por nombre");
            Console.WriteLine("3. Mostrar productos con bajo inventario");
            Console.WriteLine("4. Mostrar productos agotados");
            Console.WriteLine("5. Calcular valor total del inventario");
            Console.WriteLine("6. Mostrar producto más caro");
            Console.WriteLine("7. Mostrar producto con mayor cantidad disponible");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 8){
                return opcion;
            }
            
            Console.WriteLine("Error: Debe seleccionar una opción válida.");

        } while (true);
}

    public static void RegistrarProductos(string[] nombresProductos, int[] cantidadesProductos, double[] preciosProductos){
        for (int i = 0; i < nombresProductos.Length; i++){
            Console.WriteLine($"\nProducto {i + 1}");
            Console.Write("Nombre: ");
            nombresProductos[i] = Console.ReadLine();

            Console.Write("Cantidad disponible: ");
            cantidadesProductos[i] = int.Parse(Console.ReadLine());

            Console.Write("Precio unitario: ");
            preciosProductos[i] = double.Parse(Console.ReadLine());
        }   
    }

 
   public static void Main(string[] args){
    int cantidadProductos = SolicitarCantidadProductos();
    
    string[] nombresProductos = new string[cantidadProductos];
    int[] cantidadesProductos = new int[cantidadProductos];
    double[] preciosProductos = new double[cantidadProductos];

    RegistrarProductos(nombresProductos, cantidadesProductos, preciosProductos);
    int opcion;
    do{
        opcion = MostrarMenu();
        switch (opcion){
            case 1:
                MostrarTodosLosProductos(nombresProductos, cantidadesProductos, preciosProductos);
                break;
            case 2:
                BuscarProductoPorNombre(nombresProductos, cantidadesProductos, preciosProductos);
                break;
            case 3:
                MostrarProductosBajoInventario(nombresProductos, cantidadesProductos, preciosProductos);
                break;
            case 4:
                MostrarProductosAgotados(nombresProductos, cantidadesProductos, preciosProductos );
                break;
            case 5:
                double valorInventario = CalcularValorTotalInventario(cantidadesProductos, preciosProductos);
                Console.WriteLine("\nValor total del inventario: $" +valorInventario);
                break;
            case 6:
                MostrarProductoMasCaro(nombresProductos, cantidadesProductos, preciosProductos);
                break;
            case 7:
                MostrarProductoMayorCantidad(nombresProductos, cantidadesProductos, preciosProductos);
                break;

            case 8:
                Console.WriteLine("Saliendo del sistema...");
                break;
        }

    } while (opcion != 8);
    
    }
}        
