using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileParentCaller : MonoBehaviour
{
    TileBehaviour parent;

    private void Start()
    {
        parent = transform.parent.GetComponent<TileBehaviour>();
    }

    public void CallParentSpawnFunction()
    {
        parent.SpawnBomb();
    }

    public void CallParentDestroyTileFunction()
    {
        parent.DestroyTile();
    }
}
