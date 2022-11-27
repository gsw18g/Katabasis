// move_bat.cs: Moves bat enemy object
// written by: Gavin Williams
// TODO: add comments. Should this be in the file with the other bat behavior?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_bat : MonoBehaviour
{
    Rigidbody2D rb;
    float mod = 1.5f;
    float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = new Vector3(gameObject.transform.position.x - Time.deltaTime * mod, pos_y, 0f);
    }
}
