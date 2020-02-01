using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunRotation : MonoBehaviour
{
    public float x, y, z;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x/10, y/10, z/10, Space.World);
    }
}
