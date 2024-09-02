using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialMenu;
    public GameObject victoryMenu;
    public GameObject defeatMenu;
    public List<GameObject> Prender;
    public List<GameObject> Apagar;
    

    //carga la escena del juego
    public void StartBotton()
    {
        SceneManager.LoadScene(1);
    }
    //desactiva menu y va al tutorial
    public void TutorialBotton()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }
    //reinicia la escena del juego
    public void RetryBotton()
    {
        Time.timeScale = 1;
        victoryMenu.SetActive(false);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
    }
    public void VictoryScreen()
    {
        StartCoroutine(Delay());
        Time.timeScale = 0;
        victoryMenu.SetActive(true);
    }
    public void DefeatScreen()
    {
        StartCoroutine(Delay());
        Time.timeScale = 0;
        defeatMenu.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }




    
    ///////////////////////////////////////////-------------------
    
    public void Jugar()
    {
        mainMenu.SetActive(false);
        for (int i = 0; i < Prender.Count; i++)
        {
            Prender[i].SetActive(true);
        }
        for (int i = 0; i < Apagar.Count; i++)
        {
            Apagar[i].SetActive(false);
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
    /*
    void OnCollisionEnter(Collision Presion)
    {
        if (Presion.gameObject.tag == "jugarB")
        {
            Jugar();
        }
        if (Presion.gameObject.tag == "salirB")
        {
            Salir();
        }
    }
    */
}
