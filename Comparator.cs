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
        public int FindMaxFromCatalogOld(List<IWebElement> breed, List<IWebElement> count)
        {

            int max = 0;
            int maxIndex = 0;

            for (int i = 0; i < count.Count; i++)
            {
                int compare = Int32.Parse(count[i].Text.Replace(" ", ""));
                if ((compare > max) && (breed[i].Text != "Другая"))
                {
                    max = compare;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        /// <summary>
        /// Игнорирование категории "Другая".
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindMaxFromCatalog(List<IWebElement> breed, List<IWebElement> count)
        {
            
            count = DeleteSpace(count);
            int maxIndex = FindMax(count);

            if (breed[maxIndex].Text == "Другая")
            {
                breed.RemoveAt(maxIndex);
                count.RemoveAt(maxIndex);
                return FindMax(count);
            }

            return maxIndex;
        }
        
        /// <summary>
        /// Поиск индекса элемента с максимальным значением предложений породы.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindMax(List<IWebElement> count)
        {
            int max = count.Max(c => Int32.Parse(c.Text));
            var element = count.FirstOrDefault(c => c.Text == max.ToString());
            int maxIndex = count.IndexOf(element);

            return maxIndex;
        }

        /// <summary>
        /// Удаление пробелов в значении количества предложений породы.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<IWebElement> DeleteSpace(List<IWebElement> count)
        {
            foreach(IWebElement c in count)
            {
                c.Text.Replace(" ", "");
            }

            return count;
        }
    }
}
