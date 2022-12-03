using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_blocks : MonoBehaviour
{
    static int size = 50;
    GameObject[] blocks = new GameObject[size];
    public GameObject brick;
    GameObject player;
    float offset = 1f;
    float timer = 0;

    private GameObject[] instance_count;

    /*
     * private static boss_blocks instance = null;

    //game instance singleton
    public static boss_blocks Instance
    {
        get
        {
            return instance;
        }
    }

    //make sure only one instance is instantiated
    private void Awake()
    {
        //if the singleton hasn't been initialized yet
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
     * */

    // Start is called before the first frame update
    void Start()
    {
        //build_floor();
        player = GameObject.FindGameObjectWithTag("Player");

        instance_count = GameObject.FindGameObjectsWithTag("ground");
        Debug.Log("instances = " + instance_count.Length);
    }

    // Update is called once per frame
    void Update()
    {

 
    }

    void build_floor()
    {
        for(int i = 0; i < size; i++)
        {
            blocks[i] = Instantiate(brick, gameObject.transform.position, gameObject.transform.rotation);

            blocks[i].transform.position = new Vector3(transform.position.x + (i * offset), transform.position.y, transform.position.z);
        }
    }

    void find_block()
    {
        for (int i = 0; i < instance_count.Length; i++)
        {
            if (blocks[i].transform.position.x >= player.transform.position.x && blocks[i].transform.position.x <= player.transform.position.x - 5f)
            {

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("trigger enter");

        if (collision.transform.CompareTag("hades") && hades.destroy)
        {

            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
