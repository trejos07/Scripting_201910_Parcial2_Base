using UnityEngine;

public class Attack : Task
{
    [SerializeField] Character character;
    [SerializeField] float cD;
    bool canFire = true;
    public override bool Execute()
    {
        if (canFire == true)
        {
            canFire = false;
            character.SpawnBullet();
            Invoke("resetCD", cD);
            return true;
        }
        else
            return false;
        
    }

    void resetCD()
    {
        canFire = true;
    }
}