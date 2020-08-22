using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    interface IPlayable
    {
        void play();
    }

    class Frame : IPlayable
    {
        private string image;
        public Frame(string image)
        {
            this.image = image;
        }
        public void play()
        {
            Console.WriteLine("播放:" + image);
        }
    }

    class Playlist : IPlayable
    {
        private List<IPlayable> list = new List<IPlayable>();
        public void add(IPlayable playable)
        {
            list.Add(playable);
        }
        public void play()
        {
            foreach (IPlayable playable in list)
            {
                playable.play();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Frame logo = new Frame("片頭 LOGO");

            Playlist playlist1 = new Playlist();
            playlist1.add(new Frame("Duke 左揮手"));
            playlist1.add(new Frame("Duke 右揮手"));

            Playlist playlist2 = new Playlist();
            playlist2.add(new Frame("Duke 走左腳"));
            playlist2.add(new Frame("Duke 走右腳"));

            Playlist all = new Playlist();
            all.add(logo);
            all.add(playlist1);
            all.add(playlist2);

            all.play();

            Console.ReadLine();
        }
    }
}
