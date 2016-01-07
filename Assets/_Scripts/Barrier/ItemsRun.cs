using UnityEngine;
using System.Collections;

public class ItemsRun : MonoBehaviour
{


    public float speed;

    void Start()
    {
        speed = GameController.Instance._speedMoveBarrier;
    }

    void Update()
    {
        speed = GameController.Instance._speedMoveBarrier;
        if (GameController.Instance._isPlaying)
            transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

}