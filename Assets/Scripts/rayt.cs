using UnityEngine;

public class rayt : MonoBehaviour
{
    private Transform trans;
    private float a;
    private bool isRight = true;
    [SerializeField] private float negatifMesafe;
    [SerializeField] private float pozitifMesafe;
    [SerializeField] private float speed;


    private void Start()
    {
        trans = GetComponent<Transform>();
    }


    private void Update()
    {
        a = trans.position.x;
    }

    private void FixedUpdate()
    {

        Flip();
    }

    private void Flip()
    {
        if (isRight)
        {
            trans.position = new Vector3(trans.position.x + speed, trans.position.y, trans.position.z);
            if (a > pozitifMesafe)
            {
                isRight = false;
            }
        }
        else if (!isRight)
        {
            trans.position = new Vector3(trans.position.x - speed, trans.position.y, trans.position.z);
            if (a < negatifMesafe)
            {
                isRight = true;
            }
        }
    }

}