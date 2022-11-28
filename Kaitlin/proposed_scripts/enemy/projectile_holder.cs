// projectile_holder.cs: update the projectile holder
// written by: Gavin Williams, Matthew Kaplan
// reviewed by: Kaitlin Tran
// TODO: can this be put somewhere else if it's just one function?

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
