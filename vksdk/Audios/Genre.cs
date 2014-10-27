using System;

namespace VK.Audios
{
    public static class Genre
    {
        public const int None = 0;

        public const int Rock = 1;

        public const int Pop = 2;

        public const int RapAndHipHop = 3;

        public const int EasyListening = 4;

        public const int DanceAndHouse = 5;

        public const int Instrumental = 6;

        public const int Metal = 7;

        public const int Dubstep = 8;

        public const int JazzAndBlues = 9;

        public const int DrumAndBass = 10;

        public const int Trance = 11;

        public const int Chanson = 12;

        public const int Ethnic = 13;

        public const int AcousticAndVocal = 14;

        public const int Reggae = 15;

        public const int Classical = 16;

        public const int IndiePop = 17;

        public const int Other = 18;

        public const int Speech = 19;

        public const int Alternative = 21;

        public const int ElectropopAndDisco = 22;

        public static string GetGenreName(int genre)
        {
            switch (genre)
            {
                case None:
                    return VkLocalization.AllGenres;
                case Rock:
                    return VkLocalization.Rock;
                case Pop:
                    return VkLocalization.Pop;
                case RapAndHipHop:
                    return VkLocalization.RapAndHipHop;
                case EasyListening:
                    return VkLocalization.EasyListening;
                case DanceAndHouse:
                    return VkLocalization.DanceAndHouse;
                case Instrumental:
                    return VkLocalization.Instrumental;
                case Metal:
                    return VkLocalization.Metal;
                case Dubstep:
                    return VkLocalization.Dubstep;
                case JazzAndBlues:
                    return VkLocalization.JazzAndBlues;
                case DrumAndBass:
                    return VkLocalization.DrumAndBass;
                case Trance:
                    return VkLocalization.Trance;
                case Chanson:
                    return VkLocalization.Chanson;
                case Ethnic:
                    return VkLocalization.Ethnic;
                case AcousticAndVocal:
                    return VkLocalization.AcousticAndVocal;
                case Reggae:
                    return VkLocalization.Reggae;
                case Classical:
                    return VkLocalization.Classical;
                case IndiePop:
                    return VkLocalization.IndiePop;
                case Speech:
                    return VkLocalization.Speech;
                case Alternative:
                    return VkLocalization.Alternative;
                case ElectropopAndDisco:
                    return VkLocalization.ElectropopAndDisco;
                case Other:
                    return VkLocalization.Other;
                default:
                    return string.Empty;
            }
        }
    }
}
