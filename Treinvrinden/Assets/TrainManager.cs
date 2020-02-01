using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public bool CanAccelerate;
    public bool isAccellerating;
    public bool isDecellerating;

    [Range(0, 25)]
    public float trainSpeed;
    public float AcceleratingSpeed;
    public float DecelerateSpeed;
    public float EmberBurnRate;

    public float MinSpeed, MaxSpeed;

    //script references
    EngineManager s_engineManager;

    private void Awake()
    {
        s_engineManager = FindObjectOfType<EngineManager>();
    }

    private void Update()
    {
        SpeedCheck();
        CheckAccelerateOption();
        Accelerate();
        Decellerate();
       
    }

    public void CheckAccelerateOption()
    {
        if (s_engineManager.EmberLoaded <= 0 || trainSpeed >= MaxSpeed)
        {
            CanAccelerate = false;
        }
        else if (s_engineManager.EmberLoaded > 0)
        {
            CanAccelerate = true;
        }
    }

    public void Accelerate()
    {
        if (CanAccelerate && trainSpeed < MaxSpeed)
        {
            isAccellerating = true;
            s_engineManager.EmberLoaded -= EmberBurnRate * Time.deltaTime;
            trainSpeed += AcceleratingSpeed * Time.deltaTime;

        }
    }

    public void Decellerate()
    {     
        if (s_engineManager.EmberLoaded <= 0)
        {
            isAccellerating = false;
            trainSpeed -= DecelerateSpeed * Time.deltaTime;
        }
    }

    public void SpeedCheck()
    {
        if (trainSpeed < 0 )
        {
            trainSpeed = 0;
        }

        if (trainSpeed >= MaxSpeed)
        {
            isAccellerating = false;
            s_engineManager.EmberLoaded -= EmberBurnRate * Time.deltaTime;
        }
    }

}
