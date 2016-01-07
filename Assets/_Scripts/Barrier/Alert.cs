using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Alert : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(0, 1.5f).OnComplete(AutoDestroy);
    }

    private void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}