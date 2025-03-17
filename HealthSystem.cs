﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_OOMS_Shawn_Bernard;

public class HealthSystem: Component
{
    //public HealthSystem healthSystem;
    public int health;
    public HealthSystem()
    {
        ResetGame();
    }
    public void TakeDamage(int damage)
    {
        //Taking away health and if my health tries to go under 0 set it to 0
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
    }
    public void Heal(int hp)
    {
        health += hp;
        if (health >= 100)//if health is greater than 100
        {
            health = 100; //Set to 100
        }
    }
    public void ResetGame()
    {
        health = 100;
    }
    public bool Death()
    {
        //if the health is 0 than return true else returns false 
        if (health == 0)
        {
            return true;
        }
        return false;
    }
}