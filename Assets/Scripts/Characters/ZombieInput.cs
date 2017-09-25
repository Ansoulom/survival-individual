using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownController))]
public class ZombieInput : CharacterInput
{
    public float AggroRange = 3f;
    public float DeaggroRange = 5f;
    public int AttackDamage = 1;

    private Combateer _player;
    private TopDownController _controller;
    private bool _aggro;


	// Use this for initialization
    private void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Combateer>();
        _controller = GetComponent<TopDownController>();
    }
	

	// Update is called once per frame
    private void Update ()
    {
		UpdateAggro();
        var input = _aggro ? (_player.transform.position - transform.position).normalized : Vector3.zero;
        _controller.Input = new Vector2(input.x, input.y);

        var attack = GetComponent<Combateer>();
        if (_aggro && (_player.transform.position - transform.position).magnitude <
            attack.AttackRange)
        {
            attack.Attack(AttackDamage);
        }
    }


    private void UpdateAggro()
    {
        var distance = (_player.transform.position - transform.position).magnitude;
        if (_aggro)
        {
            if (distance > DeaggroRange)
            {
                _aggro = false;
            }
        }
        else
        {
            if (distance < AggroRange)
            {
                _aggro = true;
            }
        }
    }
}
