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
    class SubClassInherISerialize : ISerializable
    {
        private string mName;
        public SubClassInherISerialize(string name)
        {
            mName = name;
        }

        private SubClassInherISerialize(SerializationInfo info, StreamingContext context)
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
            Console.WriteLine($"SubClassInherISerialize: hash code = {this.GetHashCode()}, mName = {mName}");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", mName);
        }
    }

    [Serializable] // Attention! If need serializable, it must be set Serializable attribute.
    class SubClassNotInherISerialize
    {
        private string mName;
        public SubClassNotInherISerialize(string name)
        {
            mName = name;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"SubClassNotInherISerialize: hash code = {this.GetHashCode()}, mName = {mName}");
        }
    }

    [Serializable]
    class TestSerialize : ISerializable
    {
        public TestSerialize()
        {
            mInherSerialize = new SubClassInherISerialize("AAA");
            mNotInherSerialize = new SubClassNotInherISerialize("BBB");
        }

        private TestSerialize(SerializationInfo info, StreamingContext context)
        {
            SerializationInfoEnumerator enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                switch (enumerator.Current.Name)
                {
                    case "InherISerialize":
                        mInherSerialize = (SubClassInherISerialize)info.GetValue(enumerator.Current.Name, typeof(SubClassInherISerialize));
                        break;
                    case "NotInherISerialize":
                        mNotInherSerialize = (SubClassNotInherISerialize)info.GetValue(enumerator.Current.Name, typeof(SubClassNotInherISerialize));
                        break;
                }
            }
        }

        private SubClassInherISerialize mInherSerialize;
        private SubClassNotInherISerialize mNotInherSerialize;

        public void PrintInfo()
        {
            Console.WriteLine("In TestSerialize, print information!");
            mInherSerialize.PrintInfo();
            mNotInherSerialize.PrintInfo();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("InherISerialize", mInherSerialize);
            info.AddValue("NotInherISerialize", mNotInherSerialize);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestSerialize test = new TestSerialize();
            test.PrintInfo();

            string file = "TestSerializeFile.bin";
            // Serialize and save to file
            using (System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, test);
                stream.Close();
            }
            Console.WriteLine("\nSerialize and save to TestSerializeFile.bin");

            // Read and Deserialize
            Console.WriteLine("\n\nRead and Deserialize");
            TestSerialize read;
            using (System.IO.FileStream stream = new System.IO.FileStream(file, System.IO.FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                read = (TestSerialize)binaryFormatter.Deserialize(stream);
                stream.Close();
            }
            read.PrintInfo();


            // Test creating a empty file and do Deserialize
            //Console.WriteLine("\nTest creating a empty file and do Deserialize");
            //string emptyFile = "testEmptyFile.bin";
            //System.IO.File.Create(emptyFile).Close();
            //TestSerialize testReadEmpty;
            //using (System.IO.FileStream stream = new System.IO.FileStream(emptyFile, System.IO.FileMode.Open))
            //{
            //    BinaryFormatter binaryFormatter = new BinaryFormatter();
            //    testReadEmpty = (TestSerialize)binaryFormatter.Deserialize(stream); // here will occure error about deserialize empty data
            //    stream.Close();
            //}
            //read.PrintInfo();

            Console.ReadLine();
        }
    }
    // Result:
    // In TestSerialize, print information!
    // SubClassInherISerialize: hash code = 46104728, mName = AAA
    // SubClassNotInherISerialize: hash code = 12289376, mName = BBB
    //
    // Serialize and save to TestSerializeFile.bin
    // 
    // 
    // Read and Deserialize
    // In TestSerialize, print information!
    // SubClassInherISerialize: hash code = 56200037, mName = AAA
    // SubClassNotInherISerialize: hash code = 36038289, mName = BBB

    // Conclusion:
    // 1. If all need serializable, it must be set Serializable attribute.
    // 2. If a class need serializable, it must be implement ISerializable. 
    //    But its fields which need be serialized can do not implement ISerializable, serialized fields only need setting Serializable attribute.
    // 3. Can not deserialize empty file.
}
