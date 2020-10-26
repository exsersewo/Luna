using System.Collections.Generic;
using System.IO;

namespace Luna.Audio
{
    public class AudioManager
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private static List<AudioClip> audioClips = new List<AudioClip>();
#pragma warning restore IDE0044 // Add readonly modifier

        public static IReadOnlyList<AudioClip> AudioClips { get => audioClips.AsReadOnly(); }

        public static void AddNewClip(AudioClip clip)
            => audioClips.Add(clip);

        public static AudioClip AddNewClip(string refname, FileStream file, AudioType type)
        {
            AudioClip clip = new AudioClip
            {
                ReferenceName = refname,
                File = file,
                Type = type
            };
            audioClips.Add(clip);
            return clip;
        }

        public static void ReplaceClip(AudioClip clip, string refname, FileStream file, AudioType type)
        {
            var oldclip = audioClips.Find(x => x == clip);

            var newclip = new AudioClip()
            {
                ReferenceName = refname,
                File = file,
                Type = type
            };

            audioClips[audioClips.IndexOf(clip)] = newclip;

            oldclip.File.Dispose();
        }

        public static void RemoveClip(AudioClip clip)
            => audioClips.Remove(clip);

        public static void RemoveClip(int clip)
            => audioClips.RemoveAt(clip);

        public static void Dispose()
        {
            foreach(var audioClip in audioClips)
            {
                audioClip.File.Dispose();
                audioClips.Remove(audioClip);
            }
        }
    }
}
