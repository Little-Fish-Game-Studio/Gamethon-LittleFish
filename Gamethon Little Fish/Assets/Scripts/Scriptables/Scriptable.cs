using outros;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Empresas", menuName = "ScriptableObjects/Empresas", order = 1)]
public class Scriptable : ScriptableObject
{
    public string nomeEmpresa;
    public Sprite ImagemEmpresa;
    [TextArea] public string descricao;
    public float tempoDeGiroDeA�oes;
    public float pre�oAcao;
    public float pre�oMinA�ao, pre�oMaxA�ao;
    public Tendencia tendencia;
}
