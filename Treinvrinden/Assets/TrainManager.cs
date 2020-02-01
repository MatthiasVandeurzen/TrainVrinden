using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public bool isBraking;

    public float TrainSpeed;
    public float SlowDownFactor;
    public float SpeedUpFactor;

    public float MaxSpeed;
    public float MinsSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isBraking = false;
        SpeedUp();

    }
    private void Update()
    {
        if (!isBraking)
        {
            SpeedUp();
        }
        else if (isBraking)
        {
            SlowDown();
        }
    }

    public void SpeedUp()
    {
        if (TrainSpeed < MaxSpeed)
        {
            TrainSpeed += Time.deltaTime * SpeedUpFactor;
        }
    }

    public void SlowDown()
    {
        if (TrainSpeed >= MinsSpeed)
        {
            TrainSpeed = +Time.deltaTime * SlowDownFactor;
        }
    }
    
}
