using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameofKingdom.windows
{
    /// <summary>
    /// Logika interakcji dla klasy Instruction.xaml
    /// </summary>
    public partial class Instruction : Window
    {
        public Instruction()
        {
            InitializeComponent();
            instruction.Text = "Gra Królestw jest to prosta gra polegająca na podjemowaniu decyzji wcielając się w role władcy fikcyjnego osadzonego w średniowieczu królestwa.  Jako władca możesz kierować się różnymi wartościami. Od bogacenia się kosztem ludzi, po bycie przywódcą najpotężniejszej armii w regionie, wszystko jest możliwe. Uważaj jednak, bo zbyt dużo, jest równie złe, jak zbyt mało. Gra ma ukryte warunki natychmiastowego zwycięstwa lub porażki i w rękach gracza pozostaje ich odkrycie.";
            // spojlery - jeśli wszedłeś tu podczas jednej ze swoich pierwszych gier, to cię nie szanuje, ale co mi do tego. Tutaj będą wypisane wszystkie unikalne eveny
            /*
            głód - żywność == 0 - większość mieszkańców twojego królestwa głoduje, jesli nic z tym nie zrobisz skończy się to tragedią
                sukces - głód zarzegnany, nienawidzący cię ludzie w ramach podziękowania za ocalenie dali ci żądzić jeszcze chwilę.
                porażka - Zostałeś władcą tronu z czaszek. Twoi najwierniejsi z wczoraj dziś są twoim obiadem, zginiesz śmiercia potwora, jakim byłeś.
            hedonizm - żywność == 100 - ludzie mają więcej, niż są w stanie zjeść, co sprawia, że są coraz bardziej rozżutni i nie wórży to nic dobrego
                sukces - ludzie się opamiętali i nie stało się nic złego
                porażka - zostałeś królem błaznów lub błaznem wśród króli. Wraz z swoimi mieszkańcami popadliście w ciąg zaspokajania swoich coraz dziwniejszych potrzeb, co doprowadziło do twojej śmierci z powodu rozerwania zbyt rozepchanego żołądka
            zapaść gospodarcza - kasa == 0 - ani ty ani twoi ludzie nie macie więcej pieniędzy, co doprowadzi do nie przewidywalnych skótków
                sukces - genialna reforma ekonomiczna ożywiła gospodarkę i dała wszystkim nadzieję
                porażka - twoje państwo zmieniło się w piekło na ziemi, krainę bez prawia. Bez rządu żyć mogą tylko najsilniejszy, a ty zginąłeś zabity przez jednego z służących pragnącego twoich spodni.
            klęska urodzaju - kasa == 100 - państwo i ludzie są tak bogaci, że nie mają co robić z pieniędzmi, co sprawia, że nikt nie chce dalej pracować
                sukces - trafne inwestycje i reforma monetarna, co prawda zabrała ludzią ich oszczędności, ale sprawiła, że praca znowu ma sens, a państwo może sie rozwijać.
                porażka - państwo bez żebraków czy biednych sierot wydaje sie niebem, jednak nie dla ciebie ani ich dzieci, najlepsi handlarze przejeli władze w państwie, żeby uporac sie z tą tragedią, a ty zostałes wygnany
            powstanie chłopskie - armia == 0 - twój ojciec mawiał, że pióro jest silniejsze od miecza, ale czy jest tak naprawdę?
                sukces - Pióro, zaprawdę jest silniejsze od miecza. Udało ci się dyplomatycznie uspokoić niepokoje oraz zażegnać ryzyko powstania armi chłopskiej
                porażka - podobnie jak twój ojciec, zginąłes, jednak on od sztyletu w klatce piersiowej, a ty od nabicia na pal, przez złych chłopów
            przewrót wojskowych fanatyków
                sukces - Współpraca z kościolem powolila ci na powstrzymanie przewrotu i odzyskanie władzy
                porażka - Krew dla boga krwi, Czaszki na tron z czaszek. Tak skandowali wyznawcy jednego z twoich generałów kilka dni po przewrocie wojskowym. Na szczęście nie dożyłeś momentu, aż ich krzyki się spełniły
            Viva la Republic - control == 0 - Ludzie z śmiesznymi kolorowymi flagami głoszą równość i jakąś demokracje. Śmieszni wariaci
                sukces - zaprawde byli śmieszni, kiedy twoja armia zabijała ich jednego po drugim
                porażka - zaprawdę mieli racje pomyślałeś, zanim ostrze na dziwnej maszynie obcieło ci głowę przy krzykach tłumów
            Absolut ruler - control == 100 - kontrolujesz cale państwo i każdy jego aspekt, przez co ludzie nie mają już żadnego znaczenia
                insta win - jako władca absolutny przeżyłeś całe swoje życie w dostatku i przekazałeś władzę najstarszemu synowi
            pustkowie - population == 0 -wojny, klęski i choroby zniszczyły populację twojego państwa, a jak wiesz bez niej nie ma państwa
                sukces - dzieki dużym inwestycją udało ci się zachęcić ludzi z innych państw do osiedlenia sięu ciebie, kryzys zażegnany
                porażka - straciłeś ludzi, a potem państwo. W końcu jeśli nikt nie może go bronić, kto może nim rządzić?
            ostatnia plaga - twoje pańśtwo jest tak gęsto zamiaszkałe, że nieznana plaga zaczęla zabijać większość twoich poddanych
                sukces - dzieki wsparciu różnych grup udało ci się pokonać plagę jednak zdążyła ona zebrać swoje żniow
                porażka - plaga zabiła wszystkich poza tobą, ale życie w wierzy może trwać tak długo jak masz tam jedzenie....
            koniec czasu - czas == 100 - twoje dni dobiegly końca, a o zmarłych nie mówi się źle
                win - ty i twoje państwo przetrwaliście próbę czasu, teraz pora, żeby twój następca przejął ten zaiście rodzinny interes
             */
        }

        private void Btn_return(object sender, RoutedEventArgs e)
        {
            Welcome win = new();
            win.Show();
            Close();
        }
    }
}
