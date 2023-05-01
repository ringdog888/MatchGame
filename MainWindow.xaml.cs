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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace MatchGame
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElaspsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElaspsed++;
            timeTextBlock.Text = (tenthOfSecondsElaspsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐻", "🐻",
                "🐮", "🐮",
                "🦁", "🦁",
                "🦔", "🦔",
                "🦉", "🦉",
                "🐨", "🐨",
                "🐧", "🐧",
                "🐶", "🐶",
            };
            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);  //這個程式碼的目的是從 animalEmoji 中隨機選擇一個表情符號，並將其索引儲存在名為 index 的整數變數中。
                string nextEmoji = animalEmoji[index]; //這段程式碼將 animalEmoji 列表中索引為 index 的元素儲存在名為 nextEmoji 的字串變數中。
                textBlock.Text = nextEmoji; //然後，這段程式碼將 textBlock 控制項的 Text 屬性設定為 nextEmoji，這樣就可以將隨機選擇的動物表情符號顯示在應用程式的使用者介面中。
                animalEmoji.RemoveAt(index); //這段程式碼使用 RemoveAt 方法從 animalEmoji 列表中移除索引為 index 的元素，以防止同一個表情符號在未來的選擇中再次出現。
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked= textBlock;
                findingMatch = true;
            }else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility= Visibility.Hidden;
                findingMatch= false;
            }else
            {
                lastTextBlockClicked.Visibility= Visibility.Visible;
                findingMatch= false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}

////這段程式碼定義了一個名為 TextBlock_MouseDown 的事件處理程序，當使用者按下一個 TextBlock 控制項時，就會執行這個事件處理程序。

//在事件處理程序中，首先將 sender 變數轉換為 TextBlock 類型的 textBlock 變數。sender 變數代表引發事件的對象，因此在這裡就是被點擊的 TextBlock 控制項。

//接著，如果目前沒有在尋找匹配（findingMatch 為 false），則將 textBlock 的可見性設為隱藏（Visibility.Hidden），表示這個控制項已經被選擇了。同時，將 lastTextBlockClicked 變數設定為 textBlock，以儲存上一個被選擇的 TextBlock 控制項。最後，將 findingMatch 設定為 true，表示目前正在尋找匹配。

//如果目前正在尋找匹配且被點擊的 TextBlock 控制項的文字與上一個被點擊的 TextBlock 控制項的文字相同，則將該控制項的可見性設定為隱藏，表示這兩個控制項已經匹配成功，找到了一對。同時，將 findingMatch 設定為 false，表示已經找到一對匹配的控制項。

//如果目前正在尋找匹配但是被點擊的 TextBlock 控制項的文字與上一個被點擊的 TextBlock 控制項的文字不同，則將上一個被點擊的 TextBlock 控制項的可見性設定為可見（Visibility.Visible），表示上一個被選擇的 TextBlock 控制項需要重新顯示。同時，將 findingMatch 設定為 false，表示目前沒有找到匹配的控制項。

//總的來說，這段程式碼的作用是在一個文字匹配遊戲中處理 TextBlock 控制項的點擊事件，當兩個 TextBlock 控制項的文字相同時，將它們從畫面中隱藏，否則重新顯示上一個被選擇的 TextBlock 控制項。
