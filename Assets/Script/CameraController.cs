using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    public float camSens = 0.50f; //How sensitive it with mouse
    Vector3 lastMouse = new Vector3(255, 255, 255);
    private ObjectPool pool;

    private void Start()
    {
        pool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        CameraPosition();
        if (Input.GetButtonDown("Fire1"))
            ShootABullet();
    }

    void CameraPosition()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }

    void ShootABullet() {
        GameObject bulletInstance = pool.GetNewObjectFromPool();
        BulletHandler bh = bulletInstance.GetComponent<BulletHandler>();
        if (bh != null)
            bh.Shoot(transform.forward);
        else
        {
            Debug.Log("La Bullet no tiene Script BulletHandler");
            Destroy(bulletInstance, 3f);
        }
    }
}

