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
        public static Home Window { get; set; }
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        public void Start()
        {
            PicturesToDisplay.Clear();

            var now = DateTime.Now;
            int todayNumber = (int)now.DayOfWeek;

            DateTime bovenGrens = now.AddMinutes(-2);
            DateTime onderGrens = now.AddMinutes(-30);

            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                string folderName = new DirectoryInfo(dir).Name;
                string[] parts = folderName.Split('_');

                if (parts.Length > 0 && int.TryParse(parts[0], out int folderDayNumber) && folderDayNumber == todayNumber)
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file); // bv. "13_37_10_id1"
                        string[] nameParts = fileName.Split(new[] { "_id" }, StringSplitOptions.None);

                        if (nameParts.Length == 2)
                        {
                            string tijdString = nameParts[0].Replace("_", ":"); // "13:37:10"
                            if (TimeSpan.TryParse(tijdString, out TimeSpan tijd))
                            {
                                DateTime fotoTijd = now.Date + tijd;

                                if (fotoTijd >= onderGrens && fotoTijd <= bovenGrens)
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
                }
            }

            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        public void RefreshButtonClick()
        {
            Start();
        }
    }
}