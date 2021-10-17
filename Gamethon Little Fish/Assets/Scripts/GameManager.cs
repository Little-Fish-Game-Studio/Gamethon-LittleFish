using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int dinheiro;
    [SerializeField] int dias;
    [SerializeField] float tempoDias, tempoDiasMax;
    [SerializeField] bool pauseDias;
    [SerializeField] int acoesSelecionadas;

    [SerializeField] Textos textos;
    [SerializeField] List<ScriptableReceiverEventos> eventosPossiveis;
    [SerializeField] List<ScriptableReceiver> listaEmpresas;

    [SerializeField]List<string> empresasAfetadas;
    [SerializeField] Image imagemEmpresaSelecionada;
    [SerializeField] AudioClip[] eventClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textos.textoDinheiro.text = " " + dinheiro;
        textos.textoDias.text = "Dias: " + dias;

        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            listaEmpresas[i].Start();
        }
        for (int i = 0; i < eventosPossiveis.Count; i++)
        {
            eventosPossiveis[i].Start();
        }
    }

    void Update()
    {
        if(!pauseDias)
        {
            tempoDias -= Time.deltaTime;
            if(tempoDias<=0)
            {
                tempoDias = tempoDiasMax;
                dias++;
                textos.textoDias.text = "Dias: " + dias;

                int valor = Random.Range(0, eventosPossiveis.Count);
                eventosPossiveis[valor].EventoEstaAtivo();
                audioSource.clip = eventClips[Random.Range(0, eventClips.Length)];
                audioSource.Play();
            }
            for (int i = 0; i < eventosPossiveis.Count; i++)
            {
                if (eventosPossiveis[i].EventoAtivo)
                {
                    if (eventosPossiveis[i].TempoDuracao == eventosPossiveis[i].TempoDuracaoMax)
                    {
                        string temp = "";
                        empresasAfetadas = new List<string>();
                        for (int j = 0; j < eventosPossiveis[i].AfetarEmpresas.Count; j++)
                        {
                             temp += eventosPossiveis[i].AfetarEmpresas[j].empresaAfetada + " - " + eventosPossiveis[i].AfetarEmpresas[j].tendencia.ToString() + "\n";
                            for (int k = 0; k < listaEmpresas.Count; k++)
                            {
                                if (eventosPossiveis[i].AfetarEmpresas[j].empresaAfetada == listaEmpresas[k].NomeEmpresa)
                                {
                                    listaEmpresas[k].AtualizarTendencia(eventosPossiveis[i].AfetarEmpresas[j].tendencia);
                                    empresasAfetadas.Add(listaEmpresas[k].NomeEmpresa);


                                    textos.AtualizarEvento(eventosPossiveis[i].ImagemEvento, eventosPossiveis[i].DescricaoEvento, temp);
                                }
                            }

                        }
                    }
                    eventosPossiveis[i].DiminuirTempo(Time.deltaTime, listaEmpresas);
               /*     for (int j = 0; j < empresasAfetadas.Count; j++)
                    {
                        for (int k = 0; k < listaEmpresas.Count; k++)
                        {
                            if (listaEmpresas[k].NomeEmpresa == empresasAfetadas[j])
                            {
                                listaEmpresas[k].AtualizarTendencia(outros.Tendencia.Manter);
                            }
                        }

                    }*/
                }
                else
                {
                    textos.FinalizarEventos();
                }
            }

            for (int i = 0; i < listaEmpresas.Count; i++)
            {
                listaEmpresas[i].DiminuirTempo(Time.deltaTime);
                if (listaEmpresas[i].Count <= 0)
                {
                    listaEmpresas[i].Atualizar();
                    
                    if(listaEmpresas[i].SliderEmpresaAtiva)
                    {
                        textos.AtualizarIntroAcoes(listaEmpresas[i].AcoesCompradas,listaEmpresas[i].PreçoAcao);
                        textos.ValorComprarAcoes(acoesSelecionadas, listaEmpresas[i].PreçoAcao);
                        textos.ValorVenderAcoes(acoesSelecionadas, listaEmpresas[i].PreçoAcao);
                    }

                }
            }
        }


    }
    // Update is called once per frame
    public void EventoSelecionado()
    {
        textos.ObjetoTemplateEventos.SetActive(true);
        pauseDias = true;
        // textos.AtualizarEvento();
        print("Click");
    }
    public void FecharEPausar()
    {
        pauseDias = true;
        for (int i = 0; i < listaEmpresas.Count; i++)
        {

            listaEmpresas[i].SliderEmpresaAtiva = false;
            
        }
    }

    public void HabilitarTempo(string nome)
    {
        pauseDias = false;
        textos.CanvasGuildas.SetActive(true);
        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            if (nome == listaEmpresas[i].NomeEmpresa)
            {
                listaEmpresas[i].SliderEmpresaAtiva = true;
                imagemEmpresaSelecionada.sprite = listaEmpresas[i].ImagemSelecionada;
                textos.descricaoEmpresa.text = listaEmpresas[i].Descricao;
                listaEmpresas[i].Start();
                break;
            }
            else
            {
                listaEmpresas[i].SliderEmpresaAtiva = false;
            }
        }
    }

    public void ComprarAcoes()
    {
        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            if (listaEmpresas[i].SliderEmpresaAtiva == true)
            {
                if(dinheiro>=listaEmpresas[i].PreçoAcao * acoesSelecionadas)
                {
                    
                    dinheiro -= (int)(listaEmpresas[i].PreçoAcao * acoesSelecionadas);
                    listaEmpresas[i].AcoesCompradas += acoesSelecionadas;
                    textos.textoDinheiro.text = " " + dinheiro;
                    break;
                }
              
            }

        }
    }
    public void VenderAcoes()
    {
        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            if (listaEmpresas[i].SliderEmpresaAtiva == true)
            {
                if (listaEmpresas[i].AcoesCompradas>=acoesSelecionadas)
                {
                    //print("Acoes vendidas");
                    
                    dinheiro += (int)(listaEmpresas[i].PreçoAcao * acoesSelecionadas);
                    listaEmpresas[i].AcoesCompradas -= acoesSelecionadas;
                    textos.textoDinheiro.text = " " + dinheiro;
                    break;
                }

            }

        }
    }
    public void BotaoMais()
    {
        acoesSelecionadas++;
        textos.acoesSeleccionadas.text = acoesSelecionadas + "";
    }
    public void BotaoMenos()
    {
        acoesSelecionadas--;
        textos.acoesSeleccionadas.text = acoesSelecionadas + "";
    }
}
