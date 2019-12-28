using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUI.ocr
{
    class Utils
    {
        public string getDate(String text)
        {
            Regex reg = new Regex(@"\d{1,2}/\d{1,2}/\d{4,20}", RegexOptions.IgnorePatternWhitespace);
            var x = reg.Match(text);
            return x.Value;
        }

        public string getQuantity(String text)
        {
            Regex reg = new Regex(@"^\d{0,4}.{0,1}\d{1,4}", RegexOptions.IgnorePatternWhitespace);
            var x = reg.Match(text);
            return x.Value;
        }


        public string getLibelle(String text)
        {
            //te5ou chaine kemla 
            Utils util = new Utils();
            text = text.Remove(text.IndexOf(this.getQuantity(text)[0]), this.getQuantity(text).Length).Trim();
            text = text.Remove(text.IndexOf(this.getPrixUnitaire(text)), text.Length- text.IndexOf(this.getPrixUnitaire(text))).Trim();
            return text;
        }


        public string getPrixUnitaire(String text)
        {
            //te5ou el chaine fiha el qte mfas5a
            Regex reg = new Regex(@"\d{1,4},\d{1,4}", RegexOptions.IgnorePatternWhitespace);
            var x = reg.Match(text);
            return x.Value;
        }


        public string getMontant(String text)
        {
            //te5ou chaine ma fiha ken el labelle wel montant
            Regex reg = new Regex(@"\d{1,4}.\d{1,4}$", RegexOptions.IgnorePatternWhitespace);
            var x = reg.Match(text);
            return x.Value;
        }

        public string getTotal(String text)
        {
            if (text.StartsWith("TOTAL TICKET"))
            {
                Regex reg = new Regex(@"\d{1,4},\d{1,4}$", RegexOptions.IgnorePatternWhitespace);
                var x = reg.Match(text);
                return x.Value;
            }
            return "";
        }



    }
}
