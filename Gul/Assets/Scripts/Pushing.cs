using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public GameObject gul;
    public Vector3 Gul;
    public GameObject Push;
    public Transform pushed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pushable")
        {

            collision.gameObject.GetComponent<Transform>().position = Gul;
            Gul = Push.transform.position;
            Push.transform.SetParent(pushed);

        }
    }
}
