using UnityEngine;
using System.Collections;

public class PolarBearChiefBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject boulder;
    public bool damageTaken = false;
    bool charging = false;

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
        if(!charging)
            transform.LookAt(player.transform);

        
        

    }

    IEnumerator RunBoss()
    {
        AnimatorStateInfo stateInfo = bossAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == attack1Hash)
        {
            Debug.Log("1!");
            yield return StartCoroutine("AttackNumOne");

            //increment atk num
            attackCount++;
            //change Which State in the animator to tell the next state that needs to go to
            bossAnimator.SetInteger("WhichState", 2);
        }
        else if (stateInfo.shortNameHash == attack2Hash)
        {
            if (attackCount < 4)
            {
                attackCount++;
                bossAnimator.SetInteger("WhichState", 1);

            }
            else if (attackCount == 4)
            {
                attackCount = 0;
                bossAnimator.SetInteger("WhichState", 3);
            }
            yield return StartCoroutine("AttackNumTwo");
        }
        else if (stateInfo.shortNameHash == vunerabilityHash)
        {
            Debug.Log("vuner!");
            yield return StartCoroutine("Vulnerability", delay);
            delay--;
        }
        else
            Debug.Log("Something went wrong");

        StartCoroutine("RunBoss");
    }

    IEnumerator AttackNumOne()
    {
        StartCoroutine("InitiateCharge");
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

    IEnumerator InitiaiteCharge()
    {
        Vector3 mine = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 target = new Vector3(player.transform.position.x, mine.y, player.transform.position.z);
        Vector3 moveDir = target - mine;
        //moveDir.Normalize()  //The direction to travel in unit vector
        moveDir.Normalize();
        transform.Translate(moveDir * speed);
        yield return null;
    }
}
