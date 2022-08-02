using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite[] weapon;
    public int damageValue;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //broń1
        if(spriteR.sprite == weapon[0])
        {
            damageValue = 10;
        }
        //broń2
        else if(spriteR.sprite == weapon[1])
        {
            damageValue = 20;
        }
        //broń3
        else if (spriteR.sprite == weapon[2])
        {
            damageValue = 30;
        }
        //broń4
        else if (spriteR.sprite == weapon[3])
        {
            damageValue = 40;
        }
        //broń5
        else if (spriteR.sprite == weapon[4])
        {
            damageValue = 50;
        }
        //broń6
        else if (spriteR.sprite == weapon[5])
        {
            damageValue = 60;
        }
        //broń7
        else if (spriteR.sprite == weapon[6])
        {
            damageValue = 70;
        }
        //broń8
        else if (spriteR.sprite == weapon[7])
        {
            damageValue = 80;
        }
        //broń9
        else if (spriteR.sprite == weapon[8])
        {
            damageValue = 90;
        }
        //broń10
        else if (spriteR.sprite == weapon[9])
        {
            damageValue = 100;
        }
        //broń11
        else if (spriteR.sprite == weapon[10])
        {
            damageValue = 110;
        }
        //broń12
        else if (spriteR.sprite == weapon[11])
        {
            damageValue = 120;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().curHealth -= damageValue;
            other.GetComponent<Animator>().Play("EnemyDamage");
        }
    }
}
