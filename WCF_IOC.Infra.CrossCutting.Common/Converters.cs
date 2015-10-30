//===================================================================================
// © GABRIELGI - linkedin.com/in/gabrielgonzaleziglesias
//===================================================================================

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WCF_IOC.Infra.CrossCutting.Common
{
    public class Converters
    {
        #region Public Methods

        public static List<T> ConvertStringToEnum<T>(string stringArray)
        {
            var permissions= stringArray.Split('|').Select(permission => Convert.ToInt32(permission));
            return (List<T>)permissions.Select(r => (T)Enum.Parse(typeof(T), r.ToString(CultureInfo.InvariantCulture)));
        }

        #endregion


        protected T ConvertXmlToClassTypeFromXml<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, simply return defaultXmlClass
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("WebClient has been disposed Erro:" + ex.Message);
            }

            return returnedXmlClass;
        }

    }


}
