﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    public VoyageManager voyage;
    public Ship ship;
    public PlayerScript player1;
    public PlayerScript player2;
    public PlayerScript player3;
    public PlayerScript player4;

    private void Awake()
    {
        ship = GameObject.Find("Ship").GetComponent<Ship>();
        voyage = GetComponent<VoyageManager>();
        //player1 = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    private void Start()
    {
        UIManager.Instance.player1Inventory.AssignInventory(player1.inventory);
        //UIManager.Instance.player1Inventory.AssignInventory(player2.inventory);
        //UIManager.Instance.player1Inventory.AssignInventory(player3.inventory);
        //UIManager.Instance.player1Inventory.AssignInventory(player4.inventory);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            voyage.StartVoyage();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            voyage.ResetVoyage();
        }
    }
}
