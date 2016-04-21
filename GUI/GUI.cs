using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EvilManagerWoD;
using EvilManagerWoD.Helpers.Game;
using EvilManagerWoD.Patchables;
using PetBattleEasy.Helpers;
using PetBattleEasy.Settings;

namespace PetBattleEasy.GUI
{
    internal partial class GUI : Form
    {
        private bool _regon;
        private bool _solo;

        public GUI()
        {
            Globals.CustomClass_OnLoad();
            InitializeComponent();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.LeaveGame = LeaveGame.Checked;
            Logging.Write("LeaveGame {0}", LeaveGame.Checked);
            SettingsIO.Save();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            var targetname = NameReg.Text;
            if (!String.IsNullOrEmpty(targetname) && !String.IsNullOrWhiteSpace(targetname))
            {
                if (_regon)
                {
                    Logging.Write("Виспую {0}", targetname);
                    Chat.WhisperPlayer(@"++", targetname);
                    _regon = false;
                }
                else if (!_regon)
                {
                    Logging.Write("Виспую {0}", targetname);
                    Chat.WhisperPlayer(@"+++", targetname);
                    _regon = true;
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            SettingsIO.Save();
            Visible = false;
        }

        private void On_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.On = On.Checked;
            Logging.Write("On_CheckedChanged {0}", On.Checked);

            SettingsIO.Save();
        }

        private void Only1_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Only1 = Only1.Checked;
            Logging.Write("Only1_CheckedChanged {0}", Only1.Checked);
            SettingsIO.Save();
        }

        private void Nonstop_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Nonstop = Nonstop.Checked;
            Logging.Write("Nonstop_CheckedChanged {0}", Nonstop.Checked);
            SettingsIO.Save();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            On.Checked = PetBattleEasy.On;
            Only1.Checked = PetBattleEasy.Only1;
            Nonstop.Checked = PetBattleEasy.Nonstop;
            LeaveGame.Checked = PetBattleEasy.LeaveGame;
            Slot1Swap.Checked = PetBattleEasy.Slot1Swap;
            Slot2Swap.Checked = PetBattleEasy.Slot2Swap;
            Slot3Swap.Checked = PetBattleEasy.Slot3Swap;
            Slot1SwapLevel.Value = PetBattleEasy.Slot1SwapLevel;
            Slot2SwapLevel.Value = PetBattleEasy.Slot2SwapLevel;
            Slot3SwapLevel.Value = PetBattleEasy.Slot3SwapLevel;
            Solo.Checked = PetBattleEasy.Solo;
            EnemyLevel.Value = PetBattleEasy.EnemyLevel;
            _solo = true;
            _regon = true;
            NameReg.Text = PetBattleEasy.NameReg;
            comboBox1.Items.Clear();
            foreach (var variable in Enum.GetNames(typeof(Enums.WoWCombatPetType)))
            {
                comboBox1.Items.Add(variable);
            }
            HpFactor.Value = PetBattleEasy.HpFactor;
            AdFactor.Value = PetBattleEasy.AdFactor;
            DisFactor.Value = PetBattleEasy.DisFactor;
            ImpruvedLogic.Checked = PetBattleEasy.ImpruvedLogic;
            richTextBox1.Text = @"Бот может самостоятельно следить и поддерживать определенный уровень петов в каждом слоте.
 Для этого выберите желаемый уровень и поставьте галочку рядом с номерами нужных слотов.
Если петов нужного уровня не будет у вас в коллекции то Бот просто ничего не поменяет. Проверка уровня проводится в трех случаях
1)после боя
2)при загрузке и
3)нажатии кнопки ""upda"" в этой вкладке настроек.";
            richTextBox2.Text = @"Дисклеймер. Данная концепция была опубликована на форуме Bossland GmbH Company. Что автоматически определяет ее лицензией BSD licenses.И в данном продукте она используется полностью соответствуя оной.
 Суть в двух словах: Для каждого пета мы можем посчитать некий рейтинг и сравнить этот рейтинг с рейтингом другого пета. Так как при расчете мы используем одну и туже формулу и показатели, то можно предположить что пет чей рейтинг выше является лучшим.
