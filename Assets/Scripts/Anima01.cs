using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima01 : MonoBehaviour
{
    Animation anima;
    //public Transform Shoulder;
    // Start is called before the first frame update
    public void Start()
    {
        anima = this.GetComponent<Animation>();
        AnimationState a = anima["Idle"];
        AnimationState b = anima["Attack"];
        //layer表示层级,weight表示权重,enabled是否参与播放
        a.layer = 0; a.weight = 0.5f; a.enabled = true;
        //anima["Attack"].AddMixingTransform(Shoulder);
        //anima["Attack"].wrapMode = WrapMode.Loop;
        //anima["Attack"].layer = 1;
        //anima["Attack"].weight = 1;
        //anima["Attack"].enabled = true;
        b.layer = 1; b.weight = 0.5f; b.enabled = true;
    }
    public void Attack()
    {
        anima.Play("Attack");

    }
    // Update is called once per frame
    public void PlaySkillOne()
    {
        anima.Play("Skill");
        anima.PlayQueued("ReleaseSkill", QueueMode.CompleteOthers);

    }
    public void PlaySkillTwo()
    {
        anima.Play("Skill01");
        anima.PlayQueued("ReleaseSkill", QueueMode.CompleteOthers);

    }
    public void PlaySkillThree()
    {
        anima.Play("Skill02");
        anima.PlayQueued("ReleaseSkill", QueueMode.CompleteOthers);

    }
    private void Update()
    {
        if (!anima.isPlaying)
        {
            anima.CrossFade("Idle");
        }
    }
}
