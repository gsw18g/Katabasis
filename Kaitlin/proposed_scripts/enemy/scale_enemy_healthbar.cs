// scale_enemy_healthbar.cs: Scales enemy health bar display
// written by: Gavin Williams

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_enemy_healthbar : MonoBehaviour
{
      int health;
      float scale;

      public GameObject enemy;
      enemy_melee zombie;

      // Start is called before the first frame update
      void Start()
      {
          zombie = enemy.GetComponent<enemy_melee>();
          scale = 1f;
      }

      // Update is called once per frame
      void Update()
      {
          health = zombie.health;

          if (health < 100)
          {
              scale = health / 100f;
              gameObject.transform.localScale = new Vector3(scale, 1f, 1f);//health / 100
          }
      }
}