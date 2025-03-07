using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class BallVisual : MonoBehaviour
{
    private Entity targetEntity;


    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            targetEntity = GetRandomEntity();
        }
        if(targetEntity != Entity.Null)
        {
            Vector3 followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalToWorld>(targetEntity).Position;
            transform.position = followPosition;
        }
    }

    private Entity GetRandomEntity()
    {
        EntityQuery entityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(BallTag));
        NativeArray<Entity> array = entityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        if(array.Length > 0)
        {
            return array[Random.Range(0, array.Length)];
        }
        else
        {
            return Entity.Null;
        }
    }
}
