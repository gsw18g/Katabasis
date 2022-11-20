using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        if(enemy !=null)
        {
            transform.localScale = enemy.localScale;
        }
        
    }
}
