using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ArrayObject : MonoBehaviour
{
    public GameObject ObjectToInstantiate;
    [Range(0,100)]
    public int Count;
    public Vector3 ArrayDirection;
    [SerializeField, HideInInspector]
    private List<GameObject> kindertjes = new List<GameObject>();

    private void Update()
    {
        if (Application.isPlaying) return;
        MakeArray();
    }

    public void MakeArray()
    {
        if (!ObjectToInstantiate) return;
        if (kindertjes.Count < Count)
        {
            for (int i = kindertjes.Count; i < Count; i++)
            {
                kindertjes.Add(Instantiate(ObjectToInstantiate,  transform.position + ArrayDirection * (i + 1), transform.rotation, transform));
            }
        }
        else
        {
            for (int i = kindertjes.Count; i > Count; i--)
            {
                var kindertje = kindertjes[i - 1];
                kindertjes.Remove(kindertje);
                DestroyImmediate(kindertje);
            }
        }
    }
}
