using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField] private CardComponent cardComponent;

    private string _name;
    private string description;
    private Sprite _image;
    private int damageMultiplier;
    private int healthMultiplier;
    private int addBaseDamage;
    private int addBaseHealth;

    private BattleHandler battleHandler;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Setup();     
    }

    private void OnEnable()
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
    }
    private void Setup()
    {
        _name = cardComponent.Name;
        description = cardComponent.Description;
        _image = cardComponent.Image;
        damageMultiplier = cardComponent.DamageMultiplier;
        healthMultiplier = cardComponent.HealthMultiplier;
        addBaseDamage = cardComponent.AddBaseDamage;
        addBaseHealth = cardComponent.AddBaseHealth;
        sr.sprite = _image;
    }

    private void OnMouseEnter()
    {
        //show floating description
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            ApplyEffect();       

    }

    private void OnMouseExit()
    {
        //disable text description
    }

    private void ApplyEffect()
    {
        battleHandler.SetCardEffect(damageMultiplier, healthMultiplier, addBaseDamage, addBaseHealth);
    }

}
