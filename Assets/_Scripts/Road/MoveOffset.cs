using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

    public Renderer rend;
    private float offset;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (GameController.Instance._isPlaying)
        {
            offset = GameController.Instance._scrollBackGround * Time.time;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }



}
