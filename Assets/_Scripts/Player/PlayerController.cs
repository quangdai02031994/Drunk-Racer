using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float _speed;
    public float _maxPosition;


    //Doan code duoi day la doan code test
    public float _translation;


    void Start()
    {

    }

    void Update()
    {

        #region Not Test here
        _maxPosition = GameController.Instance._maxPosition;
        CheckPosition();
        if (GameController.Instance._isPlaying)
        {

            transform.Translate(Input.acceleration.x * Time.deltaTime * _speed, 0, 0);
        }
        #endregion
       
        #region Test
        if (GameController.Instance._isPlaying)
        {
            _translation = Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
            transform.Translate(new Vector2(_translation, 0));
        }
        #endregion
    }

    private void CheckPosition()
    {
        if (transform.position.x > _maxPosition)
        {
            transform.position = new Vector3(_maxPosition, transform.position.y, 0);
        }
        else if (transform.position.x < -_maxPosition)
        {
            transform.position = new Vector3(-_maxPosition, transform.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tags.Barrier)
        {
            GameController.Instance.OnGameOver();
        }
        else if (other.gameObject.tag == Tags.Coin)
        {
            Debug.Log("Coin");
            Destroy(other.gameObject);
        }

        
    }

}
