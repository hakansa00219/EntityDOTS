using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect: IAspect
{
    private readonly Entity entity;

    private readonly TransformAspect transformAspect;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;


    public void Move(float deltaTime)
    { 
        //Direction
        float3 direction = math.normalize(targetPosition.ValueRW.value - transformAspect.WorldPosition);
        //movement
        transformAspect.WorldPosition += direction * deltaTime * speed.ValueRO.value;
    }

    public void TestReachedTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = .5f;
        if (math.distance(transformAspect.WorldPosition, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomPosition(randomComponent);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3(randomComponent.ValueRW.random.NextFloat(-100f,100f), 0, randomComponent.ValueRW.random.NextFloat(-100f, 100f));
    }
}
