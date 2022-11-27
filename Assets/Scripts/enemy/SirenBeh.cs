using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SirenBeh : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float radius = 5f;
    [Range(1, 360)] public float angle = 360f;
    public LayerMask targetLayer;
    public float pause = 0f;
    public float timepause = 1f;
    player_movement plmv = null;
    public bool CanSeePlayer { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plmv = GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
        this.rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        CanSeePlayer = true;
        StartCoroutine(FOVCHECK());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FOVCHECK()
    {
        
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {

            yield return wait;
            
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if (rangeCheck.Length > 0)
        {

            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                CanSeePlayer = true;
            }
            else
                CanSeePlayer = false;

        }
        else if (CanSeePlayer)
            CanSeePlayer = false;


    }

    private void FixedUpdate()
    {

        if (CanSeePlayer)
        {
            Vector2 original = transform.position;
            if (pause > timepause)
            {

                if (pause > timepause + 0.4)
                {
                    plmv.hypno = false;
                    plmv.enabled = true;
                    pause=0;

                }
                else
                {
                    pause += Time.deltaTime;
                    plmv.hypno = true;
                    plmv.enabled = false;
                }
                    
            }
            else
            {
                rb.isKinematic = true;
                rb.MovePosition((Vector2)original);
                pause += Time.deltaTime;

            }


        }

    }



}
