using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{


    public static BulletPool Instance;

    [SerializeField]private Bullet bullet;
    [SerializeField]int size;

    List<Bullet> objects = new List<Bullet>();
    Vector3 defPos = Vector3.one * 5000;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        for (int i = 0; i < size; i++)
        {
            objects.Add(RequireT());
        }
    }

    public Bullet GetBulletAt(Vector3 pos, Quaternion rot)
    {
        if (objects.Count > 0)
        {
            Bullet obj = objects[objects.Count - 1];
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            objects.Remove(objects[objects.Count - 1]);
            return obj;
        }
        else
        {
            objects.Add(RequireT());
            return GetBulletAt(pos, rot);
        }


    }

    public void ReturnToPool(Bullet bullet)
    {
        objects.Add(bullet);
        bullet.transform.position = defPos;

    }

    public virtual Bullet RequireT()
    {
        return Instantiate<Bullet>(bullet, defPos, transform.rotation,transform);
    }




}
