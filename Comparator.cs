using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TDD
{
    public class Comparator
    {
        /// <summary>
        /// Поиск ссылки на породу с максимальным количеством предложений.
        /// </summary>
        /// <param name="breed">Список элементов с названием породы</param>
        /// <param name="count">Список элементов с количеством предложений</param>
        /// <returns>Возвращает индекс элемента с максимальным количеством предложений</returns>        
        public int FindMaxFromCatalog(List<IWebElement> breed, List<IWebElement> count)
        {

            int max = 0;
            int maxIndex = 0;

            for (int i = 0; i < count.Count; i++)
            {
                int compare = Int32.Parse(count[i].Text);
                if ((compare > max) && (breed[i].Text != "Другая"))
                {
                    max = compare;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
