using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource aSource;
    private ParticleSystem particleShoot;
    public AudioClip hitSound;
    public AudioClip shootSound;
    public GameObject shooter;
    private Coroutine corRef;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        particleShoot = GetComponent<ParticleSystem>();

        this.transform.position = shooter.transform.position;
        corRef = StartCoroutine(BulletTimeOut());
    }

    public void Shoot(Vector3 direction)
    {
        Start();
        aSource.clip = shootSound;
        aSource.Play();
        rb.AddForce(direction, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        particleShoot.Play();
        aSource.clip = hitSound;
        aSource.Play();
    }

    IEnumerator BulletTimeOut()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if(corRef != null) StopCoroutine(corRef);
        transform.rotation = Quaternion.identity;
    }
}
