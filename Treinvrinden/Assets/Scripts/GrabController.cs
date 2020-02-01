using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public GameObject GrabbedOBJ, Target;

    public bool grabbed;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("RightBump") && grabbed == true)
        {
            GrabbedOBJ.transform.SetParent(null);
            GrabbedOBJ.GetComponent<Rigidbody>().isKinematic = false;
            GrabbedOBJ.GetComponent<Collider>().enabled = true;
            GrabbedOBJ = null;
            grabbed = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetButton("RightBump") && other.gameObject.layer == 9 && grabbed == false)
        {
            GrabbedOBJ = other.gameObject;
            other.transform.position = Target.transform.position;
            other.gameObject.GetComponent<Collider>().enabled = false;
            other.transform.SetParent(Target.transform);
            other.GetComponent<Rigidbody>().isKinematic = true;
            grabbed = true;
        }
    }
}
