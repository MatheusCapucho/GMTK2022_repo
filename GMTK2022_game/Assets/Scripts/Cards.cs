using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    // Canvas Related
    private TMP_Text tmpName;
    private TMP_Text tmpDescription;
    private Image cardImage;
    private GameObject textPanel;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        textPanel = GameObject.Find("TextPanel");
        Debug.Log(textPanel);
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
        tmpName = textPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmpDescription = textPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();        
    }

    private void OnMouseEnter()
    {
        ShowText();
    }

    private void ShowText()
    {
        textPanel.SetActive(true);
        tmpName.text = name;
        tmpDescription.text = description;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            ApplyEffect();       

    }

    private void OnMouseExit()
    {
        textPanel.SetActive(false);
    }

    private void ApplyEffect()
    {
        battleHandler.SetCardEffect(damageMultiplier, healthMultiplier, addBaseDamage, addBaseHealth);
        textPanel.SetActive(false);
    }

}
