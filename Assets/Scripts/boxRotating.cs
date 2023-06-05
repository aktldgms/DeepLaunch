using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxRotating : MonoBehaviour
{
    [SerializeField] private Transform Circle;
    [SerializeField] private float speed;

    private void Update()
    {
        RotatingBox();
    }
    public void RotatingBox()
    {
        //Circle.Rotate(new Vector3(0, 0,Time.deltaTime*speed));

        transform.RotateAround(Circle.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
    }
}
