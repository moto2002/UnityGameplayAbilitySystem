﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public struct PlayerMovementControllableTagComponent : IComponentData { }
public struct PlayerMovementRotationMultiplierComponent : IComponentData {
    public float Value;
}

public struct PlayerMovementSpeedMultiplierComponent : IComponentData {
    public float Value;
}

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class PlayerMovementControllableTagAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity {
    // Add fields to your component here. Remember that:
    //
    // * The purpose of this class is to store data for authoring purposes - it is not for use while the game is
    //   running.
    // 
    // * Traditional Unity serialization rules apply: fields must be public or marked with [SerializeField], and
    //   must be one of the supported types.
    //
    // For example,
    //    public float scale;

    public float RotationMultiplier = 5;
    public float MovementSpeedMultiplier = 5;



    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        // Call methods on 'dstManager' to create runtime components on 'entity' here. Remember that:
        //
        // * You can add more than one component to the entity. It's also OK to not add any at all.
        //
        // * If you want to create more than one entity from the data in this class, use the 'conversionSystem'
        //   to do it, instead of adding entities through 'dstManager' directly.
        //
        // For example,
        //   dstManager.AddComponentData(entity, new Unity.Transforms.Scale { Value = scale });
        dstManager.AddComponentData(entity, new PlayerMovementControllableTagComponent());
        dstManager.AddComponentData(entity, new PlayerMovementRotationMultiplierComponent
        {
            Value = RotationMultiplier
        });

        dstManager.AddComponentData(entity, new PlayerMovementSpeedMultiplierComponent
        {
            Value = MovementSpeedMultiplier
        });

        dstManager.AddComponentData(entity, new CopyTransformToGameObject());

    }
}