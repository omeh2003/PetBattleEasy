namespace PetBattleEasy.Settings
{
    internal class Globals
    {
        internal static readonly GUI.GUI Form = new GUI.GUI();

        internal static void CustomClass_OnLoad()
        {
            SettingsIO.Load();
        }

        
        internal static void CustomClass_Settings()
        {
            Form.Show();
        }
    }
}