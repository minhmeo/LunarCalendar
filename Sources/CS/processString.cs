using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DDay.iCal.Serialization.iCalendar;


namespace LunarEventCalendar
{
    class processString
    {
        public String getStandardFormat(String orgStr)
        {
            String formatter = orgStr.ToLower(), template = "";
            int i;

            formatter = formatter.Replace(formatter.Substring(0, 1), formatter.Substring(0, 1).ToUpper());

            if (formatter.IndexOf(" ") != -1)
            {
                template += formatter.Substring(0, formatter.IndexOf(" ")).Trim();
                i = formatter.IndexOf(" ");
                while (i < formatter.Length)
                {
                    if (formatter[i] == ' ')
                    {
                        template += " ";
                        template += formatter.Substring(i, i).ToUpper();
                        i = i + 2;
                    }
                    else
                    {
                        template = formatter.Substring(i, i + 1);
                        i++;
                        MessageBox.Show(template);
                    }
                }
            }
            else
                template = formatter;
            return template;
        }

        private string capitaliseSentence(string sentence)
        {
            string result = "";
            while (sentence[0] == ' ')
            {
                sentence = sentence.Remove(0, 1);
                result += " ";
            }
            if (sentence.Length > 0)
            {
                result += sentence.TrimStart().Substring(0, 1).ToUpper();
                result += sentence.TrimStart().Substring(1, sentence.TrimStart().Length - 1);
            }
            return result;
        }

        public string ToSentenceCase(string text)
        {
            string temporary = text.ToLower();
            string result = "";
            while (temporary.Length > 0)
            {
                string[] splitTemporary = splitAtFirstSentence(temporary);
                temporary = splitTemporary[1];
                MessageBox.Show(temporary);
                if (splitTemporary[0].Length > 0)
                {
                    result += capitaliseSentence(splitTemporary[0]);
                }
                else
                {
                    result += capitaliseSentence(splitTemporary[1]);
                    temporary = "";
                }
            }
            return result;
        }

        private string[] splitAtFirstSentence(string text)
        {
            int lastChar = text.IndexOfAny(new char[] { '.', ':', '\n', '\r', '!', '?' }) + 1;
            if (lastChar == 1)
            {
                lastChar = 0;
            }
            return new string[] { text.Substring(0, lastChar), text.Substring(lastChar, text.Length - lastChar) };
        }

        public string ToTitleCase(string mText)
        {
            string rText = "";
            try
            {
                System.Globalization.CultureInfo cultureInfo =
                System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
                rText = TextInfo.ToTitleCase(mText);
            }
            catch
            {
                rText = mText;
            }
            return rText;
        }

        public string getStandardSpace(String orgStr)
        {
            string template = orgStr;

            while (template.IndexOf("  ") != -1)
            {
                template = template.Replace("  ", " ");
            }
            return template;
        }

        public string loaiboDauTiengViet(string accented)
        {
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}