Мы используем следующие коэффициенты:
Уровень угрозы нашего пета вражескому,
Уровень защиты нашего пета от врага,
Уровень жизни (имеется ввиду размер ХП).
advantage - преимущество.
disadvantage-угроза.
Hp -жизнь.
Первые два считаются в зависимости от класса-антикласса петов и их состоянию относительно друг друга.  HP в соответствии с максимальным размером ХП. Сама формула:   rating = (petHP * HpFactor)  + (advantage * 50 * advantageFactor) +  (disadvantage *50 * disadvantage)
На этой вкладке можно выставить значения коэффициентов используемых при расчете в аддоне. Суть коэффициента = важности этого параметра. Чем выше число тем важнее и весомее этот параметр в расчете рейтинга.";
        }

        private void update_Click(object sender, EventArgs e)
        {
            GoldenPet.UpdateSlot();
        }

        private void SoloReg_Click(object sender, EventArgs e)
        {
            if (_solo)
            {
                BattlePet.Game.StartPVPMatchmaking();
                _solo = false;
            }
            else if (!_solo)
            {
                BattlePet.Game.DeclineQueuedPVPMatch();
                BattlePet.Game.StopPVPMatchmaking();
                _solo = true;
            }
        }

        private void Solo_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Solo = Solo.Checked;
            Logging.Write("Solo.Checked; {0}", Solo.Checked);
            SettingsIO.Save();
        }

        private void Slot1Swap_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot1Swap = Slot1Swap.Checked;
            Logging.Write("Slot1Swap.Checked; {0}", Slot1Swap.Checked);
            SettingsIO.Save();
        }

        private void Slot1SwapLevel_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot1SwapLevel = (int)Slot1SwapLevel.Value;
            Logging.Write("Slot1SwapLevel; {0}", Slot1SwapLevel.Value);
            SettingsIO.Save();
        }

        private void NameReg_Change(object sender, EventArgs e)
        {
            PetBattleEasy.NameReg = NameReg.Text;
            Logging.Write("NameReg; {0}", NameReg.Text);
            SettingsIO.Save();
        }

        private void Slot2SwapLevel_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot2SwapLevel = (int)Slot2SwapLevel.Value;
        }

        private void Slot3SwapLevel_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot3SwapLevel = (int)Slot3SwapLevel.Value;
        }

        private void Slot2Swap_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot2Swap = Slot2Swap.Checked;
            Logging.Write("Slot2Swap.Checked; {0}", Slot2Swap.Checked);
            SettingsIO.Save();
        }

        private void Slot3Swap_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.Slot3Swap = Slot3Swap.Checked;
            Logging.Write("Slo3Swap.Checked; {0}", Slot3Swap.Checked);
            SettingsIO.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            var type = comboBox1.SelectedIndex;
            var level = EnemyLevel.Value;
            GetRatingExp(type, (int) level);
        UpdateDataGrid(type);
            UpdateForm();

            // GoldenPet.UpdateFormTask().Wait();
        }

