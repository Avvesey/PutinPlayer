using System.Collections.Generic;


namespace WindowsFormsPlayer
{
   public static class Global_Data
   { 
        // список имен файлов
        public static List<string> Files = new List<string>();
         public static string GetFileName(string file)
         {
            string[] temp = file.Split('\\');
            return temp[temp.Length - 1];
         }


   }
}
