﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SRTPluginProviderRE1C.Structs;
using System.Diagnostics;
using System.Reflection;
using SRTPluginProviderRE1C.Structs.GameStructs;

namespace SRTPluginProviderRE1C
{
    public class GameMemoryRE1C : IGameMemoryRE1C
    {
        private const string IGT_TIMESPAN_STRING_FORMAT = @"hh\:mm\:ss";
        public string GameName => "RE1";
        // Versioninfo
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        // GameInfo
        public string GameInfo { get => _gameInfo; set => _gameInfo = value; }
        internal string _gameInfo;

        // Player HP
        public GamePlayer Player { get => _player; set => _player = value;  }
        internal GamePlayer _player;

        public string PlayerName { get => _playerName; set => _playerName = value; }
        internal string _playerName;

        // IGT
        public int IGT { get => _igt; set => _igt = value; }
        internal int _igt;

        // Enemy HP Array
        public EnemyHP[] EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
        internal EnemyHP[] _enemyHealth;

        // Equipped Weapon
        public byte CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }
        internal byte _currentWeapon;

        // Inventory Item Array
        public InventoryEntry[] PlayerInventory { get => _playerInventory; set => _playerInventory = value; }
        internal InventoryEntry[] _playerInventory;

        // Box Inventory Item Array
        public InventoryEntry[] BoxInventory { get => _boxInventory; set => _boxInventory = value; }
        internal InventoryEntry[] _boxInventory;

        public TimeSpan IGTTimeSpan
        {
            get
            {
                TimeSpan timespanIGT;

                if (IGT >= 0f)
                    timespanIGT = TimeSpan.FromSeconds(IGT/30);
                else
                    timespanIGT = new TimeSpan();

                return timespanIGT;
            }
        }

        public string IGTFormattedString => IGTTimeSpan.ToString(IGT_TIMESPAN_STRING_FORMAT, CultureInfo.InvariantCulture);
    }
}
