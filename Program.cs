using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakızmakinesi2
{

    interface Durum
    {   
        void paraEkle();
        void paraIade();
        void cevir();
    }





    class SakızMakinesi
    {
        public Durum paraYokState;
        public Durum paraVarState;
        public Durum sakizKalmadiState;

        Durum simdikiDurum;
        public int sakizSayisi = 5;
        public SakızMakinesi()
        {
            paraYokState = new ParaYokDurumu(this);
            paraVarState = new ParaVarDurumu(this);
            sakizKalmadiState = new SakizKalmadıDurumu(this);
            simdikiDurum = paraYokState;
        }

        public Durum get_state()
        {
            return simdikiDurum;
        }

        public void set_state(Durum s)
        {
            simdikiDurum = s;
        }

        public void paraEkle()
        {
            simdikiDurum.paraEkle();
        }

        public void paraIade()
        {
            simdikiDurum.paraIade();
        }

        public void cevir()
        {
            simdikiDurum.cevir();

        }

        public void sakizindir()
        {
            Console.WriteLine("sakiz geliyor..");
            sakizSayisi -= 1;
            Console.WriteLine(sakizSayisi);
        }


    }


    class ParaYokDurumu : Durum
    {
        SakızMakinesi makine;
        public ParaYokDurumu(SakızMakinesi makine)
        {
            this.makine = makine;
        }

        public void paraEkle()
        {
            Console.WriteLine("para eklendi..");
            makine.set_state(makine.paraVarState);
        }

        public void paraIade()
        {
            Console.WriteLine("para yok!");
        }

        public void cevir()
        {
            Console.WriteLine("para yok ne yapmaya calisiyorsun?");
        }
    }

    class ParaVarDurumu : Durum
    {
        SakızMakinesi makine;
        public ParaVarDurumu(SakızMakinesi makine)
        {
            this.makine = makine;
        }

        public void paraEkle()
        {
            Console.WriteLine("para zaten var,kolu cevir!");
        }

        public void paraIade()
        {
            Console.WriteLine("para iade edilmis..");
            makine.set_state(makine.paraYokState);
        }

        public void cevir()
        {
            if(makine.sakizSayisi==1)
            {
                makine.sakizindir();
                makine.set_state(makine.sakizKalmadiState);

            }
            else
            {
                makine.sakizindir();
                makine.set_state(makine.paraYokState);
            }
        }
    }

    

    class SakizKalmadıDurumu : Durum
    {
        SakızMakinesi makine;
        public SakizKalmadıDurumu(SakızMakinesi makine)
        {
            this.makine = makine;
        }

        public void paraEkle()
        {
            Console.WriteLine("sakiz kalmadi malesef");
        }

        public void paraIade()
        {
            Console.WriteLine("sakız kalmadı dedik ne yapıyorsun");
        }

        public void cevir()
        {
            Console.WriteLine("para yok sakiz da yok ne yapmaya calisiyorsun?");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SakızMakinesi makine = new SakızMakinesi();
            makine.paraEkle();
            makine.paraEkle();
            makine.cevir();
            makine.paraEkle();
            makine.cevir();
            makine.paraEkle();
            makine.cevir();
            makine.paraEkle();
            makine.cevir();
            makine.paraEkle();
            makine.cevir();
            makine.paraEkle();
            makine.cevir();
            Console.ReadKey();
        }
    }
}
