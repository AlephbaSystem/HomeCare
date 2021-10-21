using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using HomeCare.Models;
using Xamarin.Forms;

namespace HomeCare.ViewModels
{
    public class TutorialViewModel: INotifyPropertyChanged
    {
        private int position;
        private string nextButtonText;
        private string skipButtonText = null;
        private ObservableCollection<Tutorial> _items;
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetNextButtonText(string nextButtonText) => NextButtonText = nextButtonText;
        private void SetSkipButtonText(string skipButtonText) => SkipButtonText = skipButtonText;

        public TutorialViewModel()
        {
            SetNextButtonText("بعدی");
            SetSkipButtonText("قبلی");
            OnTutorial();
            LaunchNextCommand();
            LaunchSkipCommand();
        }

        public ObservableCollection<Tutorial> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnTutorial()
        {
            Items = new ObservableCollection<Tutorial>
            {
                new Tutorial
                {
                    Title = "خوش آمدید",
                    Content = "شما چند کلیک تا دنیا خانه هوشمند فاصله دارید.",
                    ImageUrl = "Tutorial1.jpg"
                },
                new Tutorial
                {
                    Title = "گوشی همراهتو متصل کن",
                    Content = "شما می توانید گوشی همراه خود و اعضای خانواده را تا سقف ۱۰ نفر به سیستم متصل کنید.",
                    ImageUrl = "tutorial2.jpg"
                },
                new Tutorial
                {
                    Title = "همه چیو تحت نظر داشته باش",
                    Content = "از تک تک اتفاقات رخ داده به راحت ترین شکل ممکن باخبر شوید.",
                    ImageUrl = "tutorial3.jpg"
                },
            };
        }

        private void LaunchNextCommand()
        {

            NextCommand = new Command(() =>
            {
                if (LastPositionReached())
                {
                    ExitOnBoarding();
                }
                else
                {
                    MoveToNextPosition();
                }
            });
        }
        private void LaunchSkipCommand()
        {
            SkipCommand = new Command(() =>
            {
                ExitOnBoarding();

            });
        }

        private static void ExitOnBoarding()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        private void MoveToNextPosition()
        {
            var nextPosition = ++Position;
            Position = nextPosition;
        }

        private bool LastPositionReached()
            => Position == Items.Count - 1;



        public string NextButtonText
        {
            get => nextButtonText;
            set
            {
                nextButtonText = value;
                OnPropertyChanged(nameof(NextButtonText));
            }
        }
        public string SkipButtonText
        {
            get => skipButtonText;
            set
            {
                nextButtonText = value;
                OnPropertyChanged(nameof(SkipButtonText));
                //UpdateSkipButtonText();
            }
        }

        public int Position
        {
            get => position;
            set
            {
                position = value;
                OnPropertyChanged(nameof(Position));
                UpdateNextButtonText();
            }
        }

        private void UpdateSkipButtonText()
        {
            if (LastPositionReached())
            {
                SetSkipButtonText("رد کن");
            }
            else
            {
                SetSkipButtonText("رد کن");
            }
        }

        private void UpdateNextButtonText()
        {
            if (LastPositionReached())
            {
                SetNextButtonText("فهمیدم");
            }
            else
            {
                SetNextButtonText("بعدی");
            }
        }

        public ICommand NextCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }
    }
}
