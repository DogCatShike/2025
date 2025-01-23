using System;
using UnityEngine;
using HNY;
using System.Net.Http.Headers;

public static class AudioDomain
{
    public static AudioEntity Spawn(GameContext ctx)
    {
        AudioEntity entity = GameFactory.Audio_Create(ctx);
        ctx.audioRepository.Add(entity);
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
        ctx.audioRepository.Remove(audio);
        audio.TearDown();
    }

    public static void Clear(GameContext ctx)
    {
        int len = ctx.audioRepository.TakeAll(out AudioEntity[] entities);
        for (int i = 0; i < len; i++)
        {
            AudioEntity entity = entities[i];
            TearDown(entity, ctx);
        }
    }
}