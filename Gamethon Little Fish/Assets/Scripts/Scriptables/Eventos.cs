using outros;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Eventos", menuName = "ScriptableObjects/Eventos", order = 1)]
public class Eventos : ScriptableObject
{
    public Sprite ImagemEvento;
    public string descricaoEvento;
    public List<AfetarEmpresas> afetarEmpresas;
   public float tempoDuracao, tempoDuracaoMax;

}