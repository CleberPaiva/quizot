using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temaInfo : MonoBehaviour{

    private temaScene temaScene;

    [Header("Configuração do Tema")]
    public int idTema;
    public string nomeTema;
    public Color corTema;

    [Header("Configuração das Estrelas")]
    public int notaMin1Estrela;
    public int notaMin2Estrela;



    [Header("Configuração do Botão")]
    public Text idTemaTXT;
    public GameObject[] estrela;

    private int notaFinal;


    void Start (){

        notaFinal = PlayerPrefs.GetInt("notaFinal_" + idTema.ToString());

        temaScene = FindObjectOfType(typeof(temaScene)) as temaScene;

        idTemaTXT.text = idTema.ToString();

        estrelas(); // CHAMA O MÉTODO ESTRELAS QUE CALCULA QUANTAS ESTRELAS GANHAMOS

    }

    public void selecionarTema() 
    {

        temaScene.nomeTemaTxt.text = nomeTema;
        temaScene.nomeTemaTxt.color = corTema;

        PlayerPrefs.SetInt("idTema", idTema);
        PlayerPrefs.SetString("nomeTema", nomeTema);
        PlayerPrefs.SetInt("notaMin1Estrela", notaMin1Estrela);
        PlayerPrefs.SetInt("notaMin2Estrela", notaMin2Estrela);

        temaScene.btnJogar.interactable = true;

    }
   
   public void estrelas()
   {
       foreach(GameObject e in estrela)
        {
            e.SetActive(false);
        }

        int nEstrelas = 0;

        if(notaFinal == 10) { nEstrelas = 3;}
        else if(notaFinal >= notaMin2Estrela) { nEstrelas = 2;}
        else if(notaFinal >= notaMin1Estrela) { nEstrelas = 1;}

        for(int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }

   }

}
