using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IT_Heaven.Models.Models.ViewModels;

namespace IT_Heaven.Models.CategoriesSemiModels
{
    public static class CategoriesInformation
    {

        public enum CategoriesEnum
        {
           None , Computers ,  Laptops ,  Consoles ,  PC_Components , Peripherals , Smartphones ,  Tablets ,
            Smartphone_Accessories  ,  Tablet_Accessories ,  TVs  , Audio_systems ,  Headphones ,
            Projector ,
            Rasberry_PI ,  Arduino ,  Components ,  Windows_software ,  Mac_software ,  Games 
        }

        public static string[] Special
        {
            get
            {
                return new string[]
                {
                    "Computers","PC Components","Peripherals",
                    "Smartphone Accessories","Tablet Accessories","TVs","Audio systems",
                    "Headphones","Games"
                };
            }
        }

        public static ICollection<string> Categories
        {
            get
            {
                var categories =
                    new string[] {
                    "None","Computers", "Laptops", "Consoles", "PC Components","Peripherals","Smartphones", "Tablets",
                    "Smartphone Accessories" , "Tablet Accessories", "TVs" ,"Audio systems", "Headphones", "Projector", 
                    "Rasberry PI", "Arduino", "Components", "Windows software", "Mac software", "Games"
                    };
                return categories;
            }
        }
        public static string[] GetAdditionalInformation(string index)
        {
            switch (index)
            {
                case "Computers": return GetAdditionalInformation(0);
                case "PC Components": return GetAdditionalInformation(1);
                case "Peripherals": return GetAdditionalInformation(2);
                case "Smartphone Accessories": case "Tablet Accessories":  return GetAdditionalInformation(3);
                case "TVs": return GetAdditionalInformation(5);
                case "Audio systems": return GetAdditionalInformation(6);
                case "Headphones": return GetAdditionalInformation(7);
                case "Games": return GetAdditionalInformation(8);
                default: return null;
            }

        }
        public static string[] GetAdditionalInformation(int index)
        {
            switch (index)
            {
                case 0:
                    return new string[]
                {
                      "Workstation","Gaming","Server"
                };
                case 1:
                    return new string[]
                {
                        "CPU","GPU","Memory","Motherboard","Hard drive",
                        "SSD","Power supply","Pc case","Sound card","Network card","Cooler"
                };

                case 2:
                    return new string[]
                {
                        "Monitor","Keyboard","Mouse","Headphones(with mic)",
                        "Headphones(without mic)","Computer Speakers","Mousepad",
                        "Usb memory","Camera","External Optical device","Portable hard drive"
                };

                case 3:               
                    return new string[]
                {
                      "Screen protector","Protector" , "Phone case" ,
                      "Charger" , "Battery"  , "External battery" , "Memory cards"
                };
                case 5:
                    return new string[]
                {
                      "LED","LCD","Portable TV"
                };
                case 6:
                    return new string[]
                {
                     "Soundbar","Speakers", "Home theater","Amplifiers"
                };
                case 7:
                    return new string[]
                {
                      "With cord","Bluetooth","Handsfree"
                };
             
                case 8:
                    return new string[]
                {
                      "Action","Arcade","Action-adventure","Adventure","Role-playing","Simulation","Strategy","Sport","Other"
                };
                default: return new string[] { "" };
            }

        }

        public static string CheckAndGetAdditional(string category)
        {
            switch (category)
            {
                case "Computers":
                    {
                        return "Laptops";
                    }
                case "Smartphone Accessories":
                    {
                        return "Tablet Accessories";
                    }
                default: return "";
            }
        }

    }
}
