using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }

        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            PicturesToDisplay.Clear();

            var now = DateTime.Now;
            int todayNumber = (int)now.DayOfWeek; // 0=Zondag, 1=Maandag, ..., 6=Zaterdag

            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                string folderName = new DirectoryInfo(dir).Name; // bv. "2_Dinsdag"
                string[] parts = folderName.Split('_');

                if (parts.Length > 0 && int.TryParse(parts[0], out int folderDayNumber))
                {
                    if (folderDayNumber == todayNumber)
                    {
                        foreach (string file in Directory.GetFiles(dir))
                        {
                            PicturesToDisplay.Add(new KioskPhoto()
                            {
                                Id = PicturesToDisplay.Count,
                                Source = file
                            });
                        }
                    }
                }
            }

            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // Zelfde logica als Start(), want bij refresh willen we opnieuw alle foto's van vandaag laden
            Start();
        }
    }
}
