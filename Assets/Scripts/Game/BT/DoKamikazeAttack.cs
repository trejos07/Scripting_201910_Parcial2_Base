﻿using UnityEngine;

public class DoKamikazeAttack : Task
{
    [SerializeField] int Damage;
    Transform player;
    bool collide;
    AICharacter M_character;

    private void Awake()
    {
        M_character = TargetAI.GetComponent<AICharacter>();
        M_character.OnCollision += ReadCollision;
        player = FindObjectOfType<Player>().transform;
    }
    public override bool Execute()
    {
        if (collide)
        {
            Character P_character = player.GetComponent<Character>();
            P_character.ModifyHP(-Damage);
            M_character.ModifyHP(-M_character.HP);
            return true;
        }
        else
            return false;
    }

    void ReadCollision(Collision collision)
    {
        if (collision.transform == player)
            collide = true;
    }

}