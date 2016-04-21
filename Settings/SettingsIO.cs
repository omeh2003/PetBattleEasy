using System.IO;
using EvilManagerWoD;
using EvilManagerWoD.Classes;
using EvilManagerWoD.ObjectManager;

namespace PetBattleEasy.Settings
{
    public class SettingsIO
    {
        public int AdFactor;
        public int DisFactor;
        public int EnemyLevel;
        public int HpFactor;
        public bool LeaveGame;
        public string NameReg;
        public bool Nonstop;
        public bool On;
        public bool Only1;
        public bool Slot1Swap;
        public int Slot1SwapLevel;
        public bool Slot2Swap;
        public int Slot2SwapLevel;
        public bool Slot3Swap;
        public int Slot3SwapLevel;
        public bool Solo;
        public  bool ImpruvedLogic;


        private static string Path()
        {
            return Core.AssemblyDirectory + "\\Plugins\\PetBattleEasy\\" + ObjectManager.Me.Name + ".xml";
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists(Path())) return;
                var settings = XmlSerializer.Deserialize<SettingsIO>(Path());
                PetBattleEasy.On = settings.On;
                PetBattleEasy.Only1 = settings.Only1;
                PetBattleEasy.Nonstop = settings.Nonstop;
                PetBattleEasy.NameReg = settings.NameReg;
                PetBattleEasy.LeaveGame = settings.LeaveGame;
                PetBattleEasy.Slot1Swap = settings.Slot1Swap;
                PetBattleEasy.Slot2Swap = settings.Slot2Swap;
                PetBattleEasy.Slot3Swap = settings.Slot3Swap;
                PetBattleEasy.Slot1SwapLevel = settings.Slot1SwapLevel;
                PetBattleEasy.Slot2SwapLevel = settings.Slot2SwapLevel;
                PetBattleEasy.Slot3SwapLevel = settings.Slot3SwapLevel;
                PetBattleEasy.Solo = settings.Solo;
                PetBattleEasy.EnemyLevel = settings.EnemyLevel;
                PetBattleEasy.HpFactor = settings.HpFactor;
                PetBattleEasy.DisFactor = settings.DisFactor;
                PetBattleEasy.AdFactor = settings.AdFactor;
                PetBattleEasy.ImpruvedLogic = settings.ImpruvedLogic;
            }
            catch
            {
                // ignored
            }
        }

        public static void Save()
        {
            try
            {
                var settings = new SettingsIO
                {
                    On = PetBattleEasy.On,
                    Only1 = PetBattleEasy.Only1,
                    Nonstop = PetBattleEasy.Nonstop,
                    NameReg = PetBattleEasy.NameReg,
                    LeaveGame = PetBattleEasy.LeaveGame,
                    Slot1Swap = PetBattleEasy.Slot1Swap,
                    Slot2Swap = PetBattleEasy.Slot2Swap,
                    Slot3Swap = PetBattleEasy.Slot3Swap,
                    Slot1SwapLevel = PetBattleEasy.Slot1SwapLevel,
                    Slot2SwapLevel = PetBattleEasy.Slot2SwapLevel,
                    Slot3SwapLevel = PetBattleEasy.Slot3SwapLevel,
                    Solo = PetBattleEasy.Solo,
                    EnemyLevel = PetBattleEasy.EnemyLevel,
                    HpFactor = PetBattleEasy.HpFactor,
                    DisFactor = PetBattleEasy.DisFactor,
                    AdFactor = PetBattleEasy.AdFactor,
                    ImpruvedLogic = PetBattleEasy.ImpruvedLogic
                    
                };
                XmlSerializer.Serialize(Path(), settings);
            }
            catch
            {
                // ignored
            }
        }
    }
}