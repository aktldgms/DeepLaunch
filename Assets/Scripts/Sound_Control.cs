using UnityEngine;

public class Sound_Control : MonoBehaviour
{
    AudioSource Ses_k;
    void Start()
    {
        Ses_k = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 1)
        {
            Ses_k.mute = false;
        }
        else
        {
            Ses_k.mute = true;

        }
        if (PlayerPrefs.GetInt("lvldurum") == 1)
        {
            
        }
    }
}
