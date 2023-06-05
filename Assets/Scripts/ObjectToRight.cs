using UnityEngine;

public class ObjectToRight : MonoBehaviour
{
    Transform trans;
    float a;
    bool isRight = true;

    void Start()
    {
        trans = GetComponent<Transform>();
    }


    void Update()
    {
        a = trans.position.x;
    }

    private void FixedUpdate()
    {

        Flip();
    }

    public void Flip()
    {
        if (isRight)
        {
            trans.position = new Vector3(trans.position.x + 0.015f, trans.position.y, trans.position.z);
            if (a > 0.9f)
            {
                isRight = false;
            }
        }
        else if (!isRight)
        {
            trans.position = new Vector3(trans.position.x - 0.015f, trans.position.y, trans.position.z);
            if (a < -0.9f)
            {
                isRight = true;
            }
        }
    }

}