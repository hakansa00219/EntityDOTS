using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct BallSpawnerComponent : IComponentData
{
    public Entity towerPrefab;   
}
