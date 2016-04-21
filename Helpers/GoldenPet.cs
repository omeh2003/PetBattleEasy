using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EvilManagerWoD;
using EvilManagerWoD.Helpers.Game;
using EvilManagerWoD.ObjectManager;
using EvilManagerWoD.Patchables;

namespace PetBattleEasy.Helpers
{
    public static class GoldenPet
    {
        public static int ActiveSlotMe
        {
            get { return BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Me); }
        }

        public static BattlePet.PetJournal.PetInfo PetInfo(this int slot)
        {
            return GetPetInfo(GetGuidInSlot(slot));
        }

        public static BattlePet.PetJournal.PetInfo Info(int slot)
        {
            return GetPetInfo(GetGuidInSlot(slot));
        }

        public static int ActiveSlotEnemy
        {
            get { return BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Enemy); }
        }

        public static int BestSlot
        {
            get { return SlotBestPet(); }
        }

        public static bool MeBestPet
        {
            get { return ActiveSlotMe == BestSlot; }
        }

        public static int SppedActivePet(this BattlePet.Skills.PetOwner owner)
        {
            return BattlePet.Skills.GetSpeed(owner, GetActiveSlot(owner));

        }

        public static int SpeedEnemy(this int slot)
        {
            return BattlePet.Skills.GetSpeed(BattlePet.Skills.PetOwner.Enemy, slot);
        }

        public static int SpeedMe(this int slot)
        {
            return BattlePet.Skills.GetSpeed(BattlePet.Skills.PetOwner.Me, slot);
        }

        private static void InfoS2()
        {
            var enemy = BattlePet.Skills.GetPetSpeciesID(BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Enemy),
                BattlePet.Skills.PetOwner.Enemy);
            Logging.Write("SpeciID enemy" + enemy);
            Logging.Write("GetNumPets  " + BattlePet.PetJournal.GetNumPets);
            for (int i = 0; i < BattlePet.PetJournal.GetNumPets; i++)
            {
                var pet = BattlePet.PetJournal.GetPetInfoByIndex(i);
                if (pet.SpeciesID == enemy)
                {
                    Logging.Write(pet.EntryId.ToString());
                    Logging.Write(pet.Name);
                    Logging.Write(pet.Stats.ToString());
                    Logging.Write(pet.Level.ToString());
                    Logging.Write(pet.Type.ToString());
                }
            }
        }

        public static  void Run()
        {
            if (DebugPet) InfoS2();
            if (!Logic.Logic.TurnEnd)
            {
                Logging.Write("Ход незавершен. Отмена");
                return;
            }
            GetPetting.GetLeaveGame();
            Logic.Logic.Start();
            Pet[ActiveSlotMe]();
            Logic.Logic.End();
            //Logging.WriteDebug("жду 2 сек - {0}",DateTime.Now.Second);
            //Task.Delay(2000).Wait();
            // Logging.Write("после - {0}", DateTime.Now.Second);
        }

        public static bool DebugPet { get; set; }

        public static int SlotRating(this int petSlot)
        {
            var petLevel = GetPetlevel(petSlot);
            var petHp = PetHP(petSlot);
            var petType = BattlePet.Skills.GetPetType(BattlePet.Skills.PetOwner.Me, petSlot);
            var activeEnemyPet = BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Enemy);
            var enemyType = BattlePet.Skills.GetPetType(BattlePet.Skills.PetOwner.Enemy, activeEnemyPet);
            return BattleRating(petLevel, petHp, petType, enemyType, 25);
        }

        public static IOrderedEnumerable<KeyValuePair<Structs.UInt128, int>> Ratings;

        private static int SlotBestPet()
        {
            var bestslot = 1;
            var slot1 = SlotRating(1);
            var slot2 = SlotRating(2);
            var slot3 = SlotRating(3);
            // Logging.WriteDebug("SlotBestPet: {0} {1} {2}",slot1,slot2,slot3);
            //if (PetBattleEasy.PVPBattle)
            //{
            //    slot1 = SlotRating(1);
            //    slot2 = SlotRating(2);
            //    slot3 = SlotRating(3);
            //    //Logging.WriteDebug("old "+slot1 + " " + slot2 + " " + slot3);

            //}
            //else if (!PetBattleEasy.PVPBattle)
            //{
            //    slot1 = 300;
            //    slot2 = 200;
            //    slot3 = 100;
            //}
            if (!BattlePet.Skills.CanPetSwapIn(1)) slot1 = slot1 - 100000;
            if (!BattlePet.Skills.CanPetSwapIn(2)) slot2 = slot2 - 100000;
            if (!BattlePet.Skills.CanPetSwapIn(3)) slot3 = slot3 - 100000;
            // Logging.WriteDebug("SlotBestPet: {0} {1} {2}", slot1, slot2, slot3);
            //Logging.Write(slot1+" "+" "+slot2+" "+slot3);
            if (slot1 >= slot2 && slot1 >= slot3) bestslot = 1;
            if (slot2 >= slot1 && slot2 >= slot3) bestslot = 2;
            if (slot3 >= slot2 && slot3 >= slot1) bestslot = 3;

            //   Logging.WriteDebug("Лучший слот - " + bestslot);
            return bestslot;
        }

        public static bool CanCast(int i)
        {
            switch (i)
            {
                case 1:
                    return CanCast(BattlePet.Skills.PetAbilityIndex.Ability1);

                case 2:
                    return CanCast(BattlePet.Skills.PetAbilityIndex.Ability2);

                case 3:
                    return CanCast(BattlePet.Skills.PetAbilityIndex.Ability3);
            }

            return false;
        }

        public static bool CanCast(BattlePet.Skills.PetAbilityIndex i)
        {
            return BattlePet.Skills.CanUseAbility(i, BattlePet.Skills.PetOwner.Me,
                BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Me));
        }

        public static void Cast(int i)
        {
            switch (i)
            {
                case 1:
                    Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
                    break;

                case 2:
                    Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
                    break;

                case 3:
                    Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
                    break;
            }
        }

        public static void Cast(BattlePet.Skills.PetAbilityIndex i)
        {
            //if (CanCast(i))
            var abilityInfo = BattlePet.Skills.GetAbilityInfo(BattlePet.Skills.PetOwner.Me, ActiveSlotMe,i);
            BattlePet.Skills.UseAbility(i);
            Logging.WriteDebug(abilityInfo.Name+" - "+abilityInfo.Id);
        }

        public static bool GetChangePet()
        {
           
            if (PetBattleEasy.NextChangePet.IsRunning&&PetBattleEasy.NextChangePet.ElapsedMilliseconds < 10000) return true;
            if (!PetBattleEasy.NextChangePet.IsRunning) PetBattleEasy.NextChangePet.Start();
            PetBattleEasy.NextChangePet.Restart();
            //if (!PetBattleEasy.NeedToSwap) return;
            //if (DateTime.Now < PetBattleEasy.TimeNewWantSwaping) return;

            //var i = 0;
            //while (!MeBestPet)
            //{
           // PetBattleEasy.ImpruvedLogic = true;
            if (!PetBattleEasy.ImpruvedLogic) return false;
            if (MeBestPet || !CanChange(BestSlot)) return true;
            BattlePet.Skills.ChangePet(BestSlot);
            return true;
            //    i++;
            //    if (i >= 10) break;
            //    if (PetHP(BestSlot) < 2) break;
            //    if (!CanChange(BestSlot)) break;
            //}
            //PetBattleEasy.TimeNewWantSwaping = DateTime.Now + TimeSpan.FromSeconds(10);
        }

        private static bool CanChange(this int i)
        {
            return BattlePet.Skills.CanActivePetSwapOut() && BattlePet.Skills.CanPetSwapIn(i);
        }

        public static int GetPetlevel(this int slot)
        {
            var id = BattlePet.PetJournal.GetActivePetIDBySlot(slot);
            var petinfo = BattlePet.PetJournal.GetPetInfoByPetID(id);
            return petinfo.Level;
        }

        public static int PetHP(this int slot)
        {
            return BattlePet.Skills.PetHealthPercent(BattlePet.Skills.PetOwner.Me, slot);
        }

        public static void UpdateSlot()
        {
            if (!PetBattleEasy.Slot1Swap) return;

            Logging.Write("1-{0} 2-{1} 3-{2}", GetPetFromLevel(PetBattleEasy.Slot1SwapLevel).Name, GetPetFromLevel(PetBattleEasy.Slot2SwapLevel).Name, GetPetFromLevel(PetBattleEasy.Slot3SwapLevel).Name);
            if (PetBattleEasy.Slot1Swap) BattlePet.PetJournal.SetPetToSlot(1, GetPetFromLevel(PetBattleEasy.Slot1SwapLevel).PetID);
            if (PetBattleEasy.Slot2Swap) BattlePet.PetJournal.SetPetToSlot(2, GetPetFromLevel(PetBattleEasy.Slot2SwapLevel).PetID);
            if (PetBattleEasy.Slot3Swap) BattlePet.PetJournal.SetPetToSlot(3, GetPetFromLevel(PetBattleEasy.Slot3SwapLevel).PetID);
        }

        private static BattlePet.PetJournal.PetInfo GetPetFromLevel(int level, BattlePet.PetJournal.PetRarity rarity = BattlePet.PetJournal.PetRarity.Rare)
        {
            return BattlePet.PetJournal.MyPets.FirstOrDefault(u => u.Level == level &&
                                                                   u.Stats.Rarity ==
                                                                   rarity &&
                                                                   u.CanBattle &&
                                                                   u.IsAlive &&
                                                                   u.IsValid);
        }

        public static BattlePet.PetJournal.PetInfo GetPetFromEntryID(int entryID)
        {
            return BattlePet.PetJournal.MyPets.FirstOrDefault(u => u.Level == 25  &&
                                                                   u.EntryId == entryID &&
                                                                   u.CanBattle &&
                                                                   u.IsAlive &&
                                                                   u.IsValid);

        }

        public static int GetActiveSlot(BattlePet.Skills.PetOwner owner)
        {
            return BattlePet.Skills.GetPetActive(owner);
        }

        public static int GetActiveSlotEnemy()
        {
            return BattlePet.Skills.GetPetActive(BattlePet.Skills.PetOwner.Enemy);
        }

        public static Structs.UInt128 GetGuidInSlot(int slot)
        {
            return BattlePet.PetJournal.GetActivePetIDBySlot(slot);
        }

        /*
                private static BattlePet.PetJournal.PetInfo GetPetInfo(int slot)
                {
                    return GetPetInfo(GetGuidInSlot(slot));
                }
        */

        public static BattlePet.PetJournal.PetInfo GetPetInfo(Structs.UInt128 petGuid)
        {
            return BattlePet.PetJournal.GetPetInfoByPetID(petGuid);
        }

        public static Action Slot1;
        public static Action Slot2;
        public static Action Slot3;
        public static Action[] Pet = { Slot1, Slot2, Slot3 };
        public static int Round;
        public static bool NextRound;

        private static int SmartChoiceTakeLessDMG(int enemytype)
        {
            if (enemytype > 10 || enemytype < 0) enemytype = 1;
            int[] smart = { 0, 8, 4, 2, 9, 1, 10, 5, 3, 6, 7 };
            return smart[enemytype];
        }

        private static int SmartChoiceDealMoreDMG(int enemytype)
        {
            if (enemytype > 10 || enemytype < 0) enemytype = 1;
            int[] smart = { 0, 4, 1, 6, 5, 8, 2, 9, 10, 3, 7 };
            return smart[enemytype];
        }

        private static int DumbChoiceDealLessDMG(int enemytype)
        {
            if (enemytype > 10 || enemytype < 0) enemytype = 1;
            int[] smart = { 0, 5, 3, 8, 2, 7, 9, 10, 1, 4, 6 };
            return smart[enemytype];
        }

        private static int DumbChoiceTakeMoreDMG(int enemytype)
        {
            if (enemytype > 10 || enemytype < 0) enemytype = 1;
            int[] smart = { 0, 2, 6, 9, 1, 4, 3, 10, 5, 7, 8 };
            return smart[enemytype];
        }

        public static int BattleRating(int petLevel, int petHP, int petType, int enemytype, int enemylevel)
        {
            var advantage = 0;
            var disadvantage = 0;

            var mypet = petType;

            //Logging.Write("Pet Type : " + mypet);
            int rating;
            //Logging.Write("target type " + enemytype);
            if (mypet == DumbChoiceTakeMoreDMG(enemytype)) disadvantage = -2;

            if (mypet == DumbChoiceDealLessDMG(enemytype)) disadvantage = disadvantage - 1; //rating -1;
            if (mypet == SmartChoiceTakeLessDMG(enemytype)) advantage = 1;

            if (mypet == SmartChoiceDealMoreDMG(enemytype)) advantage = advantage + 2;

            /*****************************************/

            var s = petHP * PetBattleEasy.HpFactor;

            var total = s;

            //s = "advantage * 50 * AdFactor";
            s = advantage * 50 * PetBattleEasy.AdFactor;

            total = total + s;

            // s = "disadvantage * 50 * DisFactor";
            s = disadvantage * 50 * PetBattleEasy.DisFactor;

            total = total + s;

            s = (petLevel - enemylevel) * 4 * 0;

            total = total + s;

            rating = total;

            if (petHP < 30) rating = rating - 10000;
            if (petHP < 15) rating = rating - 40000;
            if (petHP < 5) rating = rating - 50000;

            return rating;
        }

        //        private static int BattleRatingExp(int petLevel, int petHP, int petType, int enemytype, int enemylevel)
        //        {
        //            var advantage = 0;
        //            var disadvantage = 0;
        //
        //            var mypet = petType;
        //
        //            //Logging.Write("Pet Type : " + mypet);
        //            int rating;
        //            //Logging.Write("target type " + enemytype);
        //            if (mypet == DumbChoiceTakeMoreDMG(enemytype)) disadvantage = -2;
        //
        //            if (mypet == DumbChoiceDealLessDMG(enemytype)) disadvantage = disadvantage - 1; //rating -1;
        //            if (mypet == SmartChoiceTakeLessDMG(enemytype)) advantage = 1;
        //
        //            if (mypet == SmartChoiceDealMoreDMG(enemytype)) advantage = advantage + 2;
        //
        //            /*****************************************/
        //
        //            var s = "1 + 1 * 3";
        //
        //            Calculate(s);
        //            int total;
        //
        //            //pet 1
        //
        //            var HPformula = "petHP * HPFactor";
        //            s = HPformula;
        //            var hpFactor = PetBattleEasy.HpFactor.ToString();
        //            s = s.Replace("petHP", petHP.ToString()).Replace("HPFactor", hpFactor);
        //
        //            var hPresult = Calculate(s);
        //            total = Int32.Parse(hPresult.ToString());
        //
        //            s = "advantage * 50 * AdFactor";
        //            var adFactor = PetBattleEasy.AdFactor.ToString();
        //            s = s.Replace("advantage", advantage.ToString()).Replace("AdFactor", adFactor);
        //
        //            var adresult = Calculate(s);
        //            total = total + Int32.Parse(adresult.ToString());
        //
        //            s = "disadvantage * 50 * DisFactor";
        //            var disFactor = PetBattleEasy.DisFactor.ToString();
        //            s = s.Replace("disadvantage", disadvantage.ToString()).Replace("DisFactor", disFactor);
        //
        //            var disresult = Calculate(s);
        //            total = total + Int32.Parse(disresult.ToString());
        //
        //            s = "(petLevel - enemylevel) * 4 * LevelFactor";
        //            s =
        //                s.Replace("petLevel", petLevel.ToString())
        //                    .Replace("enemylevel", enemylevel.ToString())
        //                    .Replace("LevelFactor", "0");
        //
        //            var levelresult = Calculate(s);
        //            total = total + Int32.Parse(levelresult.ToString());
        //
        //            rating = total;
        //
        //            if (petHP < 30) rating = rating - 10000;
        //            if (petHP < 15) rating = rating - 40000;
        //            if (petHP < 5) rating = rating - 50000;
        //
        //            return rating;
        //        }

        /*
                private static int Calculate(string s)
                {
                    var ce = new CE.CalcEngine();
                    var x = ce.Parse(s);

                    var value = x.Evaluate();
                    return Int32.Parse(value.ToString(), CultureInfo.InvariantCulture);
                }
        */

        public static void CheckingPetForCell()
        {
            var listall = new Tournamet().NeedPets;
            foreach (var i in listall)
            {
                var pet = GetPetFromEntryID(i);
                if (pet.IsValid) Logging.Write(pet.Name + " есть.");
                if (!pet.IsValid) Logging.Write(i + " отсутсвует в списке петов.");
            }
        }

        public static void SetPetForEncounter()
        {
            var id = 0;
            if (ObjectManager.Target != null)
            {
                id = ObjectManager.Target.Entry;
            }

            var objectType = new Tournamet();

            var name = "Npc" + id;
            var methodInfo = objectType.GetType().GetField(name);
            if (methodInfo != null)
            {
                Logging.Write(Color.MediumSpringGreen, "Найдены петы для  ID:{0} ", id);
                List<int> list = methodInfo.GetValue(objectType) as List<int>;
                var inx = 1;
                foreach (var str in from object str in (IEnumerable) list where str != null select str)
                {
                    var originalid = (int) str;
                    Logging.Write(str.ToString());
                    var pet = GetPetFromEntryID(originalid);
                    if (pet.IsValid) BattlePet.PetJournal.SetPetToSlot(inx, pet.PetID);
                    if (!pet.IsValid && objectType.PetsForChange.ContainsKey(originalid))
                    {
                        Logging.Write("Есть замена");
                       
                        var newid = objectType.PetsForChange.FirstOrDefault(key => key.Key == originalid).Value;
                        Logging.Write(newid.ToString());
                        var newpet = GetPetFromEntryID(newid);
                        Logging.Write(newpet.Name);
                        if (newpet.IsValid) BattlePet.PetJournal.SetPetToSlot(inx, newpet.PetID);
                    }
                    inx++;
                }
            }
        }
    }
}