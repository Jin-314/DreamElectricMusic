﻿using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMH_Player
{
    public partial class DataClass
    {
        public enum PlayStatus
        {
            Playing,
            Pausing,
            Stopping
        }
        public enum Part
        {
            Melody,
            Guitar,
            Base,
            Drum
        };
        public enum Device
        {
            MotorSolenoid,
            Guitar,
            FloppyDiscDrive,
            Relay
        }
        //ノートの種類
        public enum NoteType
        {
            Off,
            On,
        }
        //テンポを格納する構造体
        public struct TempoData
        {
            public uint eventTime;
            public float bpm;
        };
        public struct FileData
        {
            public string filePath, playlistPath, title;
        }
        public struct PartData
        {
            public Part playPart;
            public Device playDevice;
            public int channel;
            public int harmony;
            public int[] timerIndex;
        }
        //ヘッダーチャンク解析用
        public struct HeaderData
        {
            public byte[] chunkID;
            public int dataLength;
            public short format, tracks, division;
            //トラックチャンク解析用
            public struct TrackData
            {
                public byte[] chunkID, data;
                public int dataLength;
            };
            public TrackData[] trackData;
        };
        //データ
        public struct MidiData
        {
            public double delay;
            public List<Part> playPart;
            public string logTxt;
            public List<byte> serialData, serialRstData;
            public List<MidiMessage> midiMsg, midiRstMsg;
        }
        //デリゲートの構造体
        public struct DelegateData
        {
            public delegate void PlayerButtonDelegate(object sender);
            public delegate void TrackBarDelegate();
        }
    }
}
