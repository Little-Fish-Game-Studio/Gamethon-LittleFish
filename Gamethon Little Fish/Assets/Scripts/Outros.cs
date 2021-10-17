using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outros
{
    public enum Tendencia
    {
        Alta,
        Manter,
        Baixa
    }
    [System.Serializable]
public class AfetarEmpresas
    {
        public string empresaAfetada;
        public Tendencia tendencia;

    }
}

