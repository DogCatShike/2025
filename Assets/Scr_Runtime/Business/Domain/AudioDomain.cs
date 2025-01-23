using System;
using UnityEngine;
using HNY;
using System.Net.Http.Headers;

public static class AudioDomain
{
    public static AudioEntity Spawn(GameContext ctx)
    {
        AudioEntity entity = GameFactory.Audio_Create(ctx);
        return entity;
    }

    public static void SetClip(AudioEntity audio, int noteNumber)
    {
        audio.SetClip(noteNumber);
    }

    public static void Play(AudioEntity audio)
    {
        audio.Play();
    }

    public static void Stop(AudioEntity audio)
    {
        audio.Stop();
    }

    public static void TearDown(AudioEntity audio, GameContext ctx)
    {
        audio.TearDown();
    }
}