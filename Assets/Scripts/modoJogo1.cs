using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modoJogo1 : MonoBehaviour {

    [Header("Configuração dos Textos")]
    public Text nomeTemaTxt;
    public Text perguntaTxt;
    public Text infoRespostasTxt;
    public Text notaFinalTxt;
    public Text msg1Txt;
    public Text msg2Txt;


    [Header("Configuração das Barras")]
    public GameObject barraProgresso;
    public GameObject barraTempo;


    [Header("Configuração do Modo de Jogo")]
    public bool perguntasAleatorias;
    public bool jogarComTempo;
    public float tempoResponder;


    [Header("Configuração dos Botões")]
    public Button[] botoes;


    [Header("Configuração das Perguntas")]
    public string[] perguntas;
    public string[] correta;


    [Header("Configuração dos Painéis")]
    public GameObject[] paineis;
    public GameObject[] estrela;

    [Header("Configuração das Mensagens")]
    public string[] mensagem1;
    public string[] mensagem2;
    public Color[] corMensagem;

    // ----------------------------

    private int idResponder;
    private int idTema;
    private float qtdRespondidas;
    private float percProgresso;
    private int nEstrelas;
    private float percTempo;
    private float tempTime;

    public int notaMin1Estrela;
    public int notaMin2Estrela;
    public float notaFinal;
    public float valorQuestao;
    public int qtdAcertos;

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        notaMin1Estrela = PlayerPrefs.GetInt("notaMin1Estrela");
        notaMin2Estrela = PlayerPrefs.GetInt("notaMin2Estrela");

        nomeTemaTxt.text = PlayerPrefs.GetString("nomeTema");

        barraTempo.SetActive(false);

        montarListaPerguntas();
        progressaoBarra();
        controleBarraTempo();

        valorQuestao = 10 / (float)perguntas.Length;

       paineis[0].SetActive(true);
       paineis[1].SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(jogarComTempo == true)
        {
            tempTime += Time.deltaTime;
            controleBarraTempo();

            if(tempTime >= tempoResponder) { proximaPergunta(); }
        }
    }

    public void montarListaPerguntas()
    {
        perguntaTxt.text = perguntas[idResponder];
    }

    public void responder(string alternativa)
    {
       if(correta[idResponder] == alternativa)
       {
           print("Acertou !");
           qtdAcertos += 1;
       }
       else
       {
           print("Errou !");
       }

       
       proximaPergunta();

    }

    public void proximaPergunta()
    {
        idResponder += 1;
        tempTime = 0;

        qtdRespondidas += 1; 
        progressaoBarra();

        if(idResponder < perguntas.Length)
        {           
        perguntaTxt.text = perguntas[idResponder];
        }
        else
        {
        calcularNotaFinal();
        }
    }

    void progressaoBarra()
    {
        infoRespostasTxt.text = "Respondeu pergunta " + qtdRespondidas + " de " + perguntas.Length + " perguntas.";
        percProgresso = qtdRespondidas / perguntas.Length;
        barraProgresso.transform.localScale = new Vector3(percProgresso, 1, 1);
    }

    void controleBarraTempo()
    {
         if(jogarComTempo == true) { barraTempo.SetActive(true); }
            percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;

            if(percTempo < 0) { percTempo = 0; }

            barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);
        
        
    }

    void calcularNotaFinal()
    {
        notaFinal = Mathf.RoundToInt(valorQuestao * qtdAcertos);

        if(notaFinal > PlayerPrefs.GetInt("notaFinal_" + idTema.ToString()))
        {
            PlayerPrefs.SetInt("notaFinal_" + idTema.ToString(), (int)notaFinal);
        }

        if(notaFinal == 10) { nEstrelas = 3;}
        else if(notaFinal >= notaMin2Estrela) { nEstrelas = 2;}
        else if(notaFinal >= notaMin1Estrela) { nEstrelas = 1;}

        notaFinalTxt.text = notaFinal.ToString();
        notaFinalTxt.color = corMensagem[nEstrelas];    

        msg1Txt.text = mensagem1[nEstrelas];
        msg1Txt.color = corMensagem[nEstrelas];

        msg2Txt.text = mensagem2[nEstrelas];

        foreach(GameObject e in estrela)
        {
            e.SetActive(false);
        }

        for(int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }

        paineis[0].SetActive(false);
        paineis[1].SetActive(true);
    }
}
