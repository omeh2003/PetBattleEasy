using System.Threading;
using EvilManagerWoD;
using EvilManagerWoD.Helpers.Game;
using EvilManagerWoD.ObjectManager;
using EvilManagerWoD.Patchables;
using PetBattleEasy.Helpers;

namespace PetBattleEasy.Logic
{
    internal class Logic
    {
        #region Class

        private static bool CommandHasBuff(int skill, BattlePet.Skills.PetOwner petOwner)
        {
            var find = false;

            for (var i = 0; i <= 3; i++)
            {
                var count = BattlePet.Skills.GetNumAuras(petOwner, i);
                for (var j = 0; j <= count; j++)
                {
                    var info = BattlePet.Skills.GetAuraInfo(petOwner, i, j);

                    if (info.AuraId != skill) continue;
                    Logging.WriteDebug(info.AuraId + " " + info.InstanceId + " " + info.IsBuff + " " + " " +
                                  info.TurnsRemaining);
                                  //проверку на скорость
                    if (info.TurnsRemaining > 1 || info.TurnsRemaining == -1)
                    {
                       
                        


                            find = true;
                        
                    }

                    if (info.TurnsRemaining == 1)
                    {
                        if (GoldenPet.ActiveSlotMe.SpeedMe() > GoldenPet.ActiveSlotEnemy.SpeedEnemy())
                        {


                            find = true;
                        }
                        


                            
                        
                    }




                }
            }

            return find;
        }

        private static bool EnemyHaveBuff(string skill)
        {
            return BattlePet.Skills.HasAuraByName(BattlePet.Skills.PetOwner.Enemy, skill);//|| TurnsBuffOk(skill) == 1;
        }

        public  static void Start()
        {
            if (GoldenPet.ActiveSlotMe.PetHP() <= 2&&PetBattleEasy.ImpruvedLogic)
            {
                Logging.WriteDebug("HP < 2");
                BattlePet.Skills.ChangePet(GoldenPet.BestSlot);
            }
            //CommandHasBuff(510);
            while (BattlePet.Game.IsWaitingOpponent)
            {
                Logging.WriteDebug("Wait Opponent");
               Thread.Sleep(500);
            }
        }

        public static void End()
        {
            TurnEnd = false;
            GoldenPet.NextRound = true;
            if (BattlePet.Skills.HasAuraById(BattlePet.Skills.PetOwner.Me, 927))
            {
                Logging.Write("Пропускаю");
                Lua.FrameScript_Execute("C_PetBattles.SkipTurn()");

                // if (BattlePet.Game.IsSkipAvailable())PetBattleEasy.Cast(BattlePet.Skills.PetAbilityIndex.SkipMove);
            }
            if(!GoldenPet.MeBestPet&&PetBattleEasy.ImpruvedLogic)GoldenPet.GetChangePet();
         
            Logging.Write("Ход завершен");
        }

        public static bool TurnEnd { get; set; }

        #endregion Class

        #region Logics

        public static void Npc23274()
        {
            //вонюща
            Logging.Write("Внимание!!! Работает логика турнира небожителей");
            if (GoldenPet.CanCast(3))
            {
                GoldenPet.Cast(3);
                return;
            }
            BattlePet.Game.ForfeitGame();
        }   
        
        public static void Npc68658()
        {
            //Маленький поглотитель разума
            if (FastAll(2, 3, 1)) return;
            if (!GoldenPet.CanCast(1) && GoldenPet.CanCast(2) && !GoldenPet.CanCast(3))
            {
                Lua.FrameScript_Execute("C_PetBattles.SkipTurn()");
                return;
            }
            Logging.WriteDebug("Конец логики");
        }

        private static bool FastAll(int spell1, int spell2, int spell3)
        {
            if (Fast(spell1)) return true;
            return Fast(spell2) || Fast(spell3);
        }

        private static bool Fast(int spell)
        {
            if (!GoldenPet.CanCast(spell)) return false;
            GoldenPet.Cast(spell);
            return true;
        }

        public static void Npc73364()
        {
            //смертолаза
            if(FastAll(3,2,1))return;
            Logging.WriteDebug("Конец логики");
         
        }

