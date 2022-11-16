using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow_cerberus : MonoBehaviour
{

    public Transform followtransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followtransform.position.x + 4, followtransform.position.y, this.followtransform.position.z);
    }
}
