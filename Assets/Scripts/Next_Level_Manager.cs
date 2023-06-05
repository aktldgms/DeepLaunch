using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Next_Level_Manager : MonoBehaviour
{
    public List<Button> levelbuton;
    public TextMeshProUGUI lvltexti;
    public Sprite a;
    public bool delete;
    
    
    private void Start()
    {
        
        if (delete)
        {
            PlayerPrefs.DeleteAll();
                 
        }

        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        print(saveIndex);
        for(int i=0; i < levelbuton.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelbuton[i].interactable = true;
            }
            else
            {
                levelbuton[i].image.sprite =a;
                levelbuton[i].interactable = false;
            }
        }
    }

    public void Levelegir(int level_index)
    {
            SceneManager.LoadScene("level_" + level_index);
            Time.timeScale = 1f;
    }
    
}
