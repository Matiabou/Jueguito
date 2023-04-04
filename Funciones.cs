public static class Funciones
{
    public static string IngresarTexto(string msj)
    {
        string texto = "";
        while (texto == "")
        {
            Console.Write(msj);
            texto = Console.ReadLine();
        }
        return texto;
    }
    public static int IngresarEntero(string msj)
    {
        int entero=-1;
        while (entero == -1)
        {   
            Console.WriteLine(msj);
            int.TryParse(Console.ReadLine(), out entero);
        }
        Console.Clear();
        return entero;
    }

    public static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
    {
        int entero;
        entero = IngresarEntero(msj);
        while (entero < minimo || entero > maximo)
        {
            entero = IngresarEntero("ERROR! " + msj);
        }
        Console.Clear();
        return entero;
    }

    public static DateTime IngresarFecha(string msj)
    {
        DateTime fechaDate;
        string fechaCadena = IngresarTexto(msj);
        while (!DateTime.TryParse(fechaCadena, out fechaDate))
        {
            fechaCadena = IngresarTexto("ERROR! " + msj);
        }
        return fechaDate;
    }

    public static void Resize<T>(this List<T> list, int size, T element = default(T))
    {
        int count = list.Count;

        if (size < count)
        {
            list.RemoveRange(size, count - size);
        }
        else if (size > count)
        {
            if (size > list.Capacity)
                list.Capacity = size;

            list.AddRange(Enumerable.Repeat(element, size - count));
        }
    }

    public static void presionarTecla()
{
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}
}