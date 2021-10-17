using outros;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptableReceiverEventos 
{
    [SerializeField]Eventos eventos;

   [SerializeField] Sprite imagemEvento;
    [SerializeField] string descricaoEvento;
    [SerializeField] List<AfetarEmpresas> afetarEmpresas;
    [SerializeField] bool eventoAtivo;
    [SerializeField] float tempoDuracao, tempoDuracaoMax;

    public bool EventoAtivo { get { return eventoAtivo; } }
    public List<AfetarEmpresas> AfetarEmpresas { get { return afetarEmpresas; } }
    public float TempoDuracao { get { return tempoDuracao; } }
    public float TempoDuracaoMax { get { return tempoDuracaoMax; } }
    public string DescricaoEvento { get { return descricaoEvento; }  }
    public Sprite ImagemEvento { get { return imagemEvento; }  }
    public void Start()
    {
        imagemEvento = eventos.ImagemEvento;
        descricaoEvento = eventos.descricaoEvento;
        afetarEmpresas = eventos.afetarEmpresas;
        tempoDuracao = eventos.tempoDuracao;
        tempoDuracaoMax = eventos.tempoDuracaoMax;
        
    }

    public void DiminuirTempo(float tempo, List<ScriptableReceiver> empresas)
    {
        tempoDuracao -= tempo;
        if(tempoDuracao<=0)
        {
            eventoAtivo = false;
            for (int i = 0; i < empresas.Count; i++)
            {
                empresas[i].Tendencia = Tendencia.Manter;
            }
            tempoDuracao = tempoDuracaoMax;
        }
    }

    internal void EventoEstaAtivo()
    {
        eventoAtivo = true;

    }
}
