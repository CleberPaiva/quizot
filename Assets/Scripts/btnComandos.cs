using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnComandos : MonoBehaviour {
    //CARREGA  NOVA CENA
   public void irParaCena(string nomeCena)
   {
       SceneManager.LoadScene(nomeCena);
   }

    // FECHA O APLICATIVO (SÓ FUNCIONA PARA MOBILI E PC)
    public void sair()
    {
        Application.Quit();
    }

    public void jogarNovamente()
    {
        int idCena = PlayerPrefs.GetInt("idTema");
        if(idCena != 0)
        {
            SceneManager.LoadScene(idCena.ToString());
        }
    }

}
