﻿using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api.Profile;
using DesktopUI.Library.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class PhotosListViewModel : Screen, IHandle<MessageEvent>
    {
        private readonly IProfileEndpoint _profileEndpoint;
        private readonly IEventAggregator _events;
        private readonly IProfile _profile;
        private readonly IAuthenticatedUser _user;
        private string _username;
        private bool _isEditMode;

        public PhotosListViewModel(IProfileEndpoint profileEndpoint, IEventAggregator events, IProfile profile,
            IAuthenticatedUser user)
        {
            _profileEndpoint = profileEndpoint;
            _events = events;
            _profile = profile;
            _user = user;

            events.Subscribe(this);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            var username = _username ?? _profile.Username;
            var profile = await _profileEndpoint.LoadProfile(username);
            UserPhotos = new ObservableCollection<Photo>(profile.Photos);
        }

        private ObservableCollection<Photo> _userPhotos;

        public ObservableCollection<Photo> UserPhotos
        {
            get => _userPhotos;
            set
            {
                _userPhotos = value;
                NotifyOfPropertyChange(() => UserPhotos);
            }
        }

        private Photo _selectedPhoto;

        public Photo SelectedPhoto
        {
            get => _selectedPhoto;
            set
            {
                _selectedPhoto = value;
                NotifyOfPropertyChange(() => SelectedPhoto);
                NotifyOfPropertyChange(() => IsSelectedUser);
            }
        }

        public async Task SetMainPhoto()
        {
            await _profileEndpoint.SetMainPhoto(SelectedPhoto);

            _events.PublishOnUIThread(new MessageEvent());
        }

        public async Task DeletePhoto()
        {
            await _profileEndpoint.DeletePhoto(SelectedPhoto);

            if (SelectedPhoto.IsMain)
            {
                _profile.Image = null;
                _user.Image = null;
            }

            var updatePhotos = UserPhotos.Where(x => x.Id != SelectedPhoto.Id);
            UserPhotos = new ObservableCollection<Photo>(updatePhotos);
            NotifyOfPropertyChange(() => UserPhotos);

            _events.PublishOnUIThread(new MessageEvent());
        }

        public bool IsLogIn
        {
            get
            {
                var output = _user.Username == _profile.Username && _isEditMode;

                return output;
            }
        }

        private bool _isSelectedUser;

        public bool IsSelectedUser
        {
            get => _isSelectedUser = SelectedPhoto != null;
            set
            {
                _isSelectedUser = value;
                NotifyOfPropertyChange(() => IsSelectedUser);
            }
        }

        public void Handle(MessageEvent message)
        {
            _username = message.Username;
            _isEditMode = message.IsEditMode;
        }
    }
}