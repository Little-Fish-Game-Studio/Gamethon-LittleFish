using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPontos : MonoBehaviour
{
   
 


  //  LineRenderer lineRenderer;
  
    [SerializeField] List<ScriptableReceiver> listaEmpresas;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            listaEmpresas[i].Start();
        }
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < listaEmpresas.Count; i++)
        {
            listaEmpresas[i].DiminuirTempo(Time.deltaTime);
            if (listaEmpresas[i].Count <= 0)
            {
                listaEmpresas[i].Atualizar();
                
            }
        }
    }



}