        public static void Npc64899()
        {
            //Механический пандаренский дракончик

            if (GoldenPet.CanCast(3))
            {
                GoldenPet.Cast(3);
                return;
            }
            if (GoldenPet.CanCast(2) && (BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Enemy) > 1))
            {
                GoldenPet.Cast(2);
                return;
            }
            if (CommandHasBuff(333, BattlePet.Skills.PetOwner.Me))
            {
                GoldenPet.Cast(1);
                return;
            }
            if (!CommandHasBuff(333, BattlePet.Skills.PetOwner.Me) && !GoldenPet.CanCast(3)&&BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Me)==3)
            {
               
                if (BattlePet.Skills.CanUseAbility(BattlePet.Skills.PetAbilityIndex.Ability3, BattlePet.Skills.PetOwner.Me, 2))
                {
                    BattlePet.Skills.ChangePet(2);
                    return;
                }
                if ((3.PetHP() > 1.PetHP()+10)&&GoldenPet.ActiveSlotMe!=3)
                {
                    BattlePet.Skills.ChangePet(3);
                    return;
                }
                if ((1.PetHP() > 3.PetHP() + 10) && GoldenPet.ActiveSlotMe != 1)
                {
                    BattlePet.Skills.ChangePet(1);
                    return;
                }
            }
   
            GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
        }

        public static void Npc24388()
        {
            //Зубастик

            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3) && !CommandHasBuff(491, BattlePet.Skills.PetOwner.Enemy)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3) && CommandHasBuff(491, BattlePet.Skills.PetOwner.Enemy)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
        }

        public static void Npc69796()
        {
            //Ногокус
            if (!EnemyHaveBuff("Черный коготь") && GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability1))
            {
                Logging.WriteDebug("Нет бафа когтя. Бью");
                GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
            }

            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability1)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            BattlePet.Skills.ChangePet(2);
        }

        public static void Npc72462()
        {
            //чи-чи
            var hp = GoldenPet.GetActiveSlot(BattlePet.Skills.PetOwner.Me).PetHP();
            if (!CommandHasBuff(255, BattlePet.Skills.PetOwner.Me))
            {
                if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability2))
                {
                    GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
                }
            }
            if (hp < 60 && GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
        }

        public static void Npc88401()
        {
            //Сетте
           if(FastAll(2,3,1))return;
            Logging.Write("Конец");
        }

        public static void Npc55367()
        {
            //Дирижабль ярмарки Новолуния

            #region Логика турнира небожителей

            if (Game.GetZoneID == 6771)
            {
                Logging.Write("Логика турнира небожителей");
                var id = ObjectManager.Target.Entry;

                #region 72009/72290

                if (id == 72009 || id == 72290)
                {
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }
                    if (!GoldenPet.CanCast(3) && !GoldenPet.CanCast(2))
                    {
                        BattlePet.Skills.ChangePet(2);
                        return;
                    }
                    return;
                }

                #endregion


                #region 72291

                if (id == 72291)
                {
                    if (GoldenPet.Round >= 4)
                    {
                        if (!GoldenPet.CanCast(2)) return;
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }
                    if (!GoldenPet.CanCast(3))
                    {
                        BattlePet.Skills.ChangePet(2);
                        return;
                    }
                    return;
                }

                #endregion


                Logging.Write(id.ToString());
                return;
            }

            #endregion


            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability2)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
            if (CommandHasBuff(333, BattlePet.Skills.PetOwner.Me))
            {
                GoldenPet.Cast(1);
                return;
            }
            if (!CommandHasBuff(333, BattlePet.Skills.PetOwner.Me) && !GoldenPet.CanCast(3) && BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Me) == 3)
            {

                if (BattlePet.Skills.CanUseAbility(BattlePet.Skills.PetAbilityIndex.Ability3, BattlePet.Skills.PetOwner.Me, 2)) BattlePet.Skills.ChangePet(2);
                if (1.PetHP() > 3.PetHP()+10) BattlePet.Skills.ChangePet(1);
            }

            GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);

            //var hp = GoldenPet.GetActiveSlot(BattlePet.Skills.PetOwner.Me).PetHP();
            //var enemyhp = BattlePet.Skills.GetHealth(BattlePet.Skills.PetOwner.Enemy, GoldenPet.GetActiveSlotEnemy());
            //Logging.WriteDebug("hp " + hp + " enemyhp " + enemyhp);
            //if (enemyhp < 618) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
            //if (hp >= 80) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
            //if (hp < 80)
            //{
            //    if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            //}
            //if (CommandHasBuff(244, BattlePet.Skills.PetOwner.Me)) GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
            //GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
        }

        public static void Npc66950()
        {
            //Дух воды

            #region Логика турнира

            if (Game.GetZoneID == 6771)
            {
                Logging.Write("Логика турнира небожителей");
                var id = ObjectManager.Target.Entry;

                #region 72009/72290

                if (id == 72009 || id == 72290)
                {
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (!GoldenPet.CanCast(3) && !GoldenPet.CanCast(2))
                    {
                        BattlePet.Skills.ChangePet(3);
                        return;
                    }
                    return;
                }

                #endregion

                #region 72285

                if (id == 72285)
                {
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (!GoldenPet.CanCast(3) && !GoldenPet.CanCast(2))
                    {
                        BattlePet.Skills.ChangePet(2);
                        return;
                    }

                    return;
                }

                #endregion

                #region 72291

                if (id == 72291)
                {

                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }

                    if (!GoldenPet.CanCast(3) && !GoldenPet.CanCast(2))
                    {
                        BattlePet.Skills.ChangePet(3);
                        return;
                    }
                    return;
                }

                #endregion


                Logging.Write(id.ToString());
                return;
            }

            #endregion

            if(FastAll(3,2,1))return;
            Logging.Write("Обычная логика");
            
          
        }

        public static void Npc68662()
        {
            //Хромний

            #region Логика турнира

            if (Game.GetZoneID == 6771)
            {
                Logging.Write("Логика турнира небожителей");
                var id = ObjectManager.Target.Entry;

                #region 72009/72290

                if (id == 72009 || id == 72290)
                {
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }

                    return;
                }

                #endregion

                #region 72285

                if (id == 72285)
                {
                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }


                    return;
                }

                #endregion

                #region 72291

                if (id == 72291)
                {
                    if (!GoldenPet.CanCast(3))
                    {
                        if (BattlePet.Skills.CanPetSwapIn(1))
                        {
                            BattlePet.Skills.ChangePet(1);
                            return;
                        }
                        return;
                    }

                    if (GoldenPet.CanCast(2))
                    {
                        GoldenPet.Cast(2);
                        return;
                    }
                    if (GoldenPet.CanCast(3))
                    {
                        GoldenPet.Cast(3);
                        return;
                    }

      
                    return;
                }

                #endregion
                Logging.Write(id.ToString());
                return;
            }

            #endregion

           if(FastAll(2,3,1))return;
            Logging.Write("Обычная логика");

        }


        public static void Npc77221()
        {
            //Железная звездочка
            if (CommandHasBuff(207, BattlePet.Skills.PetOwner.Me) && CommandHasBuff(458, BattlePet.Skills.PetOwner.Me)) GoldenPet.Cast(1);
            if (!CommandHasBuff(458, BattlePet.Skills.PetOwner.Me)) GoldenPet.Cast(1);
            if (!CommandHasBuff(207, BattlePet.Skills.PetOwner.Me) && GoldenPet.CanCast(3)) GoldenPet.Cast(3);
            if (!CommandHasBuff(639, BattlePet.Skills.PetOwner.Enemy)) GoldenPet.Cast(2);
            GoldenPet.Cast(1);
        }

        public static void Npc68659()
        {
            //анубисата
            if(FastAll(2,3,1))return;
            Logging.Write("Обычная логика");
        }

        public static void Npc71014()
        {
            //Злой и страшный волчок

            if (FastAll(2, 3, 1)) return;
            Logging.Write("Обычная логика");
        }

        public static void Npc18839()
        {
            //Волшебный рак

            if (!CommandHasBuff(510, BattlePet.Skills.PetOwner.Me)) GoldenPet.Cast(2);

            if (GoldenPet.ActiveSlotMe.PetHP() <= 70 && GoldenPet.CanCast(3)) GoldenPet.Cast(3);
            if (CommandHasBuff(510, BattlePet.Skills.PetOwner.Me) && !GoldenPet.CanCast(3))
            {

                if (GoldenPet.Info(1).Stats.HealthPercentage < GoldenPet.ActiveSlotMe.PetHP()&&GoldenPet.ActiveSlotMe!=1) BattlePet.Skills.ChangePet(1);
                if (GoldenPet.Info(2).Stats.HealthPercentage < GoldenPet.ActiveSlotMe.PetHP() && GoldenPet.ActiveSlotMe != 2) BattlePet.Skills.ChangePet(2);
                if (GoldenPet.Info(3).Stats.HealthPercentage < GoldenPet.ActiveSlotMe.PetHP() && GoldenPet.ActiveSlotMe != 3) BattlePet.Skills.ChangePet(3);
            }

            GoldenPet.Cast(1);
        }

        public static void Npc71488()
        {
            //  Logging.Write(aura.AuraId+" "+aura.TurnsRemaining);
            //Цветущее древо
            if (GoldenPet.CanCast(3)&&GoldenPet.ActiveSlotMe.PetHP()<=80)
            {
                GoldenPet.Cast(3);
                return;
            }

            if (!CommandHasBuff(267, BattlePet.Skills.PetOwner.Me))
            {
                Logging.Write("Фотосинтез");

                GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability2);
                return;
            }
            //if (GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability3))
            //{
            //    GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability3);
            //    // return;
            //}
            if (!CommandHasBuff(961, BattlePet.Skills.PetOwner.Me) &&
                GoldenPet.CanCast(BattlePet.Skills.PetAbilityIndex.Ability1))
            {
                Logging.Write("Кора");

                GoldenPet.Cast(BattlePet.Skills.PetAbilityIndex.Ability1);
                return;
            }

            if(Fast(1))return;
            Logging.Write("Обычная логика");
        }

        public static void Npc45340()
        {
            //Ископаемый детеныш
            if (GoldenPet.CanCast(3) && BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Enemy) > 1)
            {
                GoldenPet.Cast(3);
                return;
            }
            if (GoldenPet.CanCast(2) && GoldenPet.ActiveSlotMe.PetHP() >= 15 && GoldenPet.ActiveSlotMe.PetHP() <= 70)
            {
                GoldenPet.Cast(2);
                return;
            }
            if(Fast(1))return;
            Logging.Write("Обычная логика");

        }
 
        public static void Npc71033()
        {
            //Злобный бес
            if (!CommandHasBuff(408, BattlePet.Skills.PetOwner.Me))
            {
                GoldenPet.Cast(2);
                return;
            }
            if (GoldenPet.ActiveSlotEnemy.PetInfo().Type == Enums.WoWCombatPetType.Mechanical &&
                GoldenPet.ActiveSlotMe.PetHP() >= 70)
            {
                GoldenPet.Cast(1);
                return;
            }
            if (GoldenPet.CanCast(3))
            {
                GoldenPet.Cast(3);
                return;
            }

            if (!GoldenPet.CanCast(3) && CommandHasBuff(408, BattlePet.Skills.PetOwner.Me) && (GoldenPet.ActiveSlotMe.PetHP() + 10 < 1.PetHP()) || (GoldenPet.ActiveSlotMe.PetHP() + 10 < 3.PetHP()) && BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Me) == 3)
            {
                if (1.PetHP() > 3.PetHP())   BattlePet.Skills.ChangePet(1);
                if (1.PetHP() < 3.PetHP()) BattlePet.Skills.ChangePet(3);
                return;
            }
            if (GoldenPet.CanCast(1))
            {
                GoldenPet.Cast(1);
                return;
            }
            Logging.Write("Обычная логика");

        }
        
         public static void Npc55386()
        {
            //Морской пони
           //  Logging.Write(BattlePet.Game.GetNumPetsInBattle(BattlePet.Skills.PetOwner.Enemy).ToString());
             if (BattlePet.Skills.GetHealth(BattlePet.Skills.PetOwner.Enemy, 2) == 0 && BattlePet.Skills.GetHealth(BattlePet.Skills.PetOwner.Enemy, 3) == 0)
             {
                 Logging.Write("Враг 1");
                 if(GoldenPet.CanCast(3))
                 {
                     GoldenPet.Cast(3);
                     return;
                 }
                 if (!CommandHasBuff(316, BattlePet.Skills.PetOwner.Enemy) && GoldenPet.CanCast(2))
                 {
                     Logging.Write("Cast 2");
                     GoldenPet.Cast(2);
                     return;
                 }
                 if (!BattlePet.Game.IsSkipAvailable() || BattlePet.Game.IsWaitingOpponent) return;
                 Logging.Write("SkipMove");
                 BattlePet.Skills.SkipMove();
                 return;
             }
            if (GoldenPet.CanCast(1))
            {
                GoldenPet.Cast(1);
                return;
            }
            Logging.Write("Обычная логика");

        }
        
        #endregion Logics
    }
}