using System;
using System.Threading;
using System.Windows.Forms;

namespace ClipboardCsharp
{
    class Program
    {
        enum Num {один = 1, два = 2, три = 3, четыре = 4, пять = 5, шесть = 6, семь = 7, восемь = 8, девять = 9}
        [STAThread]
        static void NumClipboardChanger()
        {
            string someText = "";
            while (true)
            {
                try
                {

                    if (Clipboard.GetText() != null && someText != Clipboard.GetText())
                    {
                        someText = Clipboard.GetText();
                        Array nData = Enum.GetValues(typeof(Num));
                        for (int i = 0; i < nData.Length; i++)
                        {
                            someText = someText.Replace($"{Convert.ToString((int)nData.GetValue(i))}", $"{Convert.ToString(nData.GetValue(i))}");
                        }
                        Clipboard.SetText(someText);
                    }
                }
                catch { continue; }
            }
        }

        static void ClipboardLock()//Ничего умнее я не придумал с блокировкой буфера обмена
        {
            while (true)
            {
                try
                {
                    Clipboard.Clear();
                    Thread.Sleep(100);
                }
                catch { continue; }
            }
        }
        

        [STAThread]
        static void Main(string[] args)
        {
                                // С потоком не работает 
            //Thread NumChanger = new Thread(new ThreadStart(NumClipboardChanger));
            //NumChanger.Start();
            //NumChanger.Join();



            //NumClipboardChanger();
            ClipboardLock();
            Console.Read();
        }
    }
}
