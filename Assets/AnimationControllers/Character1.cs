using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character1 : MonoBehaviour {

    public Animator Anim;

    [SerializeField] Collider attackTrigger;
    [SerializeField] float m_AttackLastTime = 0.2f;
    [SerializeField] float m_AttackLevelLastTime = 1f;
    [SerializeField] float m_AttackFinishOffset = 0.1f;
    [SerializeField] string m_IdleClipsName;
    [SerializeField] string[] m_AttackClipsName;

    int m_IdleClipsHash;
    int[] m_AttackClipsHash;
    Animator m_Animator;
    AnimatorStateInfo m_AnimatorState;
    float m_IdleTimer;
    float m_AttackLastTimer;
    float m_AttackLevelLastTimer;
     public int m_AttackLevel;
    int m_LastAttack;
    public Text GoldTextfield;
public int GoldCollected;

    void start() {

        GoldCollected = 0;
        SetGCountToString();
    }
    void Awake()
    { 
        CreateHash();
        Anim = GetComponent<Animator>();
        m_Animator = GetComponent<Animator>();
        m_LastAttack = m_IdleClipsHash;
    }

    void Update()
    {
        m_AnimatorState = m_Animator.GetCurrentAnimatorStateInfo(0);

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (isAttackClip(m_AnimatorState.shortNameHash))
        {
            m_LastAttack = m_AnimatorState.shortNameHash;
        }

        if (m_AttackLevelLastTimer > 0 && !isAttackClip(m_AnimatorState.shortNameHash))
        {
            m_AttackLevelLastTimer -= Time.deltaTime;
            if (m_AttackLevelLastTimer <= 0)
            {
                m_AttackLevel = 0;
                m_LastAttack = m_IdleClipsHash;
            }
        }

        if (m_AttackLastTimer > 0)
        {
            m_AttackLastTimer -= Time.deltaTime;
            if (m_AttackLastTimer <= 0)
            {
                m_Animator.SetBool("Attack", false);
            }
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            print("H");
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
{
            transform.Rotate(Vector3.up * -50 * Time.deltaTime);
        }

        if (Input.GetButton("w"))
        {
            print("walk");
            m_Animator.SetBool("walk", true);
         
        }
        else
        {
            m_Animator.SetBool("walk", false);
        }
        /*if (Input.GetButton("s"))
        {
            print("moceback");
            m_Animator.SetBool("walk", true);

        }
        else
        {
            m_Animator.SetBool("walk", false);
        }*/

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            GoldCollected = GoldCollected + 1;
            SetGCountToString();
        }
    }
    void SetGCountToString() {
        GoldTextfield.text = "Gold:" + GoldCollected.ToString();


    }

    void CreateHash()
    {
        m_AttackClipsHash = new int[m_AttackClipsName.Length];

        m_IdleClipsHash = Animator.StringToHash(m_IdleClipsName);
        for (int i = 0; i < m_AttackClipsName.Length; i++)
        {
            m_AttackClipsHash[i] = Animator.StringToHash(m_AttackClipsName[i]);
        }
    }

    bool CurrentAttackClipFinished()
    {
        m_AnimatorState = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (!isAttackClip(m_AnimatorState.shortNameHash) ||
            m_AnimatorState.length < m_AnimatorState.normalizedTime + m_AttackFinishOffset)
            return true;

        return false;
    }

    bool isAttackClip(int hashCode)
    {
        foreach (int i in m_AttackClipsHash)
        {
            if (i == hashCode) return true;
        }
        return false;
    }

    void increaseAttackLevel()
    {
        for (int i = 0; i < m_AttackClipsHash.Length; i++)
        {
            if (m_LastAttack == m_AttackClipsHash[i])
            {
                //For example, The index of Attack1 is 0, attack level is 1,
                //The next, Attack2, attack level should be 2, then i + 2
                m_AttackLevel = i + 2;
            }
        }
        //If reach the last attack clip, return to first cilp
        if (m_AttackLevel > m_AttackClipsHash.Length ||
            m_LastAttack == m_IdleClipsHash)
            m_AttackLevel = 1;

        if (CurrentAttackClipFinished())
        {
            m_AttackLevelLastTimer = m_AttackLevelLastTime;
        }
    }

    void EnableDamage(int level)
    {
        attackTrigger.enabled = true;
    }

    void DisableDamage()
    {
        attackTrigger.enabled = false;
    }

    public void Attack()
    {
        increaseAttackLevel();

        m_AttackLastTimer = m_AttackLastTime;
        m_Animator.SetBool("Attack", true);
        m_Animator.SetInteger("AttackStep", m_AttackLevel);
    }

    public void StopWeapon()
    {
        m_Animator.CrossFade("Idle", 0.2f);
        DisableDamage();
    }
}
