using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Get.the.solution.Image.Manipulation.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ResizeImage.Views
{
    public class ProgressBarDialogWindow : Window, IProgressBarDialogService
    {
        public ProgressBarDialogWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private String _CurrentItem;
        public String CurrentItem
        {
            get { return _CurrentItem; }
            set { SetProperty(ref _CurrentItem, value, nameof(CurrentItem)); }
        }

        private String _ItemState;
        public String ItemState
        {
            get { return _ItemState; }
            set { SetProperty(ref _ItemState, value, nameof(ItemState)); }
        }


        private int _AmountItems;
        public int AmountItems
        {
            get { return _AmountItems; }
            set { SetProperty(ref _AmountItems, value, nameof(AmountItems)); }
        }

        private int _ProcessedItems;
        public int ProcessedItems
        {
            get { return _ProcessedItems; }
            set
            {
                SetProperty(ref _ProcessedItems, value, nameof(ProcessedItems));
                ItemState = $"{ProcessedItems}/{AmountItems}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public IProgressBarDialogService ProgressBarDialogFactory()
        {
            return new ProgressBarDialogWindow();
        }

        public Task StartAsync(int amountItems)
        {
            AmountItems = amountItems;
            this.Show();
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }

        public void Stop()
        {
            Close();
        }
    
}
}
