using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BallTagAuthoring : MonoBehaviour
{
    
}

public class BallTagBaker : Baker<BallTagAuthoring>
{
    public override void Bake(BallTagAuthoring authoring)
    {
        AddComponent(new BallTag());
    }
}
