using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    Vector3 rotation;
    float z_rot;
    bool swing;
    bool up;
    bool down;
    bool back_to_start;
    float mod;

    // Start is called before the first frame update
    void Start()
    {
        //init rotation to zero
        rotation = new Vector3(0f, 0f, 0f);
        z_rot = 0f;
        mod = 1000;//15 //1200
        swing = false;
        up = false;
        down = false;
        back_to_start = false;
    }

    //rotate to up to 94 in z axis, then down to -34

    // Update is called once per frame
    void Update()
    {
        ///////change this to a timed cooldown, so player can time attacks properly

        //if left mouse pressed and released
        if(Input.GetMouseButtonDown(0) && !up && !down && !back_to_start)
        {
            
            up = true;
            Debug.Log("swing");
        }

        //if swing is started
        if(up)
        {
            //if sword is not at top of swing
            if(gameObject.transform.rotation.eulerAngles.z < 94)
            {
                //increase z rot smoothly
                z_rot = z_rot + (Time.deltaTime * mod);

                transform.eulerAngles = new Vector3(0f, 0f, z_rot);

                Debug.Log("z_rot1 = " + z_rot);
            }
            //sword is at top of swing
            else
            {
                Debug.Log("up = false");
                up = false;
                down = true;
            }

            
        }
        else if(down)
        {
            Debug.Log("down = true");

            //if sword is not at top of swing
            if((z_rot + 34) > 0)
            {
                Debug.Log("z_rot2 = " + z_rot);
                //increase z rot smoothly
                z_rot = z_rot - (Time.deltaTime * mod);

                transform.eulerAngles = new Vector3(0f, 0f, z_rot);

            }
            //sword is at top of swing
            else
            {
                Debug.Log("down = false");
                down = false;
                back_to_start = true;
            }
        }

        
        if(back_to_start)
        {
            //if sword is not at top of swing
            if (z_rot < 0f)
            {
                Debug.Log("z_rot3 = " + z_rot);
                //increase z rot soothly
                z_rot = z_rot + (Time.deltaTime * mod);

                transform.eulerAngles = new Vector3(0f, 0f, z_rot);

            }
            //sword is at top of swing
            else
            {
                
                back_to_start = false;
            }
        }
        
    }


}
