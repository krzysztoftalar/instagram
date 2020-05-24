﻿using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api.User;
using DesktopUI.Library.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IUserEndpoint _userEndpoint;
        private readonly IEventAggregator _events;

        public LoginViewModel(IUserEndpoint userEndpoint, IEventAggregator events)
        {
            _userEndpoint = userEndpoint;
            _events = events;
        }

        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin => Email?.Length > 0 && Password?.Length > 0;

        public bool IsErrorVisible => ErrorMessage?.Length > 0;


        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public async Task LoginAsync()
        {
            var user = new UserFormValues
            {
                Email = Email,
                Password = Password
            };

            try
            {
                ErrorMessage = "";

                var authUser = await _userEndpoint.LoginAsync(user);

                await _userEndpoint.CurrentUserAsync(authUser.Token);

                await _events.PublishOnUIThreadAsync(Navigation.Main, new CancellationToken());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public async Task GoToRegisterAsync()
        {
            await _events.PublishOnUIThreadAsync(Navigation.Register, new CancellationToken());
        }
    }
}