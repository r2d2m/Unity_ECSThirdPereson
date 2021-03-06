﻿using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine;

public class ActorInitalizeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<Transform, Actor>().WithNone<Frozen>().ForEach((Entity entity, Transform transform) =>
        {

            var actor = EntityManager.GetSharedComponentData<Actor>(entity);

            PostUpdateCommands.AddComponent(entity,new Frozen());
            PostUpdateCommands.AddComponent(entity,new ActorInput());
            ActorUtilities.UpdateModel(actor, transform);
            ActorUtilities.UpdateAnimator(actor, transform);
            ActorUtilities.UpdateCollider(actor, transform, 0);
            ActorUtilities.UpdatePhysics(actor, transform);
        });
    }
}