using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_UI : MonoBehaviour
{
    public GameObject Pm,pause_buton; // Pause Men?
    MainMenu meme;


    public void Start()
    {
        meme = GetComponent<MainMenu>();
        
    }
    public void Durdur()
    {
        pause_buton.SetActive(false);
        Pm.SetActive(true);
        Time.timeScale = 0f;
        
     
    }
    public void Baslat()
    {
        pause_buton.SetActive(true);
        Pm.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Level_Back()
    {
       
        SceneManager.LoadScene(0);
        

    }
         
    
}
