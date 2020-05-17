using Avalonia;
using Avalonia.Controls;
using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Service
{
    public class PageDialogService : IPageDialogService
    {
        public Task ShowAsync(string content)
        {
            Window window = new Window();

            StackPanel stackPanel = new StackPanel();
            
            TextBlock textBlock = new TextBlock();
            textBlock.Text = content;

            Button buttonOk = new Button();
            buttonOk.Content = "Ok";
            buttonOk.Click += (sender, e) => window.Close();

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(buttonOk);

            window.Content = stackPanel;


            Application.Current.MainWindow.ShowDialog(window);

            return Task.CompletedTask;
        }

        public Task<bool> ShowConfirmationAsync(string content, string yesButton, string noButton)
        {
            throw new NotImplementedException();
        }
    }
}
