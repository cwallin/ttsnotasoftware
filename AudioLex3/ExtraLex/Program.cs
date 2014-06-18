using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ExtraLex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mGeneral.APP_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

#if DEBUG
            //Husk at skifte hvis der kørtes på en anden PC
            mGeneral.APP_PATH = @"C:\a_cwa lokal\Aktuelle projekter\Talesyntese\Nota software\AudioLex3\runtime";
#endif
            mGeneral.TMP_PATH = mGeneral.APP_PATH + "\\LexTmp";

            mGeneral.FILIBUSTER = Properties.Settings.Default.FILIBUSTER;
            mGeneral.EXTRALEX_LOCATION = Properties.Settings.Default.EXTRALEX_LOCATION;

            //Fra lexiconChanger
            mGeneral.MAIN_LEX_PATH = Properties.Settings.Default.Dictionary_MainPath;
            mGeneral.NAME_LEX_PATH = Properties.Settings.Default.Dictionary_NamePath;
            mGeneral.ENGLISH_LEX_PATH = Properties.Settings.Default.Dictionary_EnglishPath;
            mGeneral.EXTRA_LEX_PATH = Properties.Settings.Default.Dictionary_ExtraPath;
            mGeneral.ACRONYMS_LEX_PATH = Properties.Settings.Default.Dictionary_Acronyms_Path;
            mGeneral.APROVED_LIST_PATH = Properties.Settings.Default.AprovedListPath;

            mGeneral.MAIN_LEX = Properties.Settings.Default.Dictionary_Main;
            mGeneral.NAME_LEX = Properties.Settings.Default.Dictionary_Name;
            mGeneral.ENGLISH_LEX = Properties.Settings.Default.Dictionary_English;
            mGeneral.EXTRA_LEX = Properties.Settings.Default.Dictionary_Extra;
            mGeneral.ACRONYMS_LEX = Properties.Settings.Default.Dictionary_Acronyms;
            mGeneral.APROVED_LIST = Properties.Settings.Default.AprovedList;

            mGeneral.CHECK_LIST = Properties.Settings.Default.CheckList;
            mGeneral.COMPLETE_LIST = Properties.Settings.Default.CompleteList;
            mGeneral.CACHED_AUDIO_PATH = Properties.Settings.Default.CachedAudio;

            mGeneral.TEXT_FILTER = Properties.Settings.Default.TextFilter;

            mGeneral.WISH_APP = Properties.Settings.Default.WishApp;

            mGeneral.MULTIWORD_LEX = Properties.Settings.Default.DictionaryMultiWord;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmExtraLex());
        }
    }
}
