using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources instance;

    public static GameResources Instance {
        get
        {
            if (instance == null) {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    [Header("Dungeon")]
    public RoomNodeTypeListSO RoomNodeTypeList;
}
