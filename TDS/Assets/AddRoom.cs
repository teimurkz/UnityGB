using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [Header("Walls")]
    public GameObject[] Walls;
    public GameObject[] WallEffect;
    public GameObject[] door;

    [Header("Enemies")]
    public GameObject[] enemyTypes;

    [HideInInspector] public List<GameObject> enemies;

    private RoomVariants variants;
    private bool spawned;
    private bool wallsDestroyed;
        


}
