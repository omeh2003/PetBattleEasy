#region usings

using EvilManagerWoD;
using EvilManagerWoD.AbstractClasses;
using EvilManagerWoD.Helpers.Game;
using EvilManagerWoD.Patchables;
using EvilManagerWoD.WowFunctions;
using PetBattleEasy.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using PetBattleEasy.Settings;
using System.Xml.Serialization;

#endregion usings

namespace PetBattleEasy
{
    
    internal class PetBattleEasy : IPlugin
    {
        #region Standart option plugin

        public override string Author
        {
            get { return "DKBOt"; }
        }

        public override string Description
        {
            get { return "Регер для битвы петов"; }
        }

        public override string Name
        {
            get { return "PetBattleEasy"; }
        }

        public override string Version
        {
            get { return new Version(3, 6, 0, 0).ToString(); }
        }

        #endregion Standart option plugin

        #region Fields and properts

        internal static bool IsEnabled;
        public static bool YaBot;
        public static DateTime Timestartbattle;
        public static bool PVPBattle;

        public static BattlePet.Skills.PetAbilityIndex Oldabily;
        public static bool AttachEvent;
        public static int CountBattle { get; set; }

        public static int Winner { get; set; }

        #endregion Fields and properts

        #region Settings

        public static bool LeaveGame;
        public static string NameReg;
        public static bool Nonstop;
        public static bool On;
        public static bool Only1;
        public static bool Slot1Swap;
        public static bool Slot2Swap;
        public static bool Slot3Swap;
        public static int Slot1SwapLevel;
        public static int Slot2SwapLevel;
        public static int Slot3SwapLevel;
        public static int EnemyLevel;
        public static bool Solo;
        public static int HpFactor;
        public static int DisFactor;
        public static int AdFactor;
        public static bool ImpruvedLogic;


        #endregion Settings

        #region Standart methods plugin

        public override void OnEnable()
        {
            if (IsEnabled) return;
            IsEnabled = true;
            Slot1SwapLevel = 1;
            Slot2SwapLevel = 25;
            Slot3SwapLevel = 25;
            EnemyLevel = 25;
            HpFactor = 31;
            AdFactor = 42;
            DisFactor = 29;
            Globals.CustomClass_OnLoad();
               
            GetAttachEvent();
            Logging.Write("{0} включен {1}", Name, Version);
            Logging.Write("Я - {0}", Game.PlayerName);

            if (Game.GetZoneID == 6771)
            {
                GoldenPet.SetPetForEncounter();
            }
            GoldenPet.UpdateSlot();
            GetPetting.GetPet();
        }

        public override void OnDisable()
        {
            if (!IsEnabled) return;
            IsEnabled = false;
           
            GetDetachEvent();
            Logging.Write("{0} выключен", Name);
        }

