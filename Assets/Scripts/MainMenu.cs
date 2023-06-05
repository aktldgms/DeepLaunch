using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ses_acik, ses_kapali,LvlMenü,background;

    private void Start()
    {
        PlayerPrefs.SetInt("sayac", 0);
    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 1)
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
        }
        else
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
        }
    }

    public void Ses_Durum(string durum)
    {
        if (durum=="acık") //Ses kapama
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            PlayerPrefs.SetInt("sesdurum", 0);


        }
        else if (durum =="kapali")  //Ses açma
        {
           ses_acik.SetActive(true);
           ses_kapali.SetActive(false);
            PlayerPrefs.SetInt("sesdurum", 1);
        }
  
  }
   
    public void Levelpanel()
    {
       background.SetActive(false);
       LvlMenü.SetActive(true);
    }

    public void Contest()
    {
        SceneManager.LoadScene(21);
    }

    
}
