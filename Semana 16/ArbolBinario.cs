using System;

class Nodo
{
    public int valor;
    public Nodo izquierda;
    public Nodo derecha;

    public Nodo(int valor)
    {
        this.valor = valor;
        izquierda = derecha = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public Nodo Insertar(Nodo raiz, int valor)
    {
        if (raiz == null)
            return new Nodo(valor);

        if (valor < raiz.valor)
            raiz.izquierda = Insertar(raiz.izquierda, valor);
        else
            raiz.derecha = Insertar(raiz.derecha, valor);

        return raiz;
    }

    public void Inorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Inorden(raiz.izquierda);
            Console.Write(raiz.valor + " ");
            Inorden(raiz.derecha);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int[] valores = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (int v in valores)
            arbol.raiz = arbol.Insertar(arbol.raiz, v);

        Console.WriteLine("Recorrido Inorden:");
        arbol.Inorden(arbol.raiz);
    }
}