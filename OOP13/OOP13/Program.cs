using System;
using static OOP13.Transport;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;


namespace OOP13
{
    class Programm
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Toyota", "Sedan", "Petrol", 200);
            Car car2 = new Car("Honda", "SUV", "Diesel", 250);
            Console.WriteLine("--------------Binary---------------");
            BinaryFormatter formaterBin = new BinaryFormatter();
            using (FileStream fs = new FileStream("cars.dat", FileMode.OpenOrCreate))
            {
                formaterBin.Serialize(fs, car1);
                formaterBin.Serialize(fs, car2);
            }
            using (FileStream fs = new FileStream("cars.dat", FileMode.OpenOrCreate))
            {
                Transport DesCar = (Car)formaterBin.Deserialize(fs);
                Console.WriteLine(DesCar.ToString());
                DesCar = (Car)formaterBin.Deserialize(fs);
                Console.WriteLine(DesCar.ToString());

            }
            Console.WriteLine("--------------SOAP-----------------");
            SoapFormatter formatterSoap = new SoapFormatter();
            using (FileStream fs = new FileStream("cars.soap", FileMode.OpenOrCreate))
            {
                formatterSoap.Serialize(fs, car1);
                formatterSoap.Serialize(fs, car2);
            }
            using (FileStream fs = new FileStream("cars.soap", FileMode.OpenOrCreate))
            {

                Transport car = (Car)formatterSoap.Deserialize(fs);
                Console.WriteLine(car.ToString());
                car = (Car)formatterSoap.Deserialize(fs);
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine("--------------JSON-----------------");
            string json = JsonConvert.SerializeObject(car1);
            using (var fs = new StreamWriter("cars.json"))
            {
                fs.Write(json);
            }
            using (var fs = new StreamReader("cars.json"))
            {
                json = fs.ReadToEnd();
                Car car = JsonConvert.DeserializeObject<Car>(json);
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine("--------------XML------------------");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, car1);
            }
            using (FileStream fs = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                Car car = (Car)xmlSerializer.Deserialize(fs);
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine("--------------Task2------------------");
            List<Car> cars = new List<Car>
            {
                new Car("Toyota", "Sedan", "Petrol", 200),
                new Car("Honda", "SUV", "Diesel", 250)
            };
            XmlSerializer xmlSerializerCars = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream("carList.xml", FileMode.OpenOrCreate))
            {
                xmlSerializerCars.Serialize(fs, cars);
            }
            using (FileStream fs = new FileStream("carList.xml", FileMode.OpenOrCreate))
            {
                List<Car> DesList = (List<Car>)xmlSerializerCars.Deserialize(fs);
                foreach (Car item in DesList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("--------------XmlSelector------------------");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("carList.xml");
            // Пример 1: Выбор всех моделей автомобилей
            XmlNodeList modelNodes = xDoc.SelectNodes("//Car/model");
            Console.WriteLine("Модели автомобилей:");
            foreach (XmlNode node in modelNodes)
            {
                Console.WriteLine(node.InnerText);
            }
            Console.WriteLine();

            // Пример 2: Выбор всех типов двигателей автомобилей, у которых лошадиные силы больше 200
            XmlNodeList engineTypeNodes = xDoc.SelectNodes("//Car[CarEngine/horsePower > 200]/CarEngine/typeOfEngine");
            Console.WriteLine("Типы двигателей с лошадиными силами больше 200:");
            foreach (XmlNode node in engineTypeNodes)
            {
                Console.WriteLine(node.InnerText);
            }
            Console.WriteLine("--------------LINQToXLM------------------");
            string fileName = "base.xml";
            XDocument doc = new XDocument();
            XElement library = new XElement("library");
            doc.Add(library);

            //создаем элемент "track"
            XElement track = new XElement("track");
            //добавляем необходимые атрибуты
            track.Add(new XAttribute("id", 1));
            track.Add(new XAttribute("genre", "Rap"));
            track.Add(new XAttribute("time", "3:24"));

            //создаем элемент "name"
            XElement name = new XElement("name");
            name.Value = "Who We Be RMX (feat. 2Pac)";
            track.Add(name);

            //создаем элемент "artist"
            XElement artist = new XElement("artist");
            artist.Value = "DMX";
            track.Add(artist);

            string albumData = "<album>The Dogz Mixtape: Who's Next?!</album>";
            XElement album = XElement.Parse(albumData);
            track.Add(album);
            doc.Root.Add(track);
            // Создаем второй трек с другой информацией
            XElement track2 = new XElement("track");
            track2.Add(new XAttribute("id", 2));
            track2.Add(new XAttribute("genre", "Pop"));
            track2.Add(new XAttribute("time", "3:45"));

            XElement name2 = new XElement("name");
            name2.Value = "Shape of You";
            track2.Add(name2);

            XElement artist2 = new XElement("artist");
            artist2.Value = "Ed Sheeran";
            track2.Add(artist2);

            library.Add(track2);


            //сохраняем наш документ
            doc.Save(fileName);
            //Получить все треки исполнителя "DMX"
            XDocument doc1 = XDocument.Load(fileName);

            var dmxTracks = doc1.Descendants("track")
                               .Where(t => t.Element("artist")?.Value == "DMX")
                               .ToList();
            foreach (var item in dmxTracks)
            {
                Console.WriteLine("Track: {0}", item.Element("name")?.Value);
                Console.WriteLine("Artist: {0}", item.Element("artist")?.Value);
                Console.WriteLine("Genre: {0}", item.Attribute("genre")?.Value);
                Console.WriteLine("Time: {0}", item.Attribute("time")?.Value);
                Console.WriteLine();
            }
        }

    }
}