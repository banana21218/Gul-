using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(lifetime());
    }

    private IEnumerator lifetime()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }
}
