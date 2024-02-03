using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    private Vector3 dropPoint;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(GetComponent<PickUp>().Holding == true)
        {
            if (Input.GetKey("f"))
            {
                Debug.Log("hmmmm");
                if(once == true)
                {
                    Debug.Log("bruh");
                    Dropping();
                    Debug.Log("help");
                    once = false;
                }
            }

        }   
    }
    public void Dropping()
    {
        Instantiate(drop, transform.position, Quaternion.identity);
        GameObject held = GetComponent<PickUp>().holding;
        held.GetComponent<MeshRenderer>().enabled = false;
    }
}
