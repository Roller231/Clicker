
using System;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public Int64 money = 0;
        public int upgradeClickCost = 10;
        public int upgradeAutoClickCost = 30;

        public int countPlusMoney = 1;
        public int autoClick = 0;

        public bool[] girlBuyScripts = new bool[11];
        public bool[] foneBuyScripts = new bool[8];


        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            for (int i = 0; i < girlBuyScripts.Length; i++)
            {
                girlBuyScripts[i] = true;
            }
            for (int j = 0; j < foneBuyScripts.Length; j++)
            {
                foneBuyScripts[j] = true;
            }

            girlBuyScripts[0] = false;
            foneBuyScripts[0] = false;

        }
    }
}
