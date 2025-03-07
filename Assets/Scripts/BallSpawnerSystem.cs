using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;


public partial class BallSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery towerEntityQuery = EntityManager.CreateEntityQuery(typeof(BallTag));

        BallSpawnerComponent towerSpawnerComponent = SystemAPI.GetSingleton<BallSpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        int spawnAmount = 10000;
        if(towerEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(towerSpawnerComponent.towerPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new Speed
            {
                value = randomComponent.ValueRW.random.NextFloat(1f, 20f)
            });
        }
    }
}
