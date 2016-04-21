using UnityEngine;
using System.Collections;

public class LavabotBehavior : MonoBehaviour
{

    public Animator bossAnimator;

    public GameObject player;
    public GameObject shield;

    bool isVuln = false;

    public int bossHealth = 3;
    int attack1Hash, attack2Hash, vunerabilityHash;
    int attackCount = 0;
    int delay = 6;

    public Vector3 offset = new Vector3(0, 20, 0);
    public Rigidbody boulder;


    // Use this for initialization
    void Start()
    {

        attack1Hash = Animator.StringToHash("Attack Pattern One");
        attack2Hash = Animator.StringToHash("Attack Pattern Two");
        vunerabilityHash = Animator.StringToHash("Vulnerability Period");
        StartCoroutine("RunBoss");
    }

    // Update is called once per frame
    void Update()
    {
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
            yield return StartCoroutine("Vulnerability", delay);
            shield.SetActive(true);
            delay--;
        }
        else
            Debug.Log("Something went wrong");

        StartCoroutine("RunBoss");

    }

    IEnumerator AttackNumOne()
    {
        //Create a boulder
        Rigidbody clone = Instantiate(boulder, player.transform.position + offset, player.transform.rotation) as Rigidbody;

        //finish throwing boulder because they didnt tell me how many to throw
        //I'm just going to spawn a boulder above the player and let it drop
        //yield return out
        yield return new WaitForSeconds(3);
    }

    IEnumerator AttackNumTwo()
    {
        yield return new WaitForSeconds(6);
    }

    IEnumerator Vulnerability(int delay)
    {
        shield.SetActive(false);
        yield return new WaitForSeconds(delay);
    }

}