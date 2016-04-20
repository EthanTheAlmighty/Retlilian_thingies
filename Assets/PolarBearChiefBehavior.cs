using UnityEngine;
using System.Collections;

public class PolarBearChiefBehavior : MonoBehaviour
{
    GameObject player;
    public bool damageTaken = false;

    public Animator bossAnimator;

    int attack1Hash, attack2Hash, vunerabilityHash;
    int damage = 0;
    int attackCount = 0;
    int delay = 6;
    int speed = 6;

    // Use this for initialization
    void Start ()
    {
        attack1Hash = Animator.StringToHash("Attack Pattern One");
        attack2Hash = Animator.StringToHash("Attack Pattern Two");
        vunerabilityHash = Animator.StringToHash("Vulnerability Period");
        StartCoroutine("RunBoss");
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Vector3 mine = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 target = new Vector3(player.transform.position.x, mine.y, player.transform.position.z);
        Vector3 moveDir = target - mine;
        //moveDir.Normalize()  //The direction to travel in unit vector
        moveDir.Normalize();
        transform.Translate(moveDir * speed);

    }

    IEnumerator AttackNumOne()
    {
        //Create a boulder

        //finish throwing boulder because they didnt tell me how many to throw

        //yield return out
        yield return new WaitForSeconds(10);
    }

    IEnumerator AttackNumTwo()
    {
        yield return new WaitForSeconds(10);
    }

    IEnumerator Vulnerability(int delay)
    {
        if (damageTaken)
            yield return null;
        yield return new WaitForSeconds(delay);
    }
}