/*
        private static  void GetValueGoldenPet(int type, decimal level)
        {
            var a = RaitingTask(type, (int)level).ContinueWith(delegate { return Task.Factory.StartNew(() => UpdateDataGrid(type)).ContinueWith(delegate { return Task.Factory.StartNew(UpdateForm); }); });
             a.Wait();
          
        }
*/

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.EnemyLevel = (int)EnemyLevel.Value;
        }

        private void HpFactor_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.HpFactor = (int)HpFactor.Value;
        }

        private void DisFactor_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.DisFactor = (int)DisFactor.Value;
        }

        private void AdFactor_ValueChanged(object sender, EventArgs e)
        {
            PetBattleEasy.AdFactor = (int)AdFactor.Value;
        }

        private static void UpdateDataGrid(int enemyType)
        {
            Globals.Form.dataGridView1.Rows.Clear();

            //Globals.Form.progressBar1.Step = 100/11;

            //   Globals.Form.progressBar1.Value = 0;
            var i = 0;
            foreach (var valuePair in GoldenPet.Ratings)
            {
                if (i == 10) break;

                var petguid = valuePair.Key;
                //Logging.WriteDebug("petguid", petguid);
                var raiting = valuePair.Value;
                //Logging.WriteDebug("raiting", raiting);
                var enemytype = enemyType;
                var petinfo = BattlePet.PetJournal.GetPetInfoByPetID(petguid);
                Globals.Form.dataGridView1.Rows.Add(petinfo.Name, petinfo.EntryId, petinfo.Stats.Speed,
                    petinfo.Stats.Power, petinfo.Stats.MaxHealth, petinfo.Type.ToString(), raiting,
                    (Enums.WoWCombatPetType)enemytype);
                i++;
            }
        }

        private static void UpdateForm()
        {
            var type = Globals.Form.comboBox1.SelectedIndex;
            var level = (int)Globals.Form.EnemyLevel.Value;

            var slot1 = GoldenPet.BattleRating(1.GetPetlevel(), 1.PetHP(), BattlePet.Skills.GetPetType(BattlePet.Skills.PetOwner.Me, 1), type, level);
            var slot2 = GoldenPet.BattleRating(2.GetPetlevel(), 2.PetHP(), BattlePet.Skills.GetPetType(BattlePet.Skills.PetOwner.Me, 2), type, level);
            var slot3 = GoldenPet.BattleRating(3.GetPetlevel(), 3.PetHP(), BattlePet.Skills.GetPetType(BattlePet.Skills.PetOwner.Me, 3), type, level);

            Globals.Form.pictureBox2.WaitOnLoad = false;
            Globals.Form.pictureBox2.LoadAsync(ImgUrl(GoldenPet.Info(1).IconPath));
            Globals.Form.pictureBox3.WaitOnLoad = false;
            Globals.Form.pictureBox3.LoadAsync(ImgUrl(GoldenPet.Info(2).IconPath));
            Globals.Form.pictureBox4.WaitOnLoad = false;
            Globals.Form.pictureBox4.LoadAsync(ImgUrl(GoldenPet.Info(3).IconPath));
            Globals.Form.label11.Visible = true;
            Globals.Form.label11.Text = GoldenPet.Info(1).Name;
            Globals.Form.label10.Visible = true;
            Globals.Form.label10.Text = GoldenPet.Info(2).Name;
            Globals.Form.label9.Visible = true;
            Globals.Form.label9.Text = GoldenPet.Info(3).Name;
            Globals.Form.label6.Visible = true;
            Globals.Form.label6.Text = slot1.ToString();
            Globals.Form.label7.Visible = true;
            Globals.Form.label7.Text = slot2.ToString();
            Globals.Form.label8.Visible = true;
            Globals.Form.label8.Text = slot3.ToString();
        }

        private static string ImgUrl(string imageloc)
        {
            var theicon = imageloc.ToLower();
            const string baseurl = "http://wow.zamimg.com/images/wow/icons/large/";
            var replace1 = @"Interface\ICONS\".ToLower();

            var image = theicon.Replace(replace1, "").Replace(".blp", "");
            image = baseurl + image + ".jpg";
            //   Logging.Write("ImgURL строка 908 {0}",image.ToLower());
            return image.ToLower();
        }

        private static void GetRatingExp(int enemyType, int enemyLevel)
        {
            var list = BattlePet.PetJournal.MyPets;
            var ratings = new Dictionary<Structs.UInt128, int>();
            var petInfos = list as IList<BattlePet.PetJournal.PetInfo> ?? list.ToList();
            var count = 100 / petInfos.Count(o => o.Level == 25);
            Globals.Form.progressBar1.Step = count;

            Globals.Form.progressBar1.Value = 0;
            foreach (var info in petInfos.Where(o => o.Level == 25))
            {
                Globals.Form.progressBar1.PerformStep();
                if (!ratings.ContainsKey(info.PetID))
                    ratings.Add(info.PetID, RatingExt(info.Level, info.Stats.MaxHealth, (int)info.Type, enemyType, enemyLevel));
            }
            GoldenPet.Ratings = ratings.OrderByDescending(o => o.Value);
            var petID = GoldenPet.Ratings.FirstOrDefault(
                pet =>
                    pet.Key != BattlePet.PetJournal.GetActivePetIDBySlot(1) &&
                    pet.Key != BattlePet.PetJournal.GetActivePetIDBySlot(2) &&
                    pet.Key != BattlePet.PetJournal.GetActivePetIDBySlot(3)).Key;
            Globals.Form.pictureBox1.WaitOnLoad = false;
            Globals.Form.pictureBox1.LoadAsync(ImgUrl(petInfos.FirstOrDefault(p => p.PetID == petID).IconPath));
            Globals.Form.label1.Visible = true;
            Globals.Form.label1.Text = petInfos.FirstOrDefault(p => p.PetID == petID).Name;
            Globals.Form.label2.Visible = true;
            Globals.Form.label2.Text = GoldenPet.Ratings.FirstOrDefault().Value.ToString();

            if (Globals.Form.slotToInsert.Value == 0)
            {
                return;
            }
            BattlePet.PetJournal.SetPetToSlot((int)Globals.Form.slotToInsert.Value, petID);
        }

        private static int RatingExt(int petLevel, int petHP, int petType, int enemyType, int enemyLevel)
        {
            return GoldenPet.BattleRating(petLevel, petHP, petType, enemyType, enemyLevel);
        }

        private void CheckCell_Click(object sender, EventArgs e)
        {
            GoldenPet.CheckingPetForCell();
            
        }

        private void SetPets_Click(object sender, EventArgs e)
        {
            GoldenPet.SetPetForEncounter();
        }

        private void ImpruvedLogic_CheckedChanged(object sender, EventArgs e)
        {
            PetBattleEasy.ImpruvedLogic = ImpruvedLogic.Checked;
            SettingsIO.Save();
        }
    }
}