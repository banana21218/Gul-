using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject drop;
    public bool once = true;
    public GameObject ObjectPoint;
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
                if(once == true)
                {
                    Dropping();
                    once = false;
                }
            }

        }   
    }
    public void Dropping()
    {
        GameObject held = GetComponent<PickUp>().holding;
        held.SetActive(false);
        Instantiate(drop, ObjectPoint.transform.position , Quaternion.identity);
 
 
    }
}
