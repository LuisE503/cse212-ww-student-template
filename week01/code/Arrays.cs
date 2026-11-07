using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        /*
        PLAN:
        1. Crear un nuevo arreglo de tipo double con el tamaño especificado por el parámetro 'length'.
        2. Usar un ciclo for que itere desde 0 hasta 'length - 1'.
        3. En cada iteración, calcular el múltiplo multiplicando el 'number' original por (i + 1) para evitar multiplicar por 0.
        4. Asignar el resultado calculado a la posición actual 'i' del arreglo.
        5. Retornar el arreglo completamente lleno.
        */

        double[] multiples = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is {1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3,
    /// the list after the function runs should be {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /*
        PLAN:
        1. Determinar el índice donde se dividirá la lista. Como rotamos a la derecha por 'amount', 
           necesitamos tomar los últimos 'amount' elementos. El índice de corte es (data.Count - amount).
        2. Extraer esos últimos 'amount' elementos de la lista usando el método GetRange() y guardarlos en una lista temporal.
        3. Eliminar esos mismos elementos del final de la lista original usando RemoveRange() para evitar duplicados.
        4. Insertar los elementos de la lista temporal al principio de la lista original (en el índice 0) 
           usando InsertRange() para completar la rotación modificando la lista existente.
        */

        int splitIndex = data.Count - amount;

        // Extraer la parte final que se va a mover al frente
        List<int> tail = data.GetRange(splitIndex, amount);
        
        // Eliminar la parte final de la lista original
        data.RemoveRange(splitIndex, amount);
        
        // Insertar la parte extraída al inicio de la lista
        data.InsertRange(0, tail);
    }
}