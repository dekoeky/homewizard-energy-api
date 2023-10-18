using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace LiveWidget.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TimeSpan historyLenght = TimeSpan.FromMinutes(1);
        private readonly TimeSpan sinusPeriod = TimeSpan.FromSeconds(10);
        private readonly TimeSpan samplePeriod = TimeSpan.FromSeconds(1);

        Dictionary<DateTime, double> values;

        public double[] data = new double[100_000];




        private DispatcherTimer _updateDataTimer;
        private DispatcherTimer _renderTimer;


        public MainWindow()
        {
            InitializeComponent();


        }

    }
}
