using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace AP2ex1.Model
{
    /// <summary>
    /// this class knows how to handle reading XML files, defining properties,
    /// and get their values from csv file.
    /// </summary>
    public class FilesParser
    {
        private const string SECTION = "descendant::input";     // the default is to look for properties in the input part.
        private const string PROP_NAME_LABEL = "chunk/name";    // the properties names are at chunk.name.
        private IDictionary<string, int> propToIndex;           // this maps between properties, and their indices in the csv data file.
        private IList<string> propList;                         // list of all properties.
        private IList<double[]> propValues;                     // this list contains the values of all properties.
        
        /// <summary>
        /// constructor for the class.
        /// </summary>
        public FilesParser()
        {
            propToIndex = new Dictionary<string, int>();
            propList = new List<string>();
            propValues = new List<double[]>();
        }

        /// <summary>
        /// this loads a new settings file.
        /// it updates the mapping between properties and indices according to their order in the XML file.
        /// </summary>
        /// <param name="xmlPath"> the new settings file </param>
        public void LoadSettings(string xmlPath)
        {
            propToIndex.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;
            XmlNode input = root.SelectSingleNode(SECTION);
            int index = 0;
            foreach (XmlNode chunkName in input.SelectNodes(PROP_NAME_LABEL))
            {
                string prop = chunkName.InnerText;
                // if there's already Field named prop, we add '2' to the name.
                if (propToIndex.ContainsKey(prop))
                {
                    prop += "2";
                }
                propToIndex[prop] = index;
                propList.Add(prop);
                index++;
            }

        }
        
        /// <summary>
        /// this loads a new data file (csv file).
        /// it updates the data stored in the object.
        /// </summary>
        /// <param name="csvPath"> the new data file. </param>
        public void LoadData(string csvPath)
        {
            propValues.Clear();
            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(",");
                    var doubleValues = new double[values.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        doubleValues[i] = Double.Parse(values[i]);
                    }
                    propValues.Add(doubleValues);
                }
            }
        }


        /// <summary>
        /// get a specific data line.
        /// </summary>
        /// <param name="lineNum"> the line wanted. </param>
        /// <returns> the data at that line. </returns>
        public double[] GetLine(int lineNum)
        {
            return propValues[lineNum];
        }

        /// <summary>
        /// get specific property at specific line.
        /// </summary>
        /// <param name="propName"> the wanted property. </param>
        /// <param name="lineNum"> the wanted line number. </param>
        /// <returns> the property value at that line. </returns>
        public double GetPropertyAtLine(string propName, int lineNum)
        {
            int index = propToIndex[propName];
            return propValues[lineNum][index];
        }

        /// <summary>
        /// get property array of values.
        /// </summary>
        /// <param name="propName"> the property, to get the values of. </param>
        /// <returns> an array of the property values, from all the lines in the csv file. </returns>
        public double[] GetProperty(string propName)
        {
            int index = propToIndex[propName];
            double[] res = new double[propValues.Count];
            for (int i = 0; i < propValues.Count; i++)
            {
                res[i] = propValues[i][index];
            }
            return res;
        }

        /// <summary>
        /// get a list of all the properties, defined at the settings file (the XML).
        /// </summary>
        /// <returns> list of all properties, defined at the XML. </returns>
        public IList<string> GetPropertiesNames()
        {
            return propList;
        }

    }
}
