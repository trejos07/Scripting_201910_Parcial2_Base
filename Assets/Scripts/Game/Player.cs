using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private float rotSpeed = 5F;
    private float movSpeed = 10F;

    private float hVal = 0F;
    private float vVal = 0F;
    private float pitchVal = 0F;

    protected virtual void Update()
    {
        hVal = Input.GetAxis("Horizontal");
        vVal = Input.GetAxis("Vertical");

        if (hVal != 0)
        {
            transform.Translate(transform.right * hVal * movSpeed * Time.deltaTime, Space.World);
        }

        if (vVal != 0)
        {
            transform.Translate(transform.forward * vVal * movSpeed * Time.deltaTime, Space.World);
        }

        pitchVal = rotSpeed * Input.GetAxis("Mouse X");

        if (pitchVal != 0F)
        {
            transform.Rotate(transform.up, pitchVal);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }
    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }

}