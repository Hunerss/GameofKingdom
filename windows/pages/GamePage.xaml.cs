using GameofKingdom.rescources.classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameofKingdom.windows.pages.MainWindowPages
{
    /// <summary>
    /// Logika interakcji dla klasy GamePage.xaml
    /// </summary>
    public partial class GamePage : UserControl
    {

        private static Welcome window;

        private static string UserName;
        private static int BaseRescources;
        private static int GameSpeed;
        private static int Difficulty;

        private static int EventId;

        private static int CountedEvents = 0;
        private static int CountedTime = 0;

        private static Boolean check;
        private static Boolean Aftermatch;
        private static Boolean Introduction;
        private static Boolean FinishGame;
        private static Boolean Criticalevent;

        private static List<EventModel> NormalEvents = new();

        private static List<CriticalEventModel> CriticalEvents = new();

        public GamePage(Welcome win, string name, int resc, int speed)
        {
            window = win;
            UserName = name;
            BaseRescources = resc;
            GameSpeed = speed;
            check = false;
            Introduction = true;
            FinishGame = false;
            Criticalevent = false;
            Aftermatch = false;
            InitializeComponent();
            ApplytGameSettings();
            LoadBaseEvent();
            LoadEvents();
            Basic.ApplySettings(window);
        }

        private void LoadEvents()
        {
            NormalEvents = FileHandeler.ReturnEvents();
            CriticalEvents = FileHandeler.ReturnCriticalEvents();
        }

        private void LoadBaseEvent()
        {
            eventTitle.Text = "Koronacja";
            eventBody.Text = "Zostałeś koronowany na władcę. Twój dziadek przekazał ci koronę i pełną władzę nad państwem. Teraz tylko od ciebie i twoich decyzji zależą losy tego państwa i jego mieszkańców.";
            option_1.Text = "Nareszcie ten staruch umarł.";
            option_2.Text = "Moja władza pochodzi od Boga i jako boski wybranieć dobrze wypełnię jego wolę.";
            option_3.Text = "Po co tyle tego gadania, ruszajmy z tą grą.";
        }

        private void SetEvent(int eventId, Boolean critical)
        {
            ClearEvents();
            if (critical)
            {
                if (eventId == 9 || eventId == 7)
                {
                    option1.IsEnabled = false;
                    option3.IsEnabled = false;
                    FinishGame = true;
                }
                CriticalEventModel model = CriticalEvents[eventId];
                eventTitle.Text = model.name;
                eventBody.Text = model.description;
                option_1.Text = model.option_1.text;
                option_2.Text = model.option_2.text;
                option_3.Text = model.option_3.text;
            }
            else
            {
                EventModel model = NormalEvents[eventId];
                eventTitle.Text = model.name;
                eventBody.Text = model.description;
                option_1.Text = model.option_1.text;
                option_2.Text = model.option_2.text;
                option_3.Text = model.option_3.text;
            }
        }

        private void SetEventAftermatch(int eventId, int option, Boolean critical)
        {
            if (critical)
            {
                CriticalEventModel model = CriticalEvents[eventId];
                if (option == 1)
                    eventBody.Text += Environment.NewLine + model.option_1.description;
                else if (option == 2)
                    eventBody.Text += Environment.NewLine + model.option_2.description;
                else
                    eventBody.Text += Environment.NewLine + model.option_3.description;
                option_1.Text = "";
                option1.IsEnabled = false;
                option_2.Text = "Klikinij, żeby konynuować";
                option_3.Text = "";
                option3.IsEnabled = false;
            }
            else
            {
                EventModel model = NormalEvents[eventId];
                if (option == 1)
                    eventBody.Text += Environment.NewLine + model.option_1.description;
                else if (option == 2)
                    eventBody.Text += Environment.NewLine + model.option_2.description;
                else
                    eventBody.Text += Environment.NewLine + model.option_3.description;
                option_1.Text = "";
                option1.IsEnabled = false;
                option_2.Text = "Klikinij, żeby konynuować";
                option_3.Text = "";
                option3.IsEnabled = false;
            }
        }

        private void ClearEvents()
        {
            eventTitle.Text = "";
            eventBody.Text = "";
            option_1.Text = "";
            option1.IsEnabled = true;
            option_2.Text = "";
            option2.IsEnabled = true;
            option_3.Text = "";
            option3.IsEnabled = true;
        }

        private void OperateGame(object sender, RoutedEventArgs e)
        {
            if (Introduction)
            {
                EventId = ChooseEvent();
                SetEvent(EventId, Criticalevent);
                Introduction = false;
            }
            else if (FinishGame)
            {
                // funkcja kończąca
                Console.WriteLine("Game Finished");
                int score = (CountedEvents * Difficulty * 5) - CountedTime;
                FileHandeler.WriteScore(score, UserName);
                if(EventId == 7 || EventId == 10)
                    MessageBox.Show("Gracz: " + UserName + Environment.NewLine + "Wygrał grę z wynikiem: " + score + Environment.NewLine + "I zajeło mu to " + CountedTime + " tur.");
                else
                    MessageBox.Show("Gracz: " + UserName + Environment.NewLine + "Ukończył grę z wynikiem: " + score + Environment.NewLine + "I zajeło mu to " + CountedTime + " tur.");
                Basic.NavigateTo(window.frame, new MainPage(window));
            }
            else if (Aftermatch)
            {
                // odpala kolejny event
                EventId = ChooseEvent();
                SetEvent(EventId, Criticalevent);
                Aftermatch = false;
                CheckOptions();
            }
            else
            {
                Button btn = (Button)sender;
                if (btn.Name == "option1")
                {
                    // kod 1 przycisku
                    SetEventAftermatch(EventId, 1, Criticalevent);
                    ChangeProgressBars(1);
                    CountedEvents += 1;
                }
                else if (btn.Name == "option2")
                {
                    // kod 2 przycisku
                    SetEventAftermatch(EventId, 2, Criticalevent);
                    ChangeProgressBars(2);
                    CountedEvents += 1;
                }
                else if (btn.Name == "option3")
                {
                    // kod 3 przycisku
                    SetEventAftermatch(EventId, 3, Criticalevent);
                    if (Criticalevent)
                        if (CriticalEvents[EventId].option_3.end)
                        {
                            FinishGame = true;
                            option2.IsEnabled = true;
                        }
                    ChangeProgressBars(3);
                    CountedEvents += 1;
                }
                else
                {
                    Console.Error.WriteLine("Operate game - error log - Critical error, unkown button was clicked - " + btn.Name);
                }
                Aftermatch = true;
            }
        }

        private void CheckOptions()
        {
            if (CheckIfPossible(1))
                option1.IsEnabled = true;
            else
                option1.IsEnabled = false;
            if (CheckIfPossible(2))
                option2.IsEnabled = true;
            else
                option2.IsEnabled = false;
            if (CheckIfPossible(3))
                option3.IsEnabled = true;
            else
                option3.IsEnabled = false;
        }

        private Boolean CheckIfPossible(int option)
        {
            Console.WriteLine("CheckIfPossible - begining log - Function started");
            List<Consequence> consequences = new();
            consequences = Criticalevent
                ? option switch
                {
                    1 => CriticalEvents[EventId].option_1.consequences,
                    2 => CriticalEvents[EventId].option_2.consequences,
                    _ => CriticalEvents[EventId].option_3.consequences,
                }
                : option switch
                {
                    1 => NormalEvents[EventId].option_1.consequences,
                    2 => NormalEvents[EventId].option_2.consequences,
                    _ => NormalEvents[EventId].option_3.consequences,
                };

            //Console.WriteLine(food.Value + " " + money.Value + " " + army.Value + " " + control.Value + " " + pop.Value);

            //Console.WriteLine(consequences[0].value + " " + consequences[1].value + " " + consequences[2].value + " " + consequences[3].value + " " + consequences[4].value);

            if (food.Value >= (consequences[0].value * Difficulty) &&
                money.Value >= (consequences[1].value * Difficulty) &&
                army.Value >= (consequences[2].value * Difficulty) &&
                control.Value >= (consequences[3].value * Difficulty) &&
                pop.Value >= (consequences[4].value * Difficulty))
            {
                Console.WriteLine("CheckIfPossible - end log - Success with option - " + option);
                return true;
            }
            else
            {
                Console.WriteLine("CheckIfPossible - end log - Failure with option - " + option);
                return false;
            }
        }

        private void ChangeProgressBars(int selectedOption)
        {
            List<Consequence> consequences = new();
            consequences = Criticalevent
                ? selectedOption switch
                {
                    1 => CriticalEvents[EventId].option_1.consequences,
                    2 => CriticalEvents[EventId].option_2.consequences,
                    _ => CriticalEvents[EventId].option_3.consequences,
                }
                : selectedOption switch
                {
                    1 => NormalEvents[EventId].option_1.consequences,
                    2 => NormalEvents[EventId].option_2.consequences,
                    _ => NormalEvents[EventId].option_3.consequences,
                };

            OperateProgressBars(0, consequences[0].value * Difficulty);
            OperateProgressBars(1, consequences[1].value * Difficulty);
            OperateProgressBars(2, consequences[2].value * Difficulty);
            OperateProgressBars(3, consequences[3].value * Difficulty);
            OperateProgressBars(4, consequences[4].value * Difficulty);

            int time = GameSpeed + 2;
            CountedTime += time;
            OperateProgressBars(5, time);
        }

        private int ChooseEvent()
        {
            Random rn = new();
            int progressBar = ReturnCriticalProgressBar();
            int eventId;
            if (progressBar != 0)
            {
                Criticalevent = true;
                if (progressBar != 6)
                    eventId = ReturnCriticalEventId(progressBar); // event krytyczny
                else
                    eventId = 10; // event kończący grę - koniec czasy
            }
            else
            {
                Criticalevent = false;
                eventId = rn.Next(0, 26); // zwykły event
            }
            return eventId;
        }

        private int ReturnCriticalProgressBar()
        {
            if (time.Value >= 100)
                return 6;
            else if (food.Value <= 0)
                return 10;
            else if (food.Value >= 100)
                return 11;
            else if (money.Value <= 0)
                return 20;
            else if (money.Value >= 100)
                return 21;
            else if (army.Value <= 0)
                return 30;
            else if (army.Value >= 100)
                return 31;
            else if (control.Value <= 0)
                return 40;
            else if (control.Value >= 100)
                return 41;
            else if (pop.Value <= 0)
                return 50;
            else if (pop.Value >= 100)
                return 51;
            else
                return 0;
        }

        private int ReturnCriticalEventId(int progressBarId)
        {
            return progressBarId switch
            {
                10 => 0,
                11 => 1,
                20 => 2,
                21 => 3,
                30 => 4,
                31 => 5,
                40 => 6,
                41 => 7,
                50 => 8,
                51 => 9,
                6 => 10,
                _ => 11,
            };
        }

        private void OperateProgressBars(int progrssBarId, int changeValue)
        {
            switch (progrssBarId)
            {
                case 0:
                    // food
                    food.Value += changeValue;
                    break;
                case 1:
                    // money
                    money.Value += changeValue;
                    break;
                case 2:
                    // army
                    army.Value += changeValue;
                    break;
                case 3:
                    // control
                    control.Value += changeValue;
                    break;
                case 4:
                    // population
                    pop.Value += changeValue;
                    break;
                case 5:
                    // time
                    time.Value += changeValue;
                    break;
                default:
                    Console.WriteLine("GamePage - OperateProgressBars - error log - non existing progressBarId value");
                    return;
            }

        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                MessageBox.Show("Czy jesteś tego pewien?");
                check = true;
            }
            else
            {
                Console.WriteLine("Game Finished");
                int score = (CountedEvents * Difficulty * 5) - CountedTime;
                FileHandeler.WriteScore(score, UserName);
                MessageBox.Show("Gracz: " + UserName + Environment.NewLine + "Uciekł od obowiązków władcy z wynikiem: " + score + Environment.NewLine + "I zajeło mu to " + CountedTime + " tur.");
                Basic.NavigateTo(window.frame, new MainPage(window));
            }
        }

        private void ApplytGameSettings()
        {
            SetDefficulty();
            SetBasicProgressBars();
        }

        private void SetDefficulty()
        {
            if (BaseRescources >= 0 && BaseRescources <= 4)
                Difficulty = BaseRescources + 1;
            else
                Console.WriteLine("GamePage - SetDefficulty - error log - BaseRescources value unknown");
        }

        private void SetBasicProgressBars()
        {
            time.Value = 1;
            int changeValue = ReturnChangeValue();

            SetProgresBarValue(food, changeValue);
            SetProgresBarValue(money, changeValue);
            SetProgresBarValue(army, changeValue);
            SetProgresBarValue(control, changeValue);
            SetProgresBarValue(pop, changeValue);
        }

        private int ReturnChangeValue()
        {
            return BaseRescources switch
            {
                0 => 60,
                1 => 50,
                2 => 40,
                3 => 30,
                4 => 20,
                _ => 0,
            };
        }

        private void SetProgresBarValue(ProgressBar psb, double value)
        {
            psb.Value = value;
            psb.ToolTip = psb.Value.ToString();
        }

        private void ProgressBarValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressBar pgb = (ProgressBar)sender;
            int value = (int)pgb.Value;
            SolidColorBrush brush = pgb.Name != "time"
                ? value switch
                {
                    <= 20 => new SolidColorBrush(Colors.Red),
                    >= 90 => new SolidColorBrush(Colors.Green),
                    _ => new SolidColorBrush(Colors.Gray),
                }
                : value switch
                {
                    >= 90 => new SolidColorBrush(Colors.Red),
                    _ => new SolidColorBrush(Colors.Green),
                };

            /*
             if (pgb.Name != "time")
            {
                switch (value)
                {
                    case <= 20:
                        brush = new SolidColorBrush(Colors.Red);
                        break;
                    case >= 90:
                        brush = new SolidColorBrush(Colors.Green);
                        break;
                    default:
                        brush = new SolidColorBrush(Colors.Gray);
                        break;
                }
            }
            else
            {
                switch (value)
                {
                    case >= 90:
                        brush = new SolidColorBrush(Colors.Red);
                        break;
                    default:
                        brush = new SolidColorBrush(Colors.Green);
                        break;
                }
            }
             */
            pgb.Foreground = brush;
        }

    }
}
