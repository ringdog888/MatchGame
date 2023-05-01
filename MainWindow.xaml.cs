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

namespace MatchGame
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
    }
}
