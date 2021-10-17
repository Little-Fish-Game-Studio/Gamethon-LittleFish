using outros;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScriptableReceiver 
{
    [SerializeField] string nomeEmpresa;
    [SerializeField] Scriptable Empresas;
    [SerializeField] GameObject EmpresaMapa;
    [SerializeField] Sprite imagemEmpresa;
    [SerializeField] float tempoDeGiroDeA�oes, count;
    [SerializeField] float pre�oAcao;
    [SerializeField] float pre�oMinA�ao, pre�oMaxA�ao;
    [SerializeField] Tendencia tendencia;

    public float Count { get { return count; }  }
    public float Pre�oAcao { get { return pre�oAcao; } }
    public string NomeEmpresa { get { return nomeEmpresa; } }
    // [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Slider Barra;
    [SerializeField] int acoesCompradas;
    [SerializeField] bool sliderEmpresaAtiva;
    [SerializeField] string descricao;
    public string Descricao { get { return descricao; } }
    public bool SliderEmpresaAtiva { get { return sliderEmpresaAtiva; } set { sliderEmpresaAtiva = value; }  }
    public int AcoesCompradas { get { return acoesCompradas; } set { acoesCompradas = value; } }
    public Tendencia Tendencia { get { return tendencia; } set { tendencia = value; } }

    public Sprite ImagemSelecionada { get { return imagemEmpresa; }  }
    // [SerializeField] List<GameObject> listaPontos;
    // [SerializeField] int pontosAdicionados;
    public void Start()
    {
        //Debug.Log(Empresas.nomeEmpresa);
        nomeEmpresa = Empresas.nomeEmpresa;
        tempoDeGiroDeA�oes = Empresas.tempoDeGiroDeA�oes;
        pre�oAcao = Empresas.pre�oAcao;
        pre�oMinA�ao = Empresas.pre�oMinA�ao;
        pre�oMaxA�ao = Empresas.pre�oMaxA�ao;
        tendencia = Empresas.tendencia;
        Barra.maxValue = Empresas.pre�oMaxA�ao*2;
        Barra.minValue = Empresas.pre�oMinA�ao;
        EmpresaMapa.name = nomeEmpresa;
        imagemEmpresa = Empresas.ImagemEmpresa;
        descricao = Empresas.descricao;
    }

    public void Atualizar()
    {
        count = tempoDeGiroDeA�oes;

        if(tendencia==Tendencia.Alta)
        {
            pre�oAcao = Random.Range(pre�oMinA�ao*2, pre�oMaxA�ao*2);
        }
        else if(tendencia==Tendencia.Manter)
        {
            pre�oAcao = Random.Range(pre�oMinA�ao, pre�oMaxA�ao);
        }
        else
        {
            pre�oAcao = Random.Range(pre�oMinA�ao/2, pre�oMaxA�ao/2);
        }

        CreatePoint(tempoDeGiroDeA�oes, pre�oAcao);
        //imagemEmpresa.sprite = Empresas.ImagemEmpresa;
    }

    private void CreatePoint(float x, float y)
    {
        if (sliderEmpresaAtiva)
        {
            pre�oMinA�ao = Empresas.pre�oMinA�ao;
            pre�oMaxA�ao = Empresas.pre�oMaxA�ao;
            Barra.maxValue = Empresas.pre�oMaxA�ao * 2;
            Barra.minValue = Empresas.pre�oMinA�ao / 2;


            Barra.value = y;
        }
    }



    public void DiminuirTempo(float tempo)
    {
        count -= tempo;
        
    }
    public void AtualizarTendencia(Tendencia t)
    {
        tendencia = t;
    }
}
