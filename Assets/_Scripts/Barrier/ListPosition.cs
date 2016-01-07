using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ListPosition : MonoBehaviour
{

    public bool pathVisible = true;
    public string Name = "";
    public Color pathColor = Color.cyan;
    public float _radius = 0.3f;

    public List<Vector3> nodes = new List<Vector3>();

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (pathVisible)
        {
            if (nodes.Count > 0)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    Gizmos.color = pathColor;
                    Gizmos.DrawWireSphere(nodes[i], _radius);
                    Handles.Label(nodes[i], Name + " " + (i).ToString());
                }
            }
        }
    }
#endif
    
}