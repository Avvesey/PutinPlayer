using System;
using Un4seen.Bass;


namespace WindowsFormsPlayer
{
    public static class SubBass
    {
        // частота дискретизации
        private static int hz = 44100;

        //состояние инициализации
        public static bool InitDefaultDevice;

        // канал
        public static int Streem;

        // громкость 
        public static int Volume = 100;

       public static bool check = false;

        // методы
        //инициализация библеотеки
        private static bool InitBass(int hz)
        {
            if (!InitDefaultDevice)

                InitDefaultDevice = Bass.BASS_Init(-1, hz, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            return InitDefaultDevice;




        }


        //play
        public static void PLay(string file, int volume)
        {
            
            Stop();
            check = true;
            if (InitBass(hz))
            {
                Streem = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_DEFAULT);
                if (Streem != 0)
                {
                    Volume = volume;
                    Bass.BASS_ChannelSetAttribute(Streem, BASSAttribute.BASS_ATTRIB_VOL, volume / 100);
                    Bass.BASS_ChannelPlay(Streem, false);
                }
            }
        }



        // стоп
        public static void Stop()
        {
            Bass.BASS_ChannelStop(Streem);
            Bass.BASS_StreamFree(Streem);

        }
        // уствновка громкости
        public static void SetVolumeToStream(int stream, int vol)
        {
            Volume = vol;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, vol / 100F);
        }

        //Длительность трека 
        public static int GetTimeOfTrackSteam(int stream)
        {
            long TimeBites = Bass.BASS_ChannelGetLength(stream);
            double Time = Bass.BASS_ChannelBytes2Seconds(stream, TimeBites);
            return (int)Time;


        }

        //получение позиции в секундах
        public static int GetPositionOfStream(int stream)
        {
            long pos = Bass.BASS_ChannelGetPosition(stream);
            double posSec = Bass.BASS_ChannelBytes2Seconds(stream, pos);
            return (int)posSec;

        }
        // перемотка
        public static void SetPosOfScroll(int stream, int pos)
        {
            Bass.BASS_ChannelSetPosition(stream, (double)pos);
        }

        public static void Pause()
        {
            Bass.BASS_ChannelPause(Streem);
        }

        public static void Chanel_play()
        {
            Bass.BASS_ChannelPlay(Streem, false);
        }

      
    }

}
