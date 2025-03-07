using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BallSpawnerAuthoring : MonoBehaviour
{
    public GameObject ballPrefab;
}

public class BallSpawnerBaker : Baker<BallSpawnerAuthoring>
{
    public override void Bake(BallSpawnerAuthoring authoring)
    {
        AddComponent(new BallSpawnerComponent() { towerPrefab = GetEntity(authoring.ballPrefab)});
    }
}
