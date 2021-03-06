﻿using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using DesktopUI.EventModels;

namespace DesktopUI.Views.Photos
{
    /// <summary>
    /// Interaction logic for PhotosListView.xaml
    /// </summary>
    public partial class PhotosListView : UserControl
    {
        public PhotosListView()
        {
            InitializeComponent();

            _events = IoC.Get<IEventAggregator>();
        }

        private readonly IEventAggregator _events;

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                if (e.VerticalOffset + e.ViewportHeight == e.ExtentHeight)
                {
                    Task.Run(() => _events.PublishOnUIThreadAsync(new MessageEvent {HandleGetNextPhotos = true}, new CancellationToken()));
                }
            }
        }
    }
}
