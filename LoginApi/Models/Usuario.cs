using System;
using System.Collections.Generic;

namespace LoginApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nickname { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}
