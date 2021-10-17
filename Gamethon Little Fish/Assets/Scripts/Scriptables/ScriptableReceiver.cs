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
    [SerializeField] float tempoDeGiroDeAçoes, count;
    [SerializeField] float preçoAcao;
    [SerializeField] float preçoMinAçao, preçoMaxAçao;
    [SerializeField] Tendencia tendencia;

    public float Count { get { return count; }  }
    public float PreçoAcao { get { return preçoAcao; } }
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
        tempoDeGiroDeAçoes = Empresas.tempoDeGiroDeAçoes;
        preçoAcao = Empresas.preçoAcao;
        preçoMinAçao = Empresas.preçoMinAçao;
        preçoMaxAçao = Empresas.preçoMaxAçao;
        tendencia = Empresas.tendencia;
        Barra.maxValue = Empresas.preçoMaxAçao*2;
        Barra.minValue = Empresas.preçoMinAçao;
        EmpresaMapa.name = nomeEmpresa;
        imagemEmpresa = Empresas.ImagemEmpresa;
        descricao = Empresas.descricao;
    }

    public void Atualizar()
    {
        count = tempoDeGiroDeAçoes;

        if(tendencia==Tendencia.Alta)
        {
            preçoAcao = Random.Range(preçoMinAçao*2, preçoMaxAçao*2);
        }
        else if(tendencia==Tendencia.Manter)
        {
            preçoAcao = Random.Range(preçoMinAçao, preçoMaxAçao);
        }
        else
        {
            preçoAcao = Random.Range(preçoMinAçao/2, preçoMaxAçao/2);
        }

        CreatePoint(tempoDeGiroDeAçoes, preçoAcao);
        //imagemEmpresa.sprite = Empresas.ImagemEmpresa;
    }

    private void CreatePoint(float x, float y)
    {
        if (sliderEmpresaAtiva)
        {
            preçoMinAçao = Empresas.preçoMinAçao;
            preçoMaxAçao = Empresas.preçoMaxAçao;
            Barra.maxValue = Empresas.preçoMaxAçao * 2;
            Barra.minValue = Empresas.preçoMinAçao / 2;


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
