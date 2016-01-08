using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrierGenerate : MonoBehaviour
{

    public GameObject barrel;
    public GameObject alert;
    public GameObject coin;

    public int numberGenerate;

    public List<Vector3> _listPosition;

    public float _countTime;
    public float _rateTime;
    public float _bigDistance = 2.5f;
    public float _smallDistance = 1;
    public float _yPosition;


    public float _minHeight;
    public float _maxHeight;

    public float _minPosition;
    public float _maxPosition;

    private int i;

    void Start()
    {
        _maxPosition = GameController.Instance._maxPosition;
        _minPosition = -_maxPosition;
    }

    void Update()
    {
        if (GameController.Instance._isPlaying)
        {
            _countTime += Time.deltaTime;
            if (_countTime > _rateTime)
            {
                int rand = Random.Range(0, 10);
                if (rand == 0)
                {
                    CreateOneObject(_minPosition, _maxPosition);
                    //Debug.Log(rand);
                }
                else if(rand == 1)
                {
                    CreateTwoObject(_minPosition, _maxPosition, _bigDistance);
                    //Debug.Log(rand);
                }
                else if(rand == 2)
                {
                    CreateTwoObject(_minPosition, _maxPosition, _smallDistance);
                }
                else if(rand == 3)
                {
                    CreateThreeObject(_minPosition, _maxPosition, _bigDistance, _smallDistance);
                }
                else if (rand == 4)
                {
                    CreateThreeObject(_minPosition, _maxPosition, _smallDistance, _bigDistance);
                }
                else if (rand == 5)
                {
                    CreateThreeObject(_minPosition, _maxPosition, _smallDistance, _smallDistance);
                }
                else if (rand == 6)
                {
                    CreateTwoObjectWithCoin(_minPosition, _maxPosition, _bigDistance);
                }
                else if (rand == 7)
                {
                    CreateThreeObjectWithCoin(_minPosition, _maxPosition, _smallDistance,_bigDistance);
                }
                else if (rand == 8)
                {
                    CreateThreeObjectWithCoin(_minPosition, _maxPosition, _bigDistance, _smallDistance);
                }
                else if (rand == 9)
                {
                    float pos = Random.Range(_minPosition, _maxPosition);
                    CreateObject(coin, new Vector3(pos, _yPosition, 0));
                }
                _rateTime = Random.Range(3, 7);
                _countTime = 0;
            }
        }

    }
    private void CreateObject(GameObject prefabs, Vector3 pos)
    {
        GameObject obj = Instantiate(prefabs, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.parent = transform;
        obj.transform.localPosition = pos;
        if (prefabs.Equals(barrel))
        {
            GameObject obj2 = Instantiate(alert, Vector3.zero, Quaternion.identity) as GameObject;
            obj2.transform.parent = transform;
            obj2.transform.localPosition = new Vector3(pos.x, -3, 0);
        }
    }

    public void CreateOneObject(float minValue, float maxValue)
    {
        float pos = Random.Range(minValue, maxValue);
        CreateObject(barrel, new Vector3(pos, _yPosition, 0));
    }
    public void CreateTwoObject(float minValue, float maxValue, float distance)
    {
        float pos = Random.Range(minValue, maxValue);
        float pos2 = 0;

            if (pos + distance < maxValue)
            {
                pos2 = pos + distance;
            }
            else if (pos - distance > minValue)
            {
                pos2 = pos - distance;
            }
            else
            {
                pos = 0;
                pos2 = maxValue;
            }
        CreateObject(barrel, new Vector3(pos, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos2, _yPosition, 0));
        //Debug.Log("Two " + distance);
    }
    public void CreateThreeObject(float minValue, float maxValue, float distance, float distance2)
    {
        float pos = Random.Range(minValue, maxValue);
        float pos1 = 0;
        float pos2 = 0;

        if (pos + distance < maxValue && pos - distance2 > minValue)
        {
            pos1 = pos + distance;
            pos2 = pos - distance2;
        }
        else
        {
            pos = 0;
            pos1 = pos + distance;
            pos2 = pos - distance2;
        }
        CreateObject(barrel, new Vector3(pos, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos1, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos2, _yPosition, 0));
    }

    public void CreateTwoObjectWithCoin(float minValue, float maxValue, float distance)
    {
        float pos = Random.Range(minValue, maxValue);
        float pos2 = 0;
        float posC = 0;
        if (pos + distance < maxValue)
        {
            pos2 = pos + distance;
            posC = pos + distance / 2;
        }
        else if (pos - distance > minValue)
        {
            pos2 = pos - distance;
            posC = pos - distance / 2;
        }
        else
        {
            pos = 0;
            pos2 = maxValue;
            posC = pos + maxValue / 2;
        }
        CreateObject(barrel, new Vector3(pos, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos2, _yPosition, 0));
        CreateObject(coin, new Vector3(posC, _yPosition, 0));
    }

    public void CreateThreeObjectWithCoin(float minValue, float maxValue, float distance,float distance2)
    {
        float pos = Random.Range(minValue, maxValue);
        float pos1 = 0;
        float pos2 = 0;
        float posC = 0;

        if (pos + distance < maxValue && pos - distance2 > minValue)
        {
            pos1 = pos + distance;
            pos2 = pos - distance2;
            
        }
        else
        {
            pos = 0;
            pos1 = pos + distance;
            pos2 = pos - distance2;
            
        }
        if (distance > distance2)
        {
            posC = pos + distance / 2;
        }
        else
        {
            posC = pos - distance2 / 2;
        }
        CreateObject(barrel, new Vector3(pos, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos1, _yPosition, 0));
        CreateObject(barrel, new Vector3(pos2, _yPosition, 0));
        CreateObject(coin, new Vector3(posC, _yPosition, 0));
    }

}
