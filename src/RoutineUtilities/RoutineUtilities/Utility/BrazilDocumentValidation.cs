namespace RoutineUtilities.Utility;

/// <summary>
/// Provides methods for validating various brazilian document formats such as CPF, CNPJ, and PIS.
/// </summary>
public static partial class BrazilDocumentValidation
{
    #region Regex

    /// <summary>
    /// Regular expression to validate CPF format (11 digits).
    /// </summary>
    [GeneratedRegex(@"^\d{11}$")]
    private static partial Regex CPFRegex();

    /// <summary>
    /// Regular expression to validate CNPJ format (14 digits).
    /// </summary>
    [GeneratedRegex(@"^\d{14}$")]
    private static partial Regex CNPJRegex();

    /// <summary>
    /// Regular expression to validate PIS format (11 digits).
    /// </summary>
    [GeneratedRegex(@"^\d{11}$")]
    private static partial Regex PISRegex();

    #endregion Regex

    #region Validates

    /// <summary>
    /// Validates a CPF (Brazilian individual taxpayer registry identification).
    /// </summary>
    /// <param name="cpf">The CPF string to validate.</param>
    /// <returns>A <see cref="DocumentValidationResponse"/> indicating whether the CPF is valid, invalid, or the wrong size.</returns>
    public static DocumentValidationResponse ValidatesCPF(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            return DocumentValidationResponse.Invalid;

        cpf = cpf.ClearSymbols();
        if (cpf.Length != 11 || !CPFRegex().IsMatch(cpf))
            return DocumentValidationResponse.WrongSize;

        int[] multiplicadoresPrimeiroDigito = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicadoresSegundoDigito = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
        string digitoTemporario, digitoFinal;
        int somaDigito, resto;

        digitoTemporario = cpf[..9];
        somaDigito = 0;

        for (int i = 0; i < 9; i++)
            somaDigito += int.Parse(digitoTemporario[i].ToString()) * multiplicadoresPrimeiroDigito[i];

        resto = somaDigito % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digitoFinal = resto.ToString();
        digitoTemporario += digitoFinal;
        somaDigito = 0;

        for (int i = 0; i < 10; i++)
            somaDigito += int.Parse(digitoTemporario[i].ToString()) * multiplicadoresSegundoDigito[i];

        resto = somaDigito % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digitoFinal += resto.ToString();
        return cpf.EndsWith(digitoFinal) ? DocumentValidationResponse.Valid : DocumentValidationResponse.Invalid;

    }

    /// <summary>
    /// Validates a CNPJ (Brazilian National Registry of Legal Entities).
    /// </summary>
    /// <param name="cnpj">The CNPJ string to validate.</param>
    /// <returns>A <see cref="DocumentValidationResponse"/> indicating whether the CNPJ is valid, invalid, or the wrong size.</returns>
    public static DocumentValidationResponse ValidatesCNPJ(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
            return DocumentValidationResponse.Invalid;

        cnpj = cnpj.ClearSymbols();
        if (cnpj.Length != 14 || !CNPJRegex().IsMatch(cnpj))
            return DocumentValidationResponse.WrongSize;

        int[] multiplicadoresPrimeiroDigito = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicadoresSegundoDigito = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        string digitoFinal, digitoTemporario;
        int somaDigito, resto;

        digitoTemporario = cnpj[..12];
        somaDigito = 0;

        for (int i = 0; i < 12; i++)
            somaDigito += int.Parse(digitoTemporario[i].ToString()) * multiplicadoresPrimeiroDigito[i];

        resto = (somaDigito % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digitoFinal = resto.ToString();
        digitoTemporario += digitoFinal;
        somaDigito = 0;

        for (int i = 0; i < 13; i++)
            somaDigito += int.Parse(digitoTemporario[i].ToString()) * multiplicadoresSegundoDigito[i];

        resto = (somaDigito % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digitoFinal += resto.ToString();
        return cnpj.EndsWith(digitoFinal) ? DocumentValidationResponse.Valid : DocumentValidationResponse.Invalid;
    }

    /// <summary>
    /// Validates a PIS (Brazilian Social Integration Program) number.
    /// </summary>
    /// <param name="pis">The PIS string to validate.</param>
    /// <returns>A <see cref="DocumentValidationResponse"/> indicating whether the PIS is valid, invalid, or the wrong size.</returns>
    public static DocumentValidationResponse ValidatesPIS(string pis)
    {
        if (string.IsNullOrEmpty(pis))
            return DocumentValidationResponse.Invalid;

        pis = pis.ClearSymbols();
        if (pis.Length != 11 || !PISRegex().IsMatch(pis))
            return DocumentValidationResponse.WrongSize;

        int[] multiplicadores = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int somaDigito, resto;

        pis = pis.Trim().Replace("-", "").Replace(".", "").PadLeft(11, '0');
        somaDigito = 0;

        for (int i = 0; i < 10; i++)
            somaDigito += int.Parse(pis[i].ToString()) * multiplicadores[i];

        resto = somaDigito % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        return pis.EndsWith(resto.ToString()) ? DocumentValidationResponse.Valid : DocumentValidationResponse.Invalid;
    }

    #endregion Validates

    #region Bool Validates

    /// <summary>
    /// Checks if a CPF (Brazilian individual taxpayer registry identification) is valid.
    /// </summary>
    /// <param name="cpf">The CPF string to validate.</param>
    /// <returns>True if the CPF is valid; otherwise, false.</returns>
    public static bool IsCPFValid(this string cpf) => ValidatesCPF(cpf) == DocumentValidationResponse.Valid;

    /// <summary>
    /// Checks if a CNPJ (Brazilian National Registry of Legal Entities) is valid.
    /// </summary>
    /// <param name="cnpj">The CNPJ string to validate.</param>
    /// <returns>True if the CNPJ is valid; otherwise, false.</returns>
    public static bool IsCNPJValid(this string cnpj) => ValidatesCNPJ(cnpj) == DocumentValidationResponse.Valid;

    /// <summary>
    /// Checks if a PIS (Brazilian Social Integration Program) number is valid.
    /// </summary>
    /// <param name="pis">The PIS string to validate.</param>
    /// <returns>True if the PIS is valid; otherwise, false.</returns>
    public static bool IsPISValid(this string pis) => ValidatesPIS(pis) == DocumentValidationResponse.Valid;

    #endregion Bool Validates
}
