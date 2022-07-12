using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestSerializeFeature
{
    [Serializable]
    public class Test1 : ISerializable
    {
        private string mName = "Test";
        public Test1(string name)
        {
            mName = name;
        }

        private Test1(SerializationInfo info, StreamingContext context)
        {
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                switch (enumerator.Current.Name)
                {
                    case "Name":
                        mName = (string)info.GetValue(enumerator.Current.Name, typeof(string));
                        break;
                }
            }


        }

        public void PrintInfo()
        {
            Console.WriteLine($"Test1: hash code = {this.GetHashCode()}, mName = {mName}");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", mName);
        }
    }

    /// <summary>
    /// This class is special class for testing what happen when deserialized a empty file with defined deserialize by swich case.
    /// </summary>
    public class TestDeSerializeEmptyFileWithDefDeserialize
    {
        private static string file = "TestDeSerializeEmptyFileWithDefDeserialize.bin";
        public static void Test()
        {
            Console.WriteLine("\n\nTest deserialize empty file with defined deserialize.");
            System.IO.File.Create(file).Close();

            Test1 testReadEmpty;
            using (System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                testReadEmpty = (Test1)binaryFormatter.Deserialize(stream); // here will occure error about deserialize empty data
                stream.Close();
            }
            testReadEmpty.PrintInfo();

            System.IO.File.Delete(file);
        }
    }
}
