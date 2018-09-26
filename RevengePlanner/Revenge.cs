using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RevengePlanner
{
    /// <summary>
    /// Класс, хранящий запись о некотором событии.
    /// </summary>
    public class Revenge
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Конструктор по-умолчанию.
        /// </summary>
        public Revenge()
        {
            DateTime = DateTime.Today;
        }

        /// <summary>
        /// Конструктор класса Revenge.
        /// </summary>
        /// <param name="dt">Время события.</param>
        /// <param name="nm">Имя жертвы.</param>
        /// <param name="txt">Описание наказания.</param>
        public Revenge(DateTime dt, string nm, string txt)
        {
            DateTime = dt;
            Name = nm;
            Text = txt;
        }
    }

    public class RevengeList
    {
        public List<Revenge> List { get; set; }
        public Guid Guid { get; set; }

        public RevengeList()
        {
            Guid = Guid.NewGuid();
            List = new List<Revenge>();
        }

        public void Save(string filename)
        {
            using (Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Revenge>));
                xml.Serialize(fs, List);
            }
        }

        public void Load(string filename)
        {
            using (Stream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Revenge>));
                List = (List<Revenge>)xml.Deserialize(fs);
            }
        }
    }
}