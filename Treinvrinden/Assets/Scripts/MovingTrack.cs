using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrack : MonoBehaviour
{
    public float distance;
    private float pos;
    private Vector3 startpos;
    public Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        pos += FindObjectOfType<TrainManager>().TrainSpeed * Time.deltaTime;
        pos %= distance;
        transform.localPosition = startpos + Direction* pos;
    }
}
