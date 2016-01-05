using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour {

    public Renderer rend;

    public float _scrollSpeed;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = _scrollSpeed * Time.time;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }



}
