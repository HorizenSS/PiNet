using Data;
using GUI.ocr;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using PiDev.Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.ocr
{
    class Application
    {
        Utils util = new Utils();
        TicketOCRService tickerService = new TicketOCRService();

        static void Main(string[] args)
        {
            Application obj = new Application();
            obj.ConvertImageToText();
        }
        public void ConvertImageToText()
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.English);

                string plainText = api.GetTextFromImage("C:\\Users\\Sweet\\Videos\\veggie-grocery-receipt_orig.jpeg");

                string[] parsed = plainText
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(plainText);
                Console.Read();
                TicketOcr ticketsMazraa = new TicketOcr();

                int i;

                for (i = 0; i < parsed.Length; i++)
                {
                    string date = util.getDate(parsed[i]);
                    if (date != "")
                    {
                        ticketsMazraa.Date = date;
                        break;
                    }
                }

                i++ ;
                int index = 0;
                string articleDetails = "Articles: \r\n ";
                for (int j=i+1; i < parsed.Length;j++)
                {
                    
                   
                    string quantite = util.getQuantity(parsed[j]);
                    if (quantite != "")
                    {
                        
                        String nomArticle = util.getLibelle(parsed[j]);
                        String prixUnitaire = util.getPrixUnitaire(parsed[j]);
                        String montant = util.getMontant(parsed[j]);
                        if ((nomArticle != "") && (prixUnitaire != "") && (montant != ""))
                        {
                            index++;
                            articleDetails = articleDetails + index + ". " + quantite + "x " + nomArticle + ". PU: " + prixUnitaire + ". Montant payé: " + montant + " TND. \r\n ";
                        }
                    }

                    var ttl = util.getTotal(parsed[j]);
                    if (ttl!="")
                    {
                        ticketsMazraa.Totale = ttl;
                        break;
                    }

                }

                ticketsMazraa.ArticlesDetails = articleDetails;

                Console.WriteLine(articleDetails);

                tickerService.Add(ticketsMazraa);
                tickerService.Commit();


                string libelle = util.getLibelle(parsed[5]);




            }
        }
    }
}
