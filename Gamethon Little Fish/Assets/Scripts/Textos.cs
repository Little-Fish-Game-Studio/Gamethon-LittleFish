using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Textos 
{

    public TextMeshProUGUI textoDinheiro;
    public TextMeshProUGUI textoDias;

    [Space][Header("templateEventos")] public Image ImagemEvento;
    public TextMeshProUGUI descricaoEvento, empresasAfetadas,descricaoEmpresa;
    public Image EventoAtivo1, EventoAtivo2;
    public GameObject imagemFundoEvento1;
   public GameObject ObjetoTemplateEventos;

    [Space] public GameObject CanvasGuildas;

    public TextMeshProUGUI IntroQuantidadeDeAcoesECusto, custoCompraAcoes, valorVendaAcoes, acoesSeleccionadas;

   // public 

    public void AtualizarEvento(Sprite imagem, string descricaoEvento, string empresasAfetadas)
    {
        this.ImagemEvento.sprite = imagem;
        this.descricaoEvento.text = descricaoEvento;
        this.empresasAfetadas.text = empresasAfetadas;
        EventoAtivo1.sprite = imagem;
        imagemFundoEvento1.SetActive(true);
        EventoAtivo1.gameObject.SetActive(true);
    }
    public void FinalizarEventos()
    {
        this.ImagemEvento.sprite = null;
        this.descricaoEvento.text = null;
        this.empresasAfetadas.text = null;
        EventoAtivo1.sprite = null;
        imagemFundoEvento1.SetActive(false);
        EventoAtivo1.gameObject.SetActive(false);
    }

    public void AtualizarIntroAcoes(int quantAcoes, float valor)
    {
        IntroQuantidadeDeAcoesECusto.text = "Voce possui " + quantAcoes + " acoes e atualmente custam " + (int)valor;
    }
    public void ValorComprarAcoes(int quantAcoes, float valor)
    {
        custoCompraAcoes.text = "Custo de " + (int)(valor*quantAcoes) + " para comprar";
    }
    public void ValorVenderAcoes(int quantAcoes, float valor)
    {
        valorVendaAcoes.text = "Ganho de " + (int)(valor * quantAcoes) + " por vender";
    }
}
