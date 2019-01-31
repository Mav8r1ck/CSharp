using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Yandex.Geocoder;
using Yandex.Geocoder.Enums;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public class ImageProcessing
    {
        private string directoryForProcessing;
        private string resultDirectory;
        internal UserCommands result;
        const int tagCreateImage = 0x0132; //for date of creat image in metadata
        const int tagLatitudeRef = 0x0001;
        const int tagLatitude = 0x0002;
        const int tagLongtitudeRef = 0x0003;
        const int tagLongtitude = 0x0004;

        public void MakeSubDirectory()
        {
            Console.WriteLine("Please, write directory name");
            directoryForProcessing = Console.ReadLine();

            DirectoryInfo dirInfo = new DirectoryInfo(directoryForProcessing);
            resultDirectory = dirInfo.Name + result.ToString();
            if (dirInfo.Exists)
            {
                resultDirectory = dirInfo.CreateSubdirectory(resultDirectory).FullName;
            }
        }

        public void RenameByDate()
        {
            var files = FilesInDierctory();
            DateTime value;

            foreach (var file in files)
            {
                Image image = Image.FromFile(file.FullName);
                var result = ImagePropertyGetFromImage(image, tagCreateImage);
                value = WhenImageMadePropertyToDateTime(result);
                image.Save($@"{resultDirectory}\{value.Day.ToString()}{value.Month.ToString()}{value.Year.ToString()}{file.Extension}");
            }
        }

        public DateTime WhenImageMadePropertyToDateTime(string date)
        {
            date = date.TrimEnd('\0');
            string[] timeElements = date.Split(':', ' ');
            DateTime time = new DateTime(Convert.ToInt32(timeElements[0]), Convert.ToInt32(timeElements[1]), Convert.ToInt32(timeElements[2]));
            return time;
        }

        public FileInfo[] FilesInDierctory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directoryForProcessing);
            return dirInfo.GetFiles();
        }

        public string ImagePropertyGetFromImage(Image image, int tag)
        {
            var propItem = image.GetPropertyItem(tag).Value;
            var encoding = new System.Text.ASCIIEncoding();
            var result = encoding.GetString(propItem);
            return result;
        }

        public void PrintDateToImage()
        {
            var files = FilesInDierctory();
            foreach (var file in files)
            {
                Image image = new Bitmap(file.FullName);
                var result = ImagePropertyGetFromImage(image, tagCreateImage);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawString(result, new Font("Arial", 30), new SolidBrush(Color.Black), 150.0F, 50.0F, new StringFormat());
                image.Save($@"{resultDirectory}\{file.Name}");
            }
        }

        public void SortImagesByYear()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(resultDirectory);
            var files = FilesInDierctory();
            DateTime value;
            string subDirectory;

            foreach (var file in files)
            {
                Image image = Image.FromFile(file.FullName);
                var result = ImagePropertyGetFromImage(image, tagCreateImage);
                value = WhenImageMadePropertyToDateTime(result);
                subDirectory = value.Year.ToString();
                if (dirInfo.Exists) dirInfo.CreateSubdirectory(subDirectory);
                image.Save($@"{resultDirectory}\{subDirectory}\{file.Name}");
            }
        }

        public async Task SortByPlaceAsync()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(resultDirectory);
            var files = FilesInDierctory();
            DateTime value;
            string subDirectory;

            foreach (var file in files)
            {
                Image image = Image.FromFile(file.FullName);
                var latitude = GetLatitude(image);

                var longtitude = GetLongitude(image);
                if (latitude != null && longtitude != null)
                {
                    var request = new ReverseGeocoderRequest { Latitude = (double)latitude, Longitude = (double)longtitude };
                    var client = new GeocoderClient();
                    var response = await client.ReverseGeocode(request);
                    var firstGeoObject = response.GeoObjectCollection.FeatureMember.FirstOrDefault();
                    var addressComponents = firstGeoObject.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components;
                    var country = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Country));
                    var province = addressComponents.LastOrDefault(c => c.Kind.Equals(AddressComponentKind.Province));
                    var area = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Area));
                    var city = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Locality));
                    var street = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.Street));
                    var house = addressComponents.FirstOrDefault(c => c.Kind.Equals(AddressComponentKind.House));
                    subDirectory = country.Name;
                    if (dirInfo.Exists) dirInfo.CreateSubdirectory(subDirectory);
                    image.Save($@"{resultDirectory}\{subDirectory}\{file.Name}");
                }
            }
        }
        public static double? GetLatitude(Image targetImg)
        {
            try
            {
                //Property Item 0x0001 - PropertyTagGpsLatitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                //Property Item 0x0002 - PropertyTagGpsLatitude
                PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                return ExifGpsToDouble(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static double? GetLongitude(Image targetImg)
        {
            try
            {
                ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                //Property Item 0x0004 - PropertyTagGpsLongitude
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                return ExifGpsToDouble(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;


            double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = coorditate * -1;
            return coorditate;
        }
    }    
}
