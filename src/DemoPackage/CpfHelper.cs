using DemoPackage.Extensions;

namespace DemoPackage;

/// <summary>
/// This class provides validation for CPF numbers
/// </summary>
public sealed class CpfHelper
{
    /// <summary>
    /// This method validates if the text passed as an argument corresponds to a valid CPF number
    /// </summary>
    /// <param name="text">CPF number to be validated</param>
    /// <returns>A boolean indicating the validation result</returns>
    public static bool IsValid(string text)
    {
        text = text.Clear();

        if (text.Length > 11)
            return false;

        while (text.Length != 11)
            text = '0' + text;

        var igual = true;
        for (var i = 1; i < 11 && igual; i++)
        {
            if (text[i] != text[0])
                igual = false;
        }

        if (igual || text == "12345678909")
            return false;

        var numeros = new int[11];

        for (var i = 0; i < 11; i++)
            numeros[i] = int.Parse(text[i].ToString());

        var soma = 0;
        for (var i = 0; i < 9; i++)
            soma += (10 - i) * numeros[i];

        var resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[9] != 0)
                return false;
        }
        else if (numeros[9] != 11 - resultado)
            return false;

        soma = 0;
        for (var i = 0; i < 10; i++)
            soma += (11 - i) * numeros[i];

        resultado = soma % 11;

        if (resultado == 1 || resultado == 0)
        {
            if (numeros[10] != 0)
                return false;
        }
        else if (numeros[10] != 11 - resultado)
            return false;

        return true;
    }
}
