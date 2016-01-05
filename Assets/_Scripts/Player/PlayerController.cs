using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera _mainCamera;


    public float _speed;
    public float _maxPosition;

    void Start()
    {
        _maxPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - 0.93f;
    }

    void Update()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * _speed, 0, 0);

        if (transform.position.x > _maxPosition)
        {
            transform.position = new Vector3(_maxPosition, transform.position.y, 0);
        }
        else if(transform.position.x < -_maxPosition)
        {
            transform.position = new Vector3(-_maxPosition, transform.position.y, 0);
        }
        
    }

}
