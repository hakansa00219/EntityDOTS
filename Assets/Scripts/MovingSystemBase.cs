using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        //RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        //foreach (MoveToPositionAspect moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>())
        //{
        //    moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, randomComponent);
        //}
    }
}
