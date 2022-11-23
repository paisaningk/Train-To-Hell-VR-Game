using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Sound
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Sound", order = 0)]
    public class SoundDataSo : ScriptableObject
    {
        public List<SoundData> soundDataList;
    }

    [Serializable]
    public class SoundData
    {
        public string id;
        public AudioClip clip;
        public SoundType type;
        [Range(0,1)]
        public float volume = 1;
        [HideInInspector]
        public AudioSource audioSource;
    }

    public enum SoundType
    {
        Sfx,
        Music,
    }
}