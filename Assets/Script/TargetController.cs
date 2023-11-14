using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private int damage = 0;
    [SerializeField] private int leavePoints = 0;
    [SerializeField] private int killPoints = 0;
    [SerializeField] private float minLeaveTIme = 2;
    [SerializeField] private float maxLeaveTime = 8;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(LeaveNow());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            anim.SetTrigger("Shot");
            GameController.Instance.points += killPoints;
            Destroy(gameObject, 0.45f + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }

    IEnumerator LeaveNow()
    {
        yield return new WaitForSeconds(Random.Range(minLeaveTIme, maxLeaveTime));
        anim.SetTrigger("Shot");
        if (this.name.StartsWith("Enemy")) GameManager.Instance.ChangeHealth(damage);
        GameController.Instance.points += leavePoints;
        Destroy(gameObject, 0.45f + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
