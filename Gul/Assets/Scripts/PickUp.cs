using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject holding;

    // Start is called before the first frame update
    void Start()
    {
        holding.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            holding.GetComponent<MeshRenderer>().enabled = true;
            Destroy(other.gameObject);
        }
    }
}
