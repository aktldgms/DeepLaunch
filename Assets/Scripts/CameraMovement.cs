using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 a;

    public bool isCamMove = true;


    void LateUpdate()
    {
        if (isCamMove)
        {
            a = new Vector3(0, target.transform.position.y + .75f, 0);
            transform.position = a;
        }
    }
}
