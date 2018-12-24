using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    private const float OFFSET = 19.2f;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        gameObject.transform.position += new Vector3(OFFSET, 0, 0);
    }
}
