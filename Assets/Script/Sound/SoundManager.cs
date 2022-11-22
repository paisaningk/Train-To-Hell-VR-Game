using System;
using System.Collections.Generic;
using System.Linq;
using Script.Singleton;
using UnityEngine;

namespace Script.Sound
{
    public class SoundManager : Singleton<SoundManager>
    {
        public List<SoundData> soundDataSet;
        public AudioSource audioSource;

        public void Play(string id)
        {
            var soundData = soundDataSet.FirstOrDefault(data => data.id == id);

            audioSource.clip = soundData.clip;
            audioSource.Play();
        }
    }

    [Serializable]
    public class SoundData
    {
        public string id;
        public AudioClip clip;
    }
}