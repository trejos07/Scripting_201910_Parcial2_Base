using UnityEngine;

public class RunBT : State
{
    [SerializeField] protected Root btRoot;
    Transform player;
    [SerializeField] float agrod;


    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
    }

    public override void Execute()
    {
        float d = Vector3.Distance(transform.position, player.position);
        if (d <= agrod)
        {
            if (btRoot != null)
            {
                btRoot.Execute();
            }
        }
        else
        {
            SwitchToNextState();
        }
        
    }
}