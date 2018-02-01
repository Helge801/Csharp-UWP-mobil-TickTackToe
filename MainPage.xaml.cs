using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TickTackToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ComputerGo()
        {
            if(CanWin("O") != null)
            {
                GetSpaceFromWin(CanWin("O")).Content = "O";
            }
            else if (CanWin("X") != null)
            {
                GetSpaceFromWin(CanWin("X")).Content = "O";
            }
            else
            {
                GetRandomButton().Content = "O";
            }


        }

        private Button GetSpaceFromWin(List<Button> buttons)
        {
            foreach(Button b in buttons)
            {
                if(b.Content == null)
                {
                    return b;
                }
            }
            return null;
        }

        private List<Button> CanWin(string mark)
        {
            foreach(List<Button> l in WinMethods())
            {
                int score = 0;
                int fill = 0;
                foreach(Button b in l)
                {
                    if(b.Content != null)
                    {
                        fill++;
                        if (b.Content.ToString() == mark)
                        {
                            score++;
                        }
                    }
                }
                if(score == 2 && fill ==2)
                {
                    return l;
                }
            }
            return null;
        }

        private List<List<Button>> WinMethods()
        {
            List<Button> top = new List<Button>();
            top.Add(grid_one);
            top.Add(grid_two);
            top.Add(grid_three);
            List<Button> middle = new List<Button>();
            middle.Add(grid_four);
            middle.Add(grid_five);
            middle.Add(grid_six);
            List<Button> bottom = new List<Button>();
            bottom.Add(grid_seven);
            bottom.Add(grid_eight);
            bottom.Add(grid_nine);
            List<Button> left = new List<Button>();
            left.Add(grid_one);
            left.Add(grid_four);
            left.Add(grid_seven);
            List<Button> center = new List<Button>();
            center.Add(grid_two);
            center.Add(grid_five);
            center.Add(grid_eight);
            List<Button> right = new List<Button>();
            right.Add(grid_three);
            right.Add(grid_six);
            right.Add(grid_nine);
            List<Button> backslash = new List<Button>();
            backslash.Add(grid_one);
            backslash.Add(grid_five);
            backslash.Add(grid_nine);
            List<Button> forwardslash = new List<Button>();
            forwardslash.Add(grid_three);
            forwardslash.Add(grid_five);
            forwardslash.Add(grid_seven);
            List<List<Button>> win = new List<List<Button>>();
            win.Add(top);
            win.Add(middle);
            win.Add(bottom);
            win.Add(left);
            win.Add(center);
            win.Add(right);
            win.Add(backslash);
            win.Add(forwardslash);
            return win;
        }

        private List<Button> GetOpenSpaces()
        {
            List<Button> openButtens = new List<Button>();
            foreach(Button b in GetButtons())
            {
                if (b.Content == null) {
                    openButtens.Add(b);
                }
            }
            return openButtens;
        }

        private List<Button> GetPlayerSpaces()
        {
            List<Button> openButtens = new List<Button>();
            foreach (Button b in GetButtons())
            {
                if (b.Content != null && b.Content.ToString() == "X")
                {
                    openButtens.Add(b);
                }
            }
            return openButtens;
        }

        private void ComputerFisrtPick()
        {
            GetRandomButton().Content = "O";
        }

        private void ClearAll()
        {
            foreach(Button b in GetButtons())
            {
                b.Content = null;
            }
        }

        private List<Button> GetButtons()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(grid_one);
            buttons.Add(grid_two);
            buttons.Add(grid_three);
            buttons.Add(grid_four);
            buttons.Add(grid_five);
            buttons.Add(grid_six);
            buttons.Add(grid_seven);
            buttons.Add(grid_eight);
            buttons.Add(grid_nine);
            return buttons;
        }

        private Button GetRandomButton()
        {
            List<Button> buttons = GetOpenSpaces();
            Random rnd = new Random();
            int r = rnd.Next(buttons.Count);
            return buttons[r];
        }

        private string WinQ()
        {
            string winner = "none";

            if (grid_one.Content != null && grid_two.Content != null && grid_three.Content != null)
            {
                if (grid_one.Content.ToString() == grid_two.Content.ToString() && grid_one.Content.ToString() == grid_three.Content.ToString())
                {
                    winner = grid_one.Content.ToString();
                }
            }

            if (grid_one.Content != null && grid_four.Content != null && grid_seven.Content != null)
            {
                if (grid_one.Content.ToString() == grid_four.Content.ToString() && grid_one.Content.ToString() == grid_seven.Content.ToString())
                {
                    winner = grid_one.Content.ToString();
                }
            }

            if (grid_one.Content != null && grid_five.Content != null && grid_nine.Content != null)
            {
                if (grid_one.Content.ToString() == grid_five.Content.ToString() && grid_one.Content.ToString() == grid_nine.Content.ToString())
                {
                    winner = grid_one.Content.ToString();
                }
            }

            if (grid_four.Content != null && grid_five.Content != null && grid_six.Content != null)
            {
                if (grid_four.Content.ToString() == grid_five.Content.ToString() && grid_four.Content.ToString() == grid_six.Content.ToString())
                {
                    winner = grid_four.Content.ToString();
                }
            }

            if (grid_seven.Content != null && grid_eight.Content != null && grid_nine.Content != null)
            {
                if (grid_seven.Content.ToString() == grid_eight.Content.ToString() && grid_seven.Content.ToString() == grid_nine.Content.ToString())
                {
                    winner = grid_seven.Content.ToString();
                }
            }

            if (grid_seven.Content != null && grid_five.Content != null && grid_three.Content != null)
            {
                if (grid_seven.Content.ToString() == grid_five.Content.ToString() && grid_seven.Content.ToString() == grid_three.Content.ToString())
                {
                    winner = grid_seven.Content.ToString();
                }
            }

            if (grid_two.Content != null && grid_five.Content != null && grid_eight.Content != null)
            {
                if (grid_two.Content.ToString() == grid_five.Content.ToString() && grid_two.Content.ToString() == grid_eight.Content.ToString())
                {
                    winner = grid_two.Content.ToString();
                }
            }

            if (grid_three.Content != null && grid_six.Content != null && grid_nine.Content != null)
            {
                if (grid_three.Content.ToString() == grid_six.Content.ToString() && grid_three.Content.ToString() == grid_nine.Content.ToString())
                {
                    winner = grid_three.Content.ToString();
                }
            }
            return winner;
        }

        private bool BoardFull()
        {
            foreach(Button b in GetButtons())
            {
                if(b.Content == null)
                {
                    return false;
                }
            }
            return true;
        }

        private void grid_button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == null)
            {
                ((Button)sender).Content = "X";
                string winner = WinQ();
                if (winner != "none")
                {
                    PopUp(WinQ());
                    ClearAll();
                }
                else
                {
                    if (BoardFull())
                    {
                        PopUp("Nobody");
                        ClearAll();
                    }
                    else
                    {
                        ComputerGo();
                        winner = WinQ();
                        if (winner != "none")
                        {
                            PopUp(WinQ());
                            ClearAll();
                        }
                    }
                }
            }
        }

        private async void PopUp(string winner)
        {
            var dialog = new MessageDialog("The winner is " + winner);
            await dialog.ShowAsync();
        }
    }
}
