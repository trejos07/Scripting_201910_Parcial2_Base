using UnityEngine;
using System;


public class AICharacter : Character
{
    
    private State currentState;
    [SerializeField] State start;

    public delegate void colliding(Collision collision);
    public event colliding OnCollision;

    private void Start()
    {
        currentState = start;
        State[] states = GetComponents<State>();
        foreach (State s in states)
        {
            s.OnStateChange += SetNewState;
        }
    }

    public void SetNewState(State newState)
    {
        currentState = newState;
    }

    private void Update()
    {
        currentState.Execute();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (OnCollision != null)
            OnCollision(collision);
    }


}