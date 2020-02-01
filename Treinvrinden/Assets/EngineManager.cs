using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineManager : MonoBehaviour
{
    public int EngineEmber;
    public float EmberLoaded;
    public int DecreaseRateOver20;
    public int DecreaseRateUnder20;

    public int RefillValue;

    // Start is called before the first frame update
    void Start()
    {
        EngineEmber = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EngineEmber > 0)
        {
            EngineEmber--;
            EmberLoaded += RefillValue;
        }
    }
}
