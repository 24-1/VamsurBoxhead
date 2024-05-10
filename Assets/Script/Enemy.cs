using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody target;

    bool isLive = true;

    Rigidbody rigid;
    // 외관 관련 SpriteRenderer spriter;

    void Awake(){
        rigid = GetComponent<Rigidbody>();
        //외관 관련 spriter = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if(!isLive) return;

        Vector3 dirVec = target.position - rigid.position;
        Vector3 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector3.zero;
    }

    // 외관 관련 void LateUpdate(){
    //     if(!isLive) return;

    //     spriter.flipX = target.position.x < rigid.position.x ;
    // }

    void OnEnable (){
        target = GameManager.instance.player.GetComponent<Rigidbody>();
    }
}
