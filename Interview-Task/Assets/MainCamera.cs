using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y +3.71f, -10) ;
    }
}
