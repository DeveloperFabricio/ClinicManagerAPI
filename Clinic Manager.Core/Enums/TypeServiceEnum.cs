using System.ComponentModel;

namespace ClinicManagerAPI.Enums
{
    public enum TypeServiceEnum
    {
        [Description("Atestado")]
        Atestado = 1,
        [Description("Receita")]
        Receita = 2,
        [Description("Evolução")]
        Evolução = 3

    }
}
