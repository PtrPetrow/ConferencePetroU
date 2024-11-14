using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConferentionOrganisationProject.Classes
{
    public static class ImageToByte
    {
        public static void ImageConverter()
        {
            foreach (var item in Model.ConferentionOrganisationDBEntities.GetContext().Users.ToList())
            {
                if (item.User_Role_Id == 1)
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\jury\\{item.User_Photo_Name}"))
                    {
                        item.User_Photo = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\jury\\{item.User_Photo_Name}");
                        continue;
                    }
                }
                else if (item.User_Role_Id == 2)
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\mod\\{item.User_Photo_Name}"))
                    {
                        item.User_Photo = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\mod\\{item.User_Photo_Name}");
                        continue;
                    }
                }
                else if (item.User_Role_Id == 3)
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\org\\{item.User_Photo_Name}"))
                    {
                        item.User_Photo = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\org\\{item.User_Photo_Name}");
                        continue;
                    }
                }
                else if (item.User_Role_Id == 4)
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\users\\{item.User_Photo_Name}"))
                    {
                        item.User_Photo = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"EventsImg\\users\\{item.User_Photo_Name}");
                        continue;
                    }
                }
            }
            Model.ConferentionOrganisationDBEntities.GetContext().SaveChanges();
        }
    }
}
