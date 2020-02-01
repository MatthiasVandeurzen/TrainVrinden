using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public int CurrentCoal;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCoal = 5;  
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CurrentCoal++;
        }
    }
}
