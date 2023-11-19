using System.Text.RegularExpressions;

namespace APIAdoPet.Utils;

public static class FormatUtil
{
    public static string RetirarCaracteresEspecias(string textoFormatar)
    {
        string ret = string.Empty;
        string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\\s]";
        Regex regex = new(pattern);
        ret = regex.Replace(textoFormatar, ret);
        return ret;
    }
}
