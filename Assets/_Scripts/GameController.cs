using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public Camera _mainCamera;

    public Transform Barrel;


    public bool _isPlaying;

    public float _maxSpeed;

    public float _scrollBackGround;
    public float _maxPosition;
    public float _speedMoveBarrier;


    //test
    public Vector3 leftRay;
    public Vector3 rightRay;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _maxPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - 0.93f;
    }


    void Update()
    {
        if (_isPlaying)
        {
            //do somethings when game is playing
            if (_speedMoveBarrier < _maxSpeed)
                _speedMoveBarrier += Time.deltaTime * 0.1f;
        }

    }


    public void OnGameOver()
    {
        if (_isPlaying)
        {
            //Debug.Log(Barrel.GetComponent<BarrierGenerate>().i);
            _isPlaying = false;
        }
    }

    public void OnPlayGame()
    {
        _isPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnRestartGame()
    {
        if (!_isPlaying)
        {
            //Barrel.GetComponent<BarrierGenerate>().Restart();
            var children = new List<GameObject>();
            foreach (Transform child in Barrel) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
            
        }
    }


    void OnDrawGizmos()
    {
        Debug.DrawRay(leftRay, Vector3.down * 1000, Color.red);
        Debug.DrawRay(rightRay, Vector3.down * 1000, Color.white);
    }


}
