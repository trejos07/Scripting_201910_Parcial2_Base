using UnityEngine;
using UnityEngine.AI;
using System;


public class AICharacter : Character
{
    
    private State currentState;
    [SerializeField] State start;
    [SerializeField] NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; set => agent = value; }

    public delegate void colliding(Collision collision);
    public event colliding OnCollision;

    public delegate void Death(AICharacter aI);
    public event Death OnDeasth;

    private void Start()
    {
        base.Start();
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

    public void Reset()
    {
        Start();
    }

    protected override void OnDeath()
    {
        if (OnDeasth != null)
            OnDeasth(this);
        AisPool.Instance.ReturnToPool(this);
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