using UnityEngine;
using System.Collections;

public class PoliceSergeantBehavior : MonoBehaviour
{
    public GameObject player;

    public int bossHealth;

    Animator bossAnimator;

    int attack1Hash, attack2Hash, vunerabilityHash;

    // Use this for initialization
    void Start ()
    {
        bossAnimator = this.GetComponent<Animator>();
        attack1Hash = Animator.StringToHash("Attack Pattern One");
        attack2Hash = Animator.StringToHash("Attack Pattern Two");
        vunerabilityHash = Animator.StringToHash("Vulnerability Period");

        StartCoroutine("RunBoss");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
	}

    IEnumerator RunBoss()
    {
        StartCoroutine("RunBoss");
        //placeholder yield
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Attack1()
    {
        //placeholder yield
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Attack2()
    {
        //placeholder yield
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Vulnerability()
    {
        //placeholder yield
        yield return new WaitForEndOfFrame();
    }
}
