using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{

    private PlayerType player = PlayerType.None;

    public enum PlayerType
    {
        None,Player1,Player2
    }
    // Use this for initialization

    public PlayerType Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
