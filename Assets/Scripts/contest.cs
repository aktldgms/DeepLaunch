using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contest : MonoBehaviour
{
    [SerializeField] private GameObject objects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "contest_finish")
        {
            objects.transform.position += new Vector3(objects.transform.position.x, objects.transform.position.y + 648f, objects.transform.position.z);
        }
    }
}
