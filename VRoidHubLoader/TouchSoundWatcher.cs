using MelonLoader;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Il2CppInterop.Runtime.Attributes;

[RegisterTypeInIl2Cpp]
public class TouchSoundWatcher : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audio;
    private string _lastClip = "";
    private AudioClip[] _clips;

    void Start()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            MelonLogger.Error("Animator not found!");
            return;
        }

        _audio = GetComponent<AudioSource>();
        if (_audio == null)
            _audio = gameObject.AddComponent<AudioSource>();

        _audio.playOnAwake = false;
        _audio.spatialBlend = 0f;
        _audio.loop = false;
        _audio.volume = 1f;
        _audio.pitch = 1f;
        _audio.dopplerLevel = 0f;

        MelonCoroutines.Start(DelayedLoad());
    }

    private string _lastAnimation = "";

    private IEnumerator DelayedLoad()
    {
        yield return null; // wait 1 frame
        LoadSounds();
    }
    private void Update()
    {
        if (_clips == null || _clips.Length == 0)
            return;

        var infos = _animator.GetCurrentAnimatorClipInfo(0);
        if (infos.Length == 0)
            return;

        string current = infos[0].clip.name;

        if (current == _lastAnimation)
            return;

        _lastAnimation = current;

        switch (current)
        {
            case "E1":
                PlayByName("anime-ahh");
                break;

            case "E2":
                PlayByName("yamete-kudasai");
                break;

            case "F1":
                PlayByName("bye-bye");
                break;

            case "F2":
                PlayByName("tuturu_1");
                break;

            case "C1":
                PlayByName("oh-my-god");
                break;

            case "C2":
                PlayByName("onich");
                break;

            case "G2_R":
                PlayByName("girl-uwu");
                break;
            case "G2_L":
                PlayByName("nya");
                break;

            case "D1":
                PlayByName("uwu");
                break;
            case "D2":
                PlayByName("yamete-kudasai");
                break;
        }
    }
    private void PlayByName(string namePart)
    {
        for (int i = 0; i < _clips.Length; i++)
        {
            if (_clips[i] != null && _clips[i].name.ToLower().Contains(namePart.ToLower()))
            {
                _audio.PlayOneShot(_clips[i]);
                return;
            }
        }

        MelonLogger.Warning("Sound not found for: " + namePart);
    }
    private void PlayRandomSound()
    {
        int index = UnityEngine.Random.Range(0, _clips.Length);
        _audio.clip = _clips[index];
        _audio.Play();
    }

    private void LoadSounds()
    {
        string soundFolder = Path.Combine(
            MelonLoader.Utils.MelonEnvironment.GameRootDirectory,
            "Mods",
            "Sounds"
        );

        if (!Directory.Exists(soundFolder))
        {
            MelonLogger.Warning("Sound folder not found: " + soundFolder);
            return;
        }

        var files = Directory.GetFiles(soundFolder, "*.wav");
        _clips = new AudioClip[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            MelonCoroutines.Start(LoadClip(files[i], i));
        }
    }

    private IEnumerator LoadClip(string path, int index)
    {
        byte[] fileData = File.ReadAllBytes(path);

        // Basic WAV header skip (44 bytes)
        int headerSize = 44;

        int totalSamples = (fileData.Length - headerSize) / 2;

        // Remove last ~5ms of audio
        int cutSamples = 220; // ~5ms at 44100 Hz
        int sampleCount = totalSamples - cutSamples;

        if (sampleCount < 0)
            sampleCount = totalSamples;

        float[] samples = new float[sampleCount];

        int offset = headerSize;
        for (int i = 0; i < sampleCount; i++)
        {
            short sample = System.BitConverter.ToInt16(fileData, offset);
            samples[i] = sample / 32768f;
            offset += 2;
        }

        AudioClip clip = AudioClip.Create(
            Path.GetFileNameWithoutExtension(path),
            sampleCount,
            1,
            44100,
            false
        );
        int fadeSamples = 400; // bigger fade

        // Fade in
        for (int i = 0; i < fadeSamples && i < sampleCount; i++)
        {
            float fade = i / (float)fadeSamples;
            samples[i] *= fade;
        }

        // Fade out
        for (int i = 0; i < fadeSamples && i < sampleCount; i++)
        {
            int fadeIndex = sampleCount - 1 - i;
            float fade = i / (float)fadeSamples;
            samples[fadeIndex] *= (1f - fade);
        }
        clip.SetData(samples, 0);

        _clips[index] = clip;

        MelonLogger.Msg("Loaded sound: " + Path.GetFileName(path));

        yield break;
    }
}