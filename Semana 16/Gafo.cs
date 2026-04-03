using System;
using System.Collections.Generic;

class Grafo
{
    private Dictionary<string, List<string>> listaAdyacencia;

    public Grafo()
    {
        listaAdyacencia = new Dictionary<string, List<string>>();
    }

    public void AgregarArista(string origen, string destino)
    {
        if (!listaAdyacencia.ContainsKey(origen))
            listaAdyacencia[origen] = new List<string>();

        listaAdyacencia[origen].Add(destino);
    }

    public void MostrarGrafo()
    {
        foreach (var nodo in listaAdyacencia)
        {
            Console.Write(nodo.Key + " -> ");
            foreach (var vecino in nodo.Value)
                Console.Write(vecino + " ");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Grafo g = new Grafo();

        g.AgregarArista("A", "B");
        g.AgregarArista("A", "C");
        g.AgregarArista("B", "D");
        g.AgregarArista("C", "D");

        g.MostrarGrafo();
    }
}