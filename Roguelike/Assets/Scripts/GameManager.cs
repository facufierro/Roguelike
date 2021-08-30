using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab, EnemyPrefab;
    private Player Player;
    private List<Enemy> Enemy = new List<Enemy>();

    private void Start()
    {
        InitializeCharacters();
        StartCoroutine(Player.Movement());
        StartCoroutine(Player.MeleeAttack());
        for (int i = 0; i < Enemy.Count; i++)
        {
            Enemy[i].MeleeAttack();
        }
    }

    private void Update()
    {
        if (Player.State == State.MOVING)
            //print(Player.State);
        Combat();

    }

    private void InitializeCharacters()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player.Initialize();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            Enemy.Add(GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<Enemy>());
            Enemy[i].Initialize();
        }
    }


    private void Combat()
    {

        for (int i = 0; i < Enemy.Count; i++)
        {
            Enemy[i].MeleeAttack();
            Enemy[i].Death();
        }

    }
}