        public override void OnLoad()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\PetBattleEasy\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\PetBattleEasy\\");
            }
           // Globals.CustomClass_OnLoad();
        }

        public override void OnUnload()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\PetBattleEasy\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\PetBattleEasy\\");
            }
           GetDetachEvent();

        }

       
        public override void Settings()
        {
            if (Globals.Form != null && !Globals.Form.Visible)
            {
                Globals.CustomClass_Settings();
            }
        }

        #endregion Standart methods plugin

        #region Methods Attach/DeAttach to events wow

        private static void GetAttachEvent()
        {
            if (AttachEvent) return;
            AttachEvent = true;
            Logging.WriteDebug("Атачу евенты");
            SignalEvent.AttachEvent(Enums.EventId.EVENT_CHAT_MSG_WHISPER, Handler_EVENT_CHAT_MSG_WHISPER);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_CHAT_MSG_WHISPER_INFORM, Handler_EVENT_CHAT_MSG_WHISPER_INFORM);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_QUEUE_PROPOSE_MATCH,
                Handler_EVENT_PET_BATTLE_QUEUE_PROPOSE_MATCH);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_CHAT_MSG_BN_WHISPER, Handler_EVENT_CHAT_MSG_BN_WHISPER);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_CHAT_MSG_BN_WHISPER_INFORM,
                Handler_EVENT_CHAT_MSG_BN_WHISPER_INFORM);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_TURN_STARTED, Handler_PET_BATTLE_TURN_STARTED);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_OPENING_DONE, Handler_PET_BATTLE_OPENING_DONE);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE,
                Handler_PET_BATTLE_TURN_END);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_CLOSE, Handler_PET_BATTLE_CLOSE);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_PET_CHANGED, Handler_PET_BATTLE_PET_CHANGED);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_CHAT_MSG_PET_BATTLE_COMBAT_LOG, Handler_COMBATLOG);
            SignalEvent.AttachEvent(Enums.EventId.EVENT_PET_BATTLE_FINAL_ROUND, Handler_EVENT_PET_BATTLE_FINAL_ROUND);
        }

        private static void GetDetachEvent()
        {
           // if (!AttachEvent) return;
            AttachEvent = false;
            Logging.WriteDebug("Детачу евенты");
            SignalEvent.DetachEvent(Enums.EventId.EVENT_CHAT_MSG_WHISPER, Handler_EVENT_CHAT_MSG_WHISPER);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_CHAT_MSG_WHISPER_INFORM, Handler_EVENT_CHAT_MSG_WHISPER_INFORM);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_QUEUE_PROPOSE_MATCH,
                Handler_EVENT_PET_BATTLE_QUEUE_PROPOSE_MATCH);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_CHAT_MSG_BN_WHISPER, Handler_EVENT_CHAT_MSG_BN_WHISPER);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_CHAT_MSG_BN_WHISPER_INFORM,
                Handler_EVENT_CHAT_MSG_BN_WHISPER_INFORM);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_TURN_STARTED, Handler_PET_BATTLE_TURN_STARTED);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_PET_ROUND_PLAYBACK_COMPLETE,
                Handler_PET_BATTLE_TURN_END);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_CLOSE, Handler_PET_BATTLE_CLOSE);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_PET_CHANGED, Handler_PET_BATTLE_PET_CHANGED);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_CHAT_MSG_PET_BATTLE_COMBAT_LOG, Handler_COMBATLOG);
            SignalEvent.DetachEvent(Enums.EventId.EVENT_PET_BATTLE_FINAL_ROUND, Handler_EVENT_PET_BATTLE_FINAL_ROUND);
        }

        #endregion Methods Attach/DeAttach to events wow



        #region Methods plugin

        private static void GetRegStart()
        {
            if (!On) return;
            var milliseconds = (TimeSpan.FromMilliseconds(1000 - DateTime.Now.Millisecond));
            var seconds = TimeSpan.FromSeconds((10 - (DateTime.Now.Second % 10)));
            var timeout = seconds + milliseconds;
            var time = DateTime.Now + timeout;
            Logging.Write("Рега будет в {0}.{1} ", time.Second, time.Millisecond);
            GoldenPet.UpdateSlot();
            //  Thread.Sleep(timeout);

            do
            {
                Thread.Sleep(10);
            } while (DateTime.Now < time);

            BattlePet.Game.StartPVPMatchmaking();
        }

        private static void GetRegStop()
        {
            Logging.Write("Снимаю регу ");
            BattlePet.Game.DeclineQueuedPVPMatch();
            BattlePet.Game.StopPVPMatchmaking();
        }

        #endregion Methods plugin

        #region Handlers

        #region Battle Pet Combat

        private static void Handler_EVENT_PET_BATTLE_FINAL_ROUND(List<string> args)
        {
            if (args[0].ToInt32() == 1)
            {
                Logging.Write("Победа");
                Winner++;
            }
            if (args[0].ToInt32() == 2)
            {
                Logging.Write("Проигрышь");
            }
            CountBattle++;
            Logging.Write("Всего битв:{0} побед:{1}", CountBattle, Winner);
        }

        private static void Handler_PET_BATTLE_OPENING_DONE(List<string> args)
        {
            Stat();
            if (!On) return;
            Logging.Write("начало боя");
          
          
            GoldenPet.NextRound = true;
            GoldenPet.Round = 0;
            Timestartbattle = DateTime.Now;
            if (PVPBattle)
            {
                Logging.WriteDebug("пвп битва");
                BattlePet.Skills.ChangePet(2);
                return;
            }
            GetPetting.GetPet();
            //GoldenPet.Run();
        }

        private static void Stat()
        {
            List<string> setaplist = null;
            if(File.Exists("PetStat.xml"))setaplist = ReadIdList("PetStat.xml");
            if (!File.Exists("PetStat.xml")) setaplist = new List<string>();
            var pet1 = BattlePet.Skills.GetPetSpeciesID(1, BattlePet.Skills.PetOwner.Me);
            var pet2 = BattlePet.Skills.GetPetSpeciesID(2, BattlePet.Skills.PetOwner.Me);
            var pet3 = BattlePet.Skills.GetPetSpeciesID(3, BattlePet.Skills.PetOwner.Me);
            var petE1 = BattlePet.Skills.GetPetSpeciesID(1, BattlePet.Skills.PetOwner.Enemy);
            var petE2 = BattlePet.Skills.GetPetSpeciesID(2, BattlePet.Skills.PetOwner.Enemy);
            var petE3 = BattlePet.Skills.GetPetSpeciesID(3, BattlePet.Skills.PetOwner.Enemy);
            var setap=petE1+" "+petE2+" " + petE3;
            if (setaplist == null) return;
            setaplist.Add(setap);
            SaveIdList("PetStat.xml",setaplist);
        }
        public static void SaveIdList(string filein, List<string> listin)
        {
            var file = filein;
            var list = listin;

            using (var f = File.CreateText(file))
            {
                var writer = new XmlSerializer(list.GetType());

                writer.Serialize(f, list);
            }
        }

        public static List<string> ReadIdList(string filein)
        {
            var file = filein;
            if (!File.Exists(file)) return null;
            var l = new List<string>();
            using (var f = new StreamReader(file))
            {
                var reader = new XmlSerializer(l.GetType());

                l = (List<string>)reader.Deserialize(f);
            }

            return l;
        }

        private static void Handler_PET_BATTLE_TURN_END(List<string> args)
        {
            Logging.Write("Handler_PET_BATTLE_TURN_END");
            Logic.Logic.TurnEnd = true;
            if (!On) return;
#if DEBUG

    Logging.Write("конец хода");
    if (BattlePet.Game.IsWaitingOpponent) Logging.Write("IsWaitingOpponent");
#endif

            if (args == null||args[0]==null)
            {
#if DEBUG
  Logging.WriteDebug("неравно");
#endif


                if (!GoldenPet.CanCast(1) && !GoldenPet.CanCast(2) && !GoldenPet.CanCast(3) && !BattlePet.Game.IsWaitingOpponent)
                {
                    
                    if(BattlePet.Skills.CanPetSwapIn(1))BattlePet.Skills.ChangePet(1);
                    if (BattlePet.Skills.CanPetSwapIn(2)) BattlePet.Skills.ChangePet(2);
                    if (BattlePet.Skills.CanPetSwapIn(3)) BattlePet.Skills.ChangePet(3);
                    if (BattlePet.Game.IsSkipAvailable() && !BattlePet.Game.IsWaitingOpponent)
                    {
                        BattlePet.Skills.SkipMove();
                        return;
                    }
                   // GoldenPet.GetChangePet();
                    return;
                }

                //GoldenPet.Pet[GoldenPet.ActiveSlotMe]();
                return;
            }
            GoldenPet.Round = args[0].ToInt32();
            GoldenPet.NextRound = true;
           GoldenPet.Run();
           // Handler_PET_BATTLE_TURN_STARTED(args);
        }

        private static void Handler_PET_BATTLE_TURN_STARTED(List<string> args)
        {
#if DEBUG
 Logging.Write("PET_BATTLE_TURN_STARTED");
#endif
            Logging.Write("PET_BATTLE_TURN_STARTED");
            if (!GoldenPet.NextRound) return;
            GoldenPet.NextRound = false;

            Logging.Write(GoldenPet.ActiveSlotMe.PetInfo().Name + ". ID:" + GoldenPet.ActiveSlotMe.PetInfo().EntryId + " Slot:" + GoldenPet.ActiveSlotMe + " HP:" + GoldenPet.ActiveSlotMe.PetHP() +
                          " Round:" + GoldenPet.Round+" Поток:"+Thread.CurrentThread.ManagedThreadId);
           
            // Logging.Write("Лучший слот - {0}. Играю - {1}", GoldenPet.BestSlot, GoldenPet.ActiveSlotMe);

            // Logging.WriteDebug(GoldenPet.SpeedMe1 + " " + GoldenPet.SpeedMe2 + " " + GoldenPet.SpeedMe3);
            //Logging.WriteDebug(GoldenPet.SpeedEnemy1 + " " + GoldenPet.SpeedEnemy2 + " " + GoldenPet.SpeedEnemy3);


            GoldenPet.Run();
        }

        private static void Handler_PET_BATTLE_PET_CHANGED(List<string> args)
        {
            if (!On) return;
            Logging.WriteDebug("Смена петов " + args[0]);
            if (args[0] == null || args[0].ToInt32() == 1)
            {
                NextChangePet.Restart();
                return;
            }
            if (GoldenPet.Round <= 0) return;

            //if (GoldenPet.CurrentHp <= 1||(GoldenPet.CurrentHp >= 40 && GoldenPet.CurrentHp <= 80))
            //{
            //    GoldenPet.GetChangePet();

            //}
            if (args[0].ToInt32() == 2&&ImpruvedLogic)
            {
                GoldenPet.GetChangePet();
            }
        }

        public static readonly Stopwatch NextChangePet =new Stopwatch();

        private static async void Handler_PET_BATTLE_CLOSE(List<string> args)
        {
            if (!On) return;
            Logging.Write("Битва окончена.");
            PVPBattle = false;
            if (YaBot) return;
            if (Nonstop && On)
            {
                var pausetime = new Random().Next(10, 18);
                Logging.Write("Оставайтесь с нами, и через {0}секунд мы продолжим", pausetime);
                await Task.Delay(TimeSpan.FromSeconds(pausetime));

                if (!String.IsNullOrEmpty(NameReg) && !String.IsNullOrWhiteSpace(NameReg))
                    Chat.WhisperPlayer(@"++", NameReg);
                if (String.IsNullOrEmpty(NameReg) ||
                    String.IsNullOrWhiteSpace(NameReg)) GetRegStart();
            }
            else if (Solo && On)
            {
                var pausetime = new Random().Next(10, 18);
                Logging.Write("Оставайтесь с нами, и через {0}секунд мы продолжим", pausetime);
                await Task.Delay(TimeSpan.FromSeconds(pausetime));

                GetRegStart();
            }
        }

        private static void Handler_COMBATLOG(List<string> args)
        {
            var str = args[0].Split('|');

            if (!String.IsNullOrWhiteSpace(str[0]) && !String.IsNullOrEmpty(str[0])) Logging.WriteDebug(str[0]);
        }

        #endregion Battle Pet Combat

        private static void Handler_EVENT_CHAT_MSG_BN_WHISPER(List<string> args)
        {
            Handler_EVENT_CHAT_MSG_WHISPER(args);
        }

        private static void Handler_EVENT_CHAT_MSG_WHISPER(List<string> args)
        {
            YaBot = true;
            var message = args[0];
            switch (message)
            {
                case "++":
                    GetRegStart();
                    break;

                case "+++":
                    GetRegStop();
                    break;

                default:
                    Logging.Write("Команда нераспознана ");
                    break;
            }

            if (args.Count == 16 && (String.IsNullOrEmpty(NameReg) || String.IsNullOrWhiteSpace(NameReg)))
            {
                if ((args[1].IndexOf('-') == -1)) NameReg = args[1];
                else if ((args[1].IndexOf('-') > 0))
                {
                    NameReg = args[1].Remove(args[1].IndexOf('-'));
                }

                Logging.Write("Имя игрока определенно как - {0} ", NameReg);
            }
        }

        private static void Handler_EVENT_CHAT_MSG_BN_WHISPER_INFORM(List<string> args)
        {
            Handler_EVENT_CHAT_MSG_WHISPER_INFORM(args);
        }

        private static void Handler_EVENT_CHAT_MSG_WHISPER_INFORM(List<string> args)
        {
            Logging.Write("Отправил сообщение -");
            YaBot = false;
            var message = args[0];
            switch (message)
            {
                case "++":

                    GetRegStart();
                    break;

                case "+++":
                    GetRegStop();
                    break;

                default:
                    Logging.Write("Команда нераспознана ");
                    break;
            }
        }

        private static void Handler_EVENT_PET_BATTLE_QUEUE_PROPOSE_MATCH(List<string> args)
        {
            if (!On) return;
            PVPBattle = true;
            Logging.Write("Рега ===================>>>>> {0} )", DateTime.Now.Ticks);
            //Logging.Write("(Очень желательно что бы эти цифры совпадали)");
            var pausetime = new Random().Next(3, 10);
            //Logging.Write("Делаю паузу {0} сек и вхожу на битву", pausetime);
            Thread.Sleep(TimeSpan.FromSeconds(pausetime));
            BattlePet.Game.AcceptQueuedPVPMatch();
        }

        #endregion Handlers

    }
}