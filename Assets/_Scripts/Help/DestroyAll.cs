using UnityEngine;
using System.Collections;

public class DestroyAll : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tags.Barrier)
        {
            Destroy(other.gameObject);
        }
    }
}
