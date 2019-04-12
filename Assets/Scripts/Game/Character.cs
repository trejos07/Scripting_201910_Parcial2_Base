using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float maxHP;

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private float shootForce = 20F;

    [SerializeField]
    private Transform bulletSpawnPosition;

    private float hp;

    public float HP
    {
        get { return hp; }
        protected set { hp = value; }
    }

    public float ShootForce { get { return shootForce; } }
    
    public void ModifyHP(float delta)
    {
        HP += delta;

        if (HP <= 0F)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        HP = maxHP;
    }

    public void SpawnBullet()
    {
        if (bullet != null && bulletSpawnPosition != null)
        {
           BulletPool.Instance.GetBulletAt(bulletSpawnPosition.position, transform.rotation).Shoot(this);
        }
    }
}