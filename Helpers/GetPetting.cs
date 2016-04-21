using EvilManagerWoD;
using EvilManagerWoD.Helpers.Game;
using System;
using System.Drawing;

namespace PetBattleEasy.Helpers
{
    public static class GetPetting
    {
        public static void GetLeaveGame()
        {
            //
            if (PetBattleEasy.YaBot && PetBattleEasy.LeaveGame && (DateTime.Now - PetBattleEasy.Timestartbattle > TimeSpan.FromMinutes(2)))
            {
                Logging.Write("Слив - {0}", DateTime.Now - PetBattleEasy.Timestartbattle);
                BattlePet.Game.ForfeitGame();
            }
        }

        private static void GetCastInstant()
        {
            //var petcurent =BattlePet.PetJournal.GetPetInfoByPetID(BattlePet.PetJournal.GetActivePetIDBySlot(BattlePet.PetJournal.PetSlotAvailable));
            //if (petcurent.EntryId == 71488)
            //{
            //    Logging.Write("Играю Деревом");
            //    Logic.Logic.Npc71488();
            //    return;
            //}
            //if (petcurent.EntryId == 68659)
            //{
            //    Logging.Write("Играю анубисата");
            //    Logic.Logic.Npc68659();
            //    return;
            //}
            var best = BattlePet.Skills.GetBestAbility();
            // Logging.Write(CanCast(1).ToString());
            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability1) && best == PetBattleEasy.Oldabily)
            {
                PetBattleEasy.Oldabily = BattlePet.Skills.PetAbilityIndex.Ability1;
                GoldenPet.Cast(PetBattleEasy.Oldabily);
                return;
            }
            if (best != PetBattleEasy.Oldabily && GoldenPet.CanCast(best))
            {
                PetBattleEasy.Oldabily = best;

                GoldenPet.Cast(best);
            }
            //await Task.Delay(1000);

            //Lua.FrameScript_Execute("C_PetBattles.SkipTurn()");
        }

        private static void GetOnly1()
        {
            Logging.Write("Мой ход ");

            GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
        }

        public static void GetPet()
        {
            GoldenPet.Pet = new Action[4];
            GoldenPet.DebugPet = false;
            GoldenPet.Slot1 = ParseLogic(1);
            GoldenPet.Slot2 = ParseLogic(2);
            GoldenPet.Slot3 = ParseLogic(3);
            GoldenPet.Pet[1] = GoldenPet.Slot1;
            GoldenPet.Pet[2] = GoldenPet.Slot2;
            GoldenPet.Pet[3] = GoldenPet.Slot3;
        }

        private static Action _act;

        private static Action ParseLogic(this int slot)
        {
            _act = null;
            var petGuid = GoldenPet.GetGuidInSlot(slot);
            var petInfo = GoldenPet.GetPetInfo(petGuid);
            var objectType = new Logic.Logic();
            var name = "Npc" + petInfo.EntryId;
            var methodInfo = objectType.GetType().GetMethod(name);
            if (methodInfo != null)
            {
                Logging.Write(Color.MediumSpringGreen, "Найдена логика для пета ID:{0} из слота:{1}", petInfo.EntryId, slot);
                Action method = delegate { methodInfo.Invoke(objectType, null); };
                _act = method;
            }
            if (methodInfo != null) return _act;
            Logging.Write(Color.MediumSpringGreen, "Не найдена логика для пета ID:{0} из слота:{1}", petInfo.EntryId, slot);
            if (PetBattleEasy.Only1) _act = GetOnly1;
            if (!PetBattleEasy.Only1) _act = GetCastInstant;

            //_act += delegate { GoldenPet.GetChangePet(); };

            return _act;
        }
    }
}