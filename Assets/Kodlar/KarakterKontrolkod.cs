﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrolkod : MonoBehaviour
{
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;

    SpriteRenderer spriteRendere;

    int beklemeAnimSayac = 0;
    int yurumeAnimSayac = 0;

    Rigidbody2D fizik;
    Vector3 vec;

    float horizontal = 0;
    float beklemeAnimZaman = 0;
    float yurumeAnimZaman = 0;
    bool birkereZipla = true;

    void Start()
    {
        spriteRendere = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(birkereZipla)
            {
                fizik.AddForce(new Vector2(0, 500));
                birkereZipla = false;

            }
            
        }
    }

    void FixedUpdate()
    {
        karakterHareket();
        Animasyon();
    }
    void karakterHareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal*10,fizik.velocity.y,0);
        fizik.velocity = vec;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        birkereZipla = true;    
    }
    void Animasyon()
    {
        if(horizontal == 0)
        {
            beklemeAnimZaman += Time.deltaTime;
            if (beklemeAnimZaman > 0.05f)
            {
                spriteRendere.sprite = beklemeAnim[beklemeAnimSayac++];
                if (beklemeAnimSayac == beklemeAnim.Length)
                {
                    beklemeAnimSayac = 0;
                }
                beklemeAnimZaman = 0;
            }
           

        }
        else if(horizontal >0)
        {
            yurumeAnimZaman += Time.deltaTime;
            if (yurumeAnimZaman > 0.01f)
            {
                spriteRendere.sprite = yurumeAnim[yurumeAnimSayac++];
                if (yurumeAnimSayac == yurumeAnim.Length)
                {
                    yurumeAnimSayac = 0;
                }
                yurumeAnimZaman = 0;
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontal <0)
        {
            yurumeAnimZaman += Time.deltaTime;
            if (yurumeAnimZaman > 0.01f)
            {
                spriteRendere.sprite = yurumeAnim[yurumeAnimSayac++];
                if (yurumeAnimSayac == yurumeAnim.Length)
                {
                    yurumeAnimSayac = 0;
                }
                yurumeAnimZaman = 0;
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
