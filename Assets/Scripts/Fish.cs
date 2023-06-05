using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    [SerializeField] CameraMovement cam;
    Rigidbody2D rb;
    Vector2 move;

    public int buildindex = 1;
    private float speed = 600;
    float xAxs;

    bool isCrash;
    bool isFinish;

    public int reklamSayaci = 0;

    private void Awake()
    {
        reklamSayaci = PlayerPrefs.GetInt("sayac");
        isCrash = true;
        isFinish = true;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        QualitySettings.vSyncCount = 0;
    }

    private void Start()
    {
        buildindex = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        xAxs = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        move = new Vector2(xAxs, 1.5f);
    }
    private void FixedUpdate()
    {
        if (isFinish && isCrash)
        {
            rb.AddForce(move * speed * Time.deltaTime, ForceMode2D.Force);
        }
        else if (!isCrash && isFinish)
        {
            rb.AddForce(new Vector2(0, 0.75f) * speed * Time.deltaTime, ForceMode2D.Force);
            cam.isCamMove = false;
        }
        else
        {
            rb.AddForce(new Vector2(0, 8) * speed * Time.deltaTime, ForceMode2D.Force);
        }

        if (isCrash && isFinish)
        {
            if (xAxs < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), 0.04f);
            }
            else if (xAxs > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), 0.04f);
            }
            else if (xAxs == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
            }
        }
        else if (!isFinish)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "barrier")
        {
            isCrash = false;
            reklamSayaci++;
            PlayerPrefs.SetInt("sayac", reklamSayaci);
            StartCoroutine(bekletme());
        }

        if (other.gameObject.tag == "Finish")
        {
            cam.isCamMove = false;
            isFinish = false;
        }

        IEnumerator bekletme()
        {
            yield return new WaitForSecondsRealtime(1.1f);
            SceneManager.LoadScene(buildindex);
        }

        if (other.gameObject.tag == "newScene")
        {
            int saveindex = PlayerPrefs.GetInt("SaveIndex");
            if (buildindex >= saveindex)
            {
                PlayerPrefs.SetInt("SaveIndex", buildindex);
            }
            if (SceneManager.GetActiveScene().buildIndex < 20)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 20) //son level
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}