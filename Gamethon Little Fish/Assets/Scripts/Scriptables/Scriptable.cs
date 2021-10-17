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
    public float tempoDeGiroDeAçoes;
    public float preçoAcao;
    public float preçoMinAçao, preçoMaxAçao;
    public Tendencia tendencia;
}
