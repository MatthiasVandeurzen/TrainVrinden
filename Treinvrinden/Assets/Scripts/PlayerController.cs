using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float Movementspeed, MovementspeedMax,SprintMax, Rotationspeed, Sprintmeter, SprintMeterMax;
    public GameObject Player;
    public float Lerpspeed = 0.5f;
    public Rigidbody Rigid;
    public Vector3 Rotationcheck,destination;
    public bool SprintFull;
  
    
    void Start()
    {
        Rigid = this.GetComponent<Rigidbody>();
        destination = Rigid.position;
    }


    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            Rigid.freezeRotation = false;
            if(Movementspeed < MovementspeedMax)
            {
                Movementspeed += Lerpspeed * Time.deltaTime;

                  
            }

           Rigid.position += Rigid.transform.right*  Time.deltaTime * Movementspeed;
            Vector3 LookDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Rigid.rotation = Quaternion.LookRotation(LookDir);
            Rotationcheck = LookDir;
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Vertical") == 0)
        {
            Movementspeed = 0;
            Rigid.freezeRotation = true;

        }
        //Sprint part
        #region Sprint
        if (Input.GetButton("Fire3") && Sprintmeter != SprintMeterMax && SprintFull == false)
            {
                Movementspeed = SprintMax;
                if (Sprintmeter < SprintMeterMax)
                {
                    Sprintmeter += 5 * Time.deltaTime;
                }

            }
            if (Input.GetButtonUp("Fire3") || Sprintmeter >= SprintMeterMax)
            {
                Movementspeed = MovementspeedMax;
                SprintFull = true;
            }
            if (SprintFull == true)
            {
                Sprintmeter -= 5 * Time.deltaTime;
            }
            if (Sprintmeter <= 0)
            {
                SprintFull = false;
                Sprintmeter = 0;
            }
        #endregion
    }
}
