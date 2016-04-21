using System;
using System.Collections.Generic;

namespace PetBattleEasy.Helpers
{
    internal class Tournamet
    {
        public List<int> NeedPets = new List<int>()
        {
            62820,
            62181,
            69819,
            62854,
            62395,
            68846,
            69794,
            66950,
            23274,
            53048,
            45340,
            64899,
            55367,
            25062,
            29147,
            68660,
            68662,
            68659
        };

        public Dictionary<int,int> PetsForChange = new Dictionary<int, int>()
        {
            {69819,83642}
        };
        public List<int> Npc71929 = new List<int>() { 69819, 68846, 25062 };//Салли «Рассольный» Маклири
        public List<int> Npc71926 = new List<int>() { 62395, 64899, 68659 };//Хранитель истории Чо
        public List<int> Npc71934 = new List<int>() { 53048,62854 , 55367 };//Доктор Ян Голдблум
        public List<int> Npc71931 = new List<int>() { 29147, 45340, 25062 };//Тажань Чжу <Глава Шадо-Пан>
        public List<int> Npc73030 = new List<int>() { 68846, 55367, 68660 };//Чэнь Буйный Портер
        public List<int> Npc73138 = new List<int>() { 68659, 62854, 69819 };//Гневион
        public List<int> Npc71930 = new List<int>() { 62181, 55367, 25062 };//Темный мастер Кирин
        public List<int> Npc71933 = new List<int>() { 69794, 53048, 62820 };//Блесктрон-4000
        public List<int> Npc71932 = new List<int>() { 68659, 64899, 68660 };//Мудрый Марис 
        public List<int> Npc72009 = new List<int>() { 55367, 66950, 68662 };//Сюй-фу
        public List<int> Npc72285 = new List<int>() { 66950, 68662, 55367 };//Чи-Чи
        public List<int> Npc72290 = new List<int>() { 55367, 66950, 68662 };//Ндзао
        public List<int> Npc72291 = new List<int>() { 55367, 66950, 68662 };//Юла

        public List<int> Npc0 = new List<int>() { 66950, 68662, 55367 };
    }
}