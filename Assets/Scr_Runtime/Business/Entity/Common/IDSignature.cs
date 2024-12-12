using System;
using UnityEngine;
using HNY;
using System.Runtime.InteropServices;

[Serializable]
//内存显式布局 用[FieldOffset]指定字段起始位置（不懂）
[StructLayout(LayoutKind.Explicit)]
public struct IDSignature
{
    [FieldOffset(0)]
    [HideInInspector]
    public ulong value;

    [FieldOffset(0)]
    public EntityType entityType;

    [FieldOffset(4)]
    public int entityID;

    public IDSignature(EntityType entityType, int entityID)
    {
        this.value = 0;
        this.entityType = entityType;
        this.entityID = entityID;
    }

    public static bool operator ==(IDSignature a, IDSignature b)
    {
        return a.value == b.value;
    }

    public static bool operator !=(IDSignature a, IDSignature b)
    {
        return a.value != b.value;
    }

    //下面两条重写和上面重载通常同时存在，防止冲突
    public override bool Equals(object obj)
    {
        if (obj is IDSignature)
        {
            return this == (IDSignature)obj;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return value.GetHashCode();
    }
}