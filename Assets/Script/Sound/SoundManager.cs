using System;
using System.Collections.Generic;
using System.Linq;
using Script.Singleton;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Sound
{
    public class SoundManager : Singleton<SoundManager>
    {
        public SoundDataSo soundDataSo;
        public AudioSource audioSource;
        public Transform spawnPoint;

        [Button]
        public void Play(string id)
        {
            var soundData = soundDataSo.soundDataList.FirstOrDefault(data => data.id == id);

            if (soundData != null)
            {
                if (soundData.audioSource == null)
                {
                    soundData.audioSource = Instantiate(audioSource, spawnPoint);
                    soundData.audioSource.clip = soundData.clip;
                    soundData.audioSource.volume = soundData.volume;
                    if (soundData.type == SoundType.Music)
                    {
                        soundData.audioSource.loop = true;
                    }
                }
                soundData.audioSource.Play();
            }
            else
            {
                Debug.LogWarning("can't Found SoundData");
            }
        }

        [Button]
        public void Stop(string id)
        {
            var soundData = soundDataSo.soundDataList.FirstOrDefault(data => data.id == id);
            
            if (soundData != null)
            {
                soundData.audioSource.Stop();
            }
        }
    }
}