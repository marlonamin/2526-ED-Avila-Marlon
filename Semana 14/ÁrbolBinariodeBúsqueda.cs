using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    private Nodo raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo actual, int valor)
    {
        if (actual == null)
            return new Nodo(valor);

        if (valor < actual.Valor)
            actual.Izquierdo = InsertarRec(actual.Izquierdo, valor);
        else if (valor > actual.Valor)
            actual.Derecho = InsertarRec(actual.Derecho, valor);
        else
            Console.WriteLine("El valor ya existe en el árbol.");

        return actual;
    }

    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo actual, int valor)
    {
        if (actual == null)
            return false;

        if (valor == actual.Valor)
            return true;

        if (valor < actual.Valor)
            return BuscarRec(actual.Izquierdo, valor);

        return BuscarRec(actual.Derecho, valor);
    }

    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo actual, int valor)
    {
        if (actual == null)
        {
            Console.WriteLine("El valor no se encontró en el árbol.");
            return null;
        }

        if (valor < actual.Valor)
        {
            actual.Izquierdo = EliminarRec(actual.Izquierdo, valor);
        }
        else if (valor > actual.Valor)
        {
            actual.Derecho = EliminarRec(actual.Derecho, valor);
        }
        else
        {
            if (actual.Izquierdo == null && actual.Derecho == null)
                return null;

            if (actual.Izquierdo == null)
                return actual.Derecho;

            if (actual.Derecho == null)
                return actual.Izquierdo;

            Nodo sucesor = ObtenerMinNodo(actual.Derecho);
            actual.Valor = sucesor.Valor;
            actual.Derecho = EliminarRec(actual.Derecho, sucesor.Valor);
        }

        return actual;
    }

    private Nodo ObtenerMinNodo(Nodo actual)
    {
        while (actual.Izquierdo != null)
            actual = actual.Izquierdo;

        return actual;
    }

    public void MostrarInorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        InordenRec(raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo actual)
    {
        if (actual != null)
        {
            InordenRec(actual.Izquierdo);
            Console.Write(actual.Valor + " ");
            InordenRec(actual.Derecho);
        }
    }

    public void MostrarPreorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        PreordenRec(raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo actual)
    {
        if (actual != null)
        {
            Console.Write(actual.Valor + " ");
            PreordenRec(actual.Izquierdo);
            PreordenRec(actual.Derecho);
        }
    }

    public void MostrarPostorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        PostordenRec(raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo actual)
    {
        if (actual != null)
        {
            PostordenRec(actual.Izquierdo);
            PostordenRec(actual.Derecho);
            Console.Write(actual.Valor + " ");
        }
    }

    public int ObtenerMinimo()
    {
        if (raiz == null)
            throw new InvalidOperationException("El árbol está vacío.");

        Nodo actual = raiz;
        while (actual.Izquierdo != null)
            actual = actual.Izquierdo;

        return actual.Valor;
    }

    public int ObtenerMaximo()
    {
        if (raiz == null)
            throw new InvalidOperationException("El árbol está vacío.");

        Nodo actual = raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;

        return actual.Valor;
    }

    public int ObtenerAltura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo actual)
    {
        if (actual == null)
            return -1;

        int alturaIzquierda = AlturaRec(actual.Izquierdo);
        int alturaDerecha = AlturaRec(actual.Derecho);

        return Math.Max(alturaIzquierda, alturaDerecha) + 1;
    }

    public void Limpiar()
    {
        raiz = null;
    }

    public bool EstaVacio()
    {
        return raiz == null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda bst = new ArbolBinarioBusqueda();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n===== MENÚ ÁRBOL BINARIO DE BÚSQUEDA =====");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorrido Inorden");
            Console.WriteLine("5. Mostrar recorrido Preorden");
            Console.WriteLine("6. Mostrar recorrido Postorden");
            Console.WriteLine("7. Mostrar valor mínimo");
            Console.WriteLine("8. Mostrar valor máximo");
            Console.WriteLine("9. Mostrar altura del árbol");
            Console.WriteLine("10. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        bst.Insertar(valor);
                        Console.WriteLine("Valor insertado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        Console.WriteLine(bst.Buscar(valor)
                            ? "El valor sí existe en el árbol."
                            : "El valor no existe en el árbol.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 3:
                    Console.Write("Ingrese el valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out valor))
                    {
                        bst.Eliminar(valor);
                        Console.WriteLine("Operación de eliminación finalizada.");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 4:
                    Console.Write("Recorrido Inorden: ");
                    bst.MostrarInorden();
                    break;

                case 5:
                    Console.Write("Recorrido Preorden: ");
                    bst.MostrarPreorden();
                    break;

                case 6:
                    Console.Write("Recorrido Postorden: ");
                    bst.MostrarPostorden();
                    break;

                case 7:
                    if (!bst.EstaVacio())
                        Console.WriteLine("Valor mínimo: " + bst.ObtenerMinimo());
                    else
                        Console.WriteLine("El árbol está vacío.");
                    break;

                case 8:
                    if (!bst.EstaVacio())
                        Console.WriteLine("Valor máximo: " + bst.ObtenerMaximo());
                    else
                        Console.WriteLine("El árbol está vacío.");
                    break;

                case 9:
                    if (!bst.EstaVacio())
                        Console.WriteLine("Altura del árbol: " + bst.ObtenerAltura());
                    else
                        Console.WriteLine("El árbol está vacío.");
                    break;

                case 10:
                    bst.Limpiar();
                    Console.WriteLine("El árbol ha sido limpiado completamente.");
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}