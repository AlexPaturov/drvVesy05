using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

/*
    Привожу полученные от контроллера данные к требуемому по спецификации формату, для ответа АРМ(у) весов.
 */

namespace drvVesy05
{
    public static class XMLFormatter
    {

        // Получить результат статического взвешивания.
        public static byte[] getStatic(byte[] bInput) 
        {
            if (bInput != null) 
            { 
                Dictionary<string, string> preparedAnswer = RawToXML(System.Text.Encoding.Default.GetString(bInput) );

                XmlDocument xmlDoc = new XmlDocument();                                                     
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            
                XmlElement rootResponse = xmlDoc.CreateElement("Response");                                 
                xmlDoc.AppendChild(rootResponse);                                                           

                    XmlElement ch1_State = xmlDoc.CreateElement("State");                                   
                    ch1_State.InnerText = "Success";
                    rootResponse.AppendChild(ch1_State);

                    XmlElement ch1_CheckSumZero = xmlDoc.CreateElement("CheckSumZero");                     
                    ch1_CheckSumZero.InnerText = "0";
                    rootResponse.AppendChild(ch1_CheckSumZero);

                    XmlElement ch1_CheckSumWeight = xmlDoc.CreateElement("CheckSumWeight");
                    ch1_CheckSumWeight.InnerText = "0";
                    rootResponse.AppendChild(ch1_CheckSumWeight);

                        XmlElement ch2_StaticData = xmlDoc.CreateElement("StaticData");
                        rootResponse.AppendChild(ch2_StaticData);

                        XmlElement ch3_Processed = xmlDoc.CreateElement("Processed");
                        ch3_Processed.InnerText = "1";
                        ch2_StaticData.AppendChild(ch3_Processed);

                        XmlElement ch3_Npp = xmlDoc.CreateElement("Npp");
                        ch3_Npp.InnerText = "1";
                        ch2_StaticData.AppendChild(ch3_Npp);

                        XmlElement ch3_Number = xmlDoc.CreateElement("Number");
                        ch3_Number.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Number);

                        XmlElement ch3_Date = xmlDoc.CreateElement("Date");
                        ch3_Date.InnerText = preparedAnswer["Date"];
                        ch2_StaticData.AppendChild(ch3_Date);

                        XmlElement ch3_Time = xmlDoc.CreateElement("Time");
                        ch3_Time.InnerText = preparedAnswer["Time"];
                        ch2_StaticData.AppendChild(ch3_Time);

                        XmlElement ch3_Brutto = xmlDoc.CreateElement("Brutto");
                        ch3_Brutto.InnerText = preparedAnswer["Brutto"];
                        ch2_StaticData.AppendChild(ch3_Brutto);

                        XmlElement ch3_KolOs = xmlDoc.CreateElement("KolOs");
                        ch3_KolOs.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_KolOs);

                        XmlElement ch3_Speed = xmlDoc.CreateElement("Speed");
                        ch3_Speed.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Speed);

                        XmlElement ch3_Platform1 = xmlDoc.CreateElement("Platform1");
                        ch3_Platform1.InnerText = preparedAnswer["Platform1"];
                        ch2_StaticData.AppendChild(ch3_Platform1);

                        XmlElement ch3_Rail1_1 = xmlDoc.CreateElement("Rail1_1");
                        ch3_Rail1_1.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail1_1);

                        XmlElement ch3_Rail1_2 = xmlDoc.CreateElement("Rail1_2");
                        ch3_Rail1_2.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail1_2); ;

                        XmlElement ch3_Rail1_3 = xmlDoc.CreateElement("Rail1_3");
                        ch3_Rail1_3.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail1_3);

                        XmlElement ch3_Rail1_4 = xmlDoc.CreateElement("Rail1_4");
                        ch3_Rail1_4.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail1_4);

                        XmlElement ch3_Platform2 = xmlDoc.CreateElement("Platform2");
                        ch3_Platform2.InnerText = preparedAnswer["Platform2"];
                        ch2_StaticData.AppendChild(ch3_Platform2);

                        XmlElement ch3_Rail2_1 = xmlDoc.CreateElement("Rail2_1");
                        ch3_Rail2_1.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail2_1);

                        XmlElement ch3_Rail2_2 = xmlDoc.CreateElement("Rail2_2");
                        ch3_Rail2_2.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail2_2); ;

                        XmlElement ch3_Rail2_3 = xmlDoc.CreateElement("Rail2_3");
                        ch3_Rail2_3.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail2_3);

                        XmlElement ch3_Rail2_4 = xmlDoc.CreateElement("Rail2_4");
                        ch3_Rail2_4.InnerText = "0";
                        ch2_StaticData.AppendChild(ch3_Rail2_4);

                        XmlElement ch3_ShiftPop = xmlDoc.CreateElement("ShiftPop");
                        ch3_ShiftPop.InnerText = preparedAnswer["ShiftPop"];
                        ch2_StaticData.AppendChild(ch3_ShiftPop);

                        XmlElement ch3_ShiftPro = xmlDoc.CreateElement("ShiftPro");
                        ch3_ShiftPro.InnerText = preparedAnswer["ShiftPro"];
                        ch2_StaticData.AppendChild(ch3_ShiftPro);

                        XmlElement ch3_pravBort1_2 = xmlDoc.CreateElement("PravBort1_2");
                        ch3_pravBort1_2.InnerText = preparedAnswer["PravBort1_2"];
                        ch2_StaticData.AppendChild(ch3_pravBort1_2);

                        XmlElement ch3_levBort3_4 = xmlDoc.CreateElement("LevBort3_4");
                        ch3_levBort3_4.InnerText = preparedAnswer["LevBort3_4"];
                        ch2_StaticData.AppendChild(ch3_levBort3_4);

                        XmlElement ch3_Delta = xmlDoc.CreateElement("Delta");
                        ch3_Delta.InnerText = preparedAnswer["Delta"];
                        ch2_StaticData.AppendChild(ch3_Delta);

                        XmlElement ch3_Type = xmlDoc.CreateElement("Type");
                        ch3_Type.InnerText = "V";
                        ch2_StaticData.AppendChild(ch3_Type);

                return Encoding.GetEncoding(1251).GetBytes(xmlDoc.OuterXml);
            }
            else 
            {
                throw new Exception("Answer from device is incorrect. getStatic input == null");
            }
        }

        // Получаю стандартный Exception и код по спецификации, возвращаю ошибку в установленном спецификацией формате XML.
        public static byte[] GetError(Exception ex, int code) 
        {
            XmlDocument xmlDoc = new XmlDocument();                                                         
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlElement rootResponse = xmlDoc.CreateElement("Response");                                     
            xmlDoc.AppendChild(rootResponse);

            XmlElement ch1_State = xmlDoc.CreateElement("State");                                           
            ch1_State.InnerText = "Error";
            rootResponse.AppendChild(ch1_State);

                XmlElement ch2_ErrorDescription = xmlDoc.CreateElement("ErrorDescription");                 
                rootResponse.AppendChild(ch2_ErrorDescription);

                XmlElement ch3_ErrorCode = xmlDoc.CreateElement("ErrorCode");                               
                ch3_ErrorCode.InnerText = code.ToString();
                ch2_ErrorDescription.AppendChild(ch3_ErrorCode);

                XmlElement ch3_ErrorText = xmlDoc.CreateElement("ErrorText");
                ch3_ErrorText.InnerText = ex.Message;
                ch2_ErrorDescription.AppendChild(ch3_ErrorText);

            return Encoding.GetEncoding(1251).GetBytes(xmlDoc.OuterXml);
        }

        private static Dictionary<string, string> RawToXML(string input)
        {
            Dictionary<string, string> XMLtmp = new Dictionary<string, string>();

            if (input.Contains("F#1"))                                                                                                  // 1
            {
                input = input.Substring(input.IndexOf("F#1") + 3, (input.Length - (input.IndexOf("F#1") + 3))).Trim();
            }
            else
            {
                throw new Exception($"Format of answer from device is incorrect. {input}");
            }

            string checkedInput = FixBSafterDate(input);
            if (checkedInput == "0")
            {
                throw new ArgumentException($"Controller data is corrupted: {input}");
            }

            // Извлекаем дату
            int firstSpace = checkedInput.IndexOf(" ");
            if (firstSpace == -1) throw new Exception($"Invalid format: Missing date. {checkedInput}");

            string datePart = checkedInput.Substring(0, firstSpace);
            checkedInput = checkedInput.Substring(firstSpace + 1);

            if (!DateTime.TryParseExact(datePart, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new Exception($"Invalid date format. {checkedInput}");
            }

            XMLtmp.Add("Date", parsedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

            // Извлекаем время
            int secondSpace = checkedInput.IndexOf(" ");
            if (secondSpace == -1) throw new Exception($"Invalid format: Missing time. {checkedInput}");

            string timePart = checkedInput.Substring(0, secondSpace);
            checkedInput = checkedInput.Substring(secondSpace + 1);

            XMLtmp.Add("Time", timePart);
            XMLtmp.Add("Brutto", TonnsToKilos(ExtractWeight(checkedInput)));                                    // Извлекаем вес
            XMLtmp.Add("Platform1", "0");
            XMLtmp.Add("Platform2", "0");
            XMLtmp.Add("PravBort1_2", "0");
            XMLtmp.Add("LevBort3_4", "0");
            XMLtmp.Add("ShiftPop", "0");
            XMLtmp.Add("ShiftPro", "0");
            XMLtmp.Add("Delta", "0");
            return XMLtmp;
        }

        // Перевожу тонны в киллограммы, возвращаю в строковом представлении.
        private static string TonnsToKilos(string inputTonns) 
        {
            if (!string.IsNullOrEmpty(inputTonns)) 
            {
                double outputKilos = 0;
                if (double.TryParse(inputTonns, out outputKilos))
                {
                    return (outputKilos * 1000).ToString();
                }
                throw new Exception("Calculation mass is incorrect. | " + inputTonns +" |");
            }
            else
            {
                throw new Exception("Mass value is incorrect.");
            }
            
        }

        // Для получения значения веса из строки от контроллера 5-х весов
        static string ExtractWeight(string input)
        {
            string inpFixed = FixBSafterDate(input);
            Regex numberRegex = new Regex(@"\b\d{1,2}\.\d{3}\b|\b0\.\d{3}\b"); // Регулярное выражение для поиска валидных чисел после даты и времени
            MatchCollection matches = numberRegex.Matches(inpFixed);

            foreach (Match match in matches)
            {
                if (decimal.TryParse(match.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal value) && value >= 0.000m && value <= 59.999m)
                {
                    return match.Value;
                }
            }

            return "0";
        }

        #region FixBSafterDate() Контроллер иногда теряет пробел после даты и времени - добавляем пробел
        static string FixBSafterDate(string input)
        {
            if (input.Length < 18) return "0";
            if (input[16] != ' ') return input.Insert(16, " ");
            return input;
        }
        #endregion
    }
}
