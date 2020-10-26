using System;
using System.IO;

namespace Luna.Audio
{
    public struct AudioClip
    {
        public string ReferenceName;
        public FileStream File;
        public AudioType Type;

        public static bool operator ==(AudioClip a, AudioClip b)
            => a.File == b.File && a.ReferenceName.ToLowerInvariant() == b.ReferenceName.ToLowerInvariant() && a.Type == b.Type;

        public static bool operator !=(AudioClip a, AudioClip b)
            => a.File != b.File && a.ReferenceName.ToLowerInvariant() != b.ReferenceName.ToLowerInvariant() && a.Type != b.Type;

        public override bool Equals(Object o)
        {
            if (o is AudioClip obj)
            {
                return this == obj;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ReferenceName.ToLowerInvariant(), File, Type);
        }
    }

    public enum AudioType
    {
        SFX,
        Music
    }
}
