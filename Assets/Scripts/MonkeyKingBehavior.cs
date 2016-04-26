using UnityEngine;
using System.Collections;

public class MonkeyKingBehavior : MonoBehaviour
{
    Animator bossAnimator;

    int attack1Hash, attack2Hash, vunerabilityHash;

    // Use this for initialization
    void Start ()
    {
        bossAnimator = GetComponent<Animator>();
        attack1Hash = Animator.StringToHash("Attack Pattern One");
        attack2Hash = Animator.StringToHash("Attack Pattern Two");
        vunerabilityHash = Animator.StringToHash("Vulnerability Period");

        StartCoroutine("RunBoss");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator RunBoss()
    {
        //placeholder yield
        yield return new WaitForEndOfFrame();
    }
}
