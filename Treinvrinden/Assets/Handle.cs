using UnityEngine;

public class Handle : MonoBehaviour
{
    public TrainManager s_trainManager;

    [SerializeField]
    Material handleMat;
    [SerializeField]
    Color normalColor;
    [SerializeField]
    Color HighLightcolor;

    public GameObject HandleBar;
    public Animator HandleAnimator;


    private void Awake()
    {
        s_trainManager = FindObjectOfType<TrainManager>().gameObject.GetComponent<TrainManager>();
    }

    private void Start()
    {
        handleMat.color = normalColor;
    }

    private void Update()
    {
        HandleChecker();
    }

    void HandleChecker()
    {
        if (s_trainManager.isBraking)
        {
            HandleAnimator.SetBool("isBraking", true);
        }
        else if (!s_trainManager.isBraking)
        {
            HandleAnimator.SetBool("isBraking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        handleMat.color = HighLightcolor;
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Action"))
        {
            if (s_trainManager.isBraking)
            {
                s_trainManager.isBraking = false;
            }

            if (!s_trainManager.isBraking)
            {
                s_trainManager.isBraking = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        handleMat.color = normalColor;
    }

}
