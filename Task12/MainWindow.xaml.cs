using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Task12
{
    public partial class MainWindow : Window
    {
        List<UserWrapper>? userList;
        User _currentUser = new Consult();

        private ObservableCollection<ClientView> _clientViewList = new ObservableCollection<ClientView>();
        private ClientView? _editedObject;

        private bool _isAdd => this._editedObject?.Id == 0;

        public MainWindow()
        {
            this.InitializeComponent();

            this.LoadUserList();
            this.RefreshData();
        }

        /// <summary>
        /// Загрузка списка типов пользователей
        /// </summary>
        private void LoadUserList()
        {
            this.userList = new List<UserWrapper>
            {
                new UserWrapper(new Consult(), "Консультант"),
                new UserWrapper(new Manager(), "Менеджер")
            };

            this.userComboBox.ItemsSource = this.userList;
            this.userComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновление данных в списке клиентов
        /// </summary>
        private void RefreshData()
        {
            var previousSelectedClient = this.clientsListBox.SelectedItem as ClientView;
            var clientsViews = DataManager.GetClients().Select(o => new ClientView(o));
            this._clientViewList = new ObservableCollection<ClientView>(clientsViews);
            this.clientsListBox.ItemsSource = this._clientViewList;

            this.ModifyClientViewList(this._currentUser);

            if (this._isAdd)
                this.SetNewItemSelected();
            else
                this.RestorePreviousSelectedItem(previousSelectedClient);
        }

        /// <summary>
        /// Внесение изменений в список представлений Клиента в зависимости от текущего типа пользователя
        /// </summary>
        private void ModifyClientViewList(IShowClientViewRules viewRules)
        {
            foreach (var view in this._clientViewList)
                viewRules.ModifyClientView(view);
        }

        /// <summary>
        /// Выставить выбранным последний элемент в списке
        /// </summary>
        private void SetNewItemSelected()
        {
            var view = this._clientViewList.LastOrDefault();
            this.clientsListBox.SelectedItem = view;
            this.RefreshDataContext(view);
        }

        /// <summary>
        /// Выставление выбранного элемента в списке обратно как было до перезагрузки списка
        /// </summary>
        private void RestorePreviousSelectedItem(ClientView? previousView)
        {
            ClientView? view = null;

            if (previousView is not null)
                view = this._clientViewList.FirstOrDefault(o => o.Id == previousView.Id);
            else if (this._clientViewList.Any())
                view = this._clientViewList[0];

            this.clientsListBox.SelectedItem = view;
            this.RefreshDataContext(view);
        }

        /// <summary>
        /// Обновление редактируемой модели согласно выбранному представлению в списке
        /// </summary>
        private void RefreshDataContext(ClientView? view)
        {
            if (view is null)
                this._editedObject = new ClientView();
            else
                this._editedObject = new ClientView(view);

            this.DataContext = this._editedObject;

            this.RefreshButtonVisible();
        }

        /// <summary>
        /// Смена активного типа пользователя
        /// </summary>
        private void ChangeUser(User user)
        {
            this._currentUser = user;

            this.SetupUI(user);
            this.RefreshData();
        }

        /// <summary>
        /// Настройка полей в UI согласно доступам которое имеет текущий тип пользователя
        /// </summary>
        private void SetupUI(IDataPermission dataPermission)
        {
            var permission = dataPermission.GetPermission();

            this.SetUISettingForFullNameFields(permission.FullName);
            this.SetUISettingForPhoneFields(permission.Phone);
            this.SetUISettingForPassportFields(permission.Passport);
        }

        /// <summary>
        /// Настройка полей ФИО
        /// </summary>
        private void SetUISettingForPassportFields(PermissionEnum permissionEnum)
        {
            switch (permissionEnum)
            {
                case PermissionEnum.FullAllow:
                    this.passSerialTextBox.IsReadOnly = false;
                    this.passNumTextBox.IsReadOnly = false;
                    this.passSerialTextBox.Visibility = Visibility.Visible;
                    this.passNumTextBox.Visibility = Visibility.Visible;
                    return;

                case PermissionEnum.ReadOnly:
                    this.passSerialTextBox.IsReadOnly = true;
                    this.passNumTextBox.IsReadOnly = true;
                    this.passSerialTextBox.Visibility = Visibility.Visible;
                    this.passNumTextBox.Visibility = Visibility.Visible;
                    break;

                case PermissionEnum.Hide:
                    this.passSerialTextBox.Visibility = Visibility.Hidden;
                    this.passNumTextBox.Visibility = Visibility.Hidden;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Настройка полей Телефон
        /// </summary>
        private void SetUISettingForPhoneFields(PermissionEnum permissionEnum)
        {
            switch (permissionEnum)
            {
                case PermissionEnum.FullAllow:
                    this.phoneTextBox.IsReadOnly = false;
                    this.phoneTextBox.Visibility = Visibility.Visible;
                    break;

                case PermissionEnum.ReadOnly:
                    this.phoneTextBox.IsReadOnly = true;
                    this.phoneTextBox.Visibility = Visibility.Visible;
                    break;

                case PermissionEnum.Hide:
                    this.phoneTextBox.Visibility = Visibility.Hidden;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Настройка полей Паспорт
        /// </summary>
        private void SetUISettingForFullNameFields(PermissionEnum permissionEnum)
        {
            switch (permissionEnum)
            {
                case PermissionEnum.FullAllow:
                    this.firstNameTextBox.IsReadOnly = false;
                    this.secondNameTextBox.IsReadOnly = false;
                    this.lastNameTextBox.IsReadOnly = false;
                    this.firstNameTextBox.Visibility = Visibility.Visible;
                    this.secondNameTextBox.Visibility = Visibility.Visible;
                    this.lastNameTextBox.Visibility = Visibility.Visible;
                    return;

                case PermissionEnum.ReadOnly:
                    this.firstNameTextBox.IsReadOnly = true;
                    this.secondNameTextBox.IsReadOnly = true;
                    this.lastNameTextBox.IsReadOnly = true;
                    this.firstNameTextBox.Visibility = Visibility.Visible;
                    this.secondNameTextBox.Visibility = Visibility.Visible;
                    this.lastNameTextBox.Visibility = Visibility.Visible;
                    break;

                case PermissionEnum.Hide:
                    this.firstNameTextBox.Visibility = Visibility.Hidden;
                    this.secondNameTextBox.Visibility = Visibility.Hidden;
                    this.lastNameTextBox.Visibility = Visibility.Hidden;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Выставить видимость кнопок в зависимости от состояния формы(добавление или редактирование)
        /// </summary>
        private void RefreshButtonVisible()
        {
            if (!this._currentUser.IsCanAddData() || this._isAdd)
            {
                this.addDataBtn.Visibility = Visibility.Hidden;
                this.deleteDataBtn.Visibility = Visibility.Hidden;
                return;
            }

            this.addDataBtn.Visibility = Visibility.Visible;
            this.deleteDataBtn.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Нажатие на кнопку сохранения UI
        /// </summary>
        private void saveDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsValidateAll())
                return;

            var editedView = this.DataContext as ClientView;
            if (editedView is null)
                return;

            if (this._isAdd)
            {
                DataManager.AddClient(new Client(editedView));
                this.RefreshData();
                return;
            }

            var clientList = DataManager.GetClients();
            var clientDataModel = clientList.FirstOrDefault(o => o.Id == editedView.Id);

            if (clientDataModel is null)
                return;

            if (!DataManager.IsHaveChange(this._currentUser, clientDataModel, editedView, out var changedFieldString))
                return;

            clientDataModel.DataFieldChanged = changedFieldString;

            this.ModifyClientData(this._currentUser, clientDataModel, editedView);

            DataManager.SaveClients(clientList);
            this.RefreshData();
        }

        /// <summary>
        /// Проверка введенных данных
        /// </summary>
        private bool IsValidateAll()
        {
            if (this.IsValid("FirstName") &&
                this.IsValid("SecondName") &&
                this.IsValid("LastName") &&
                this.IsValid("Phone") &&
                this.IsValid("PassSerial") &&
                this.IsValid("PassNum"))
                return true;

            return false;
        }

        /// <summary>
        /// Проверка конкретного поля на правильность заполнения
        /// </summary>
        private bool IsValid(string path)
        {
            var errorMessage = ((IDataErrorInfo)this.DataContext)[path];
            return string.IsNullOrEmpty(errorMessage);
        }

        /// <summary>
        /// Внесение изменений в модель данных из представления согласно описанию процесса для конкретного пользователя
        /// </summary>
        private void ModifyClientData(ISaveClientDataRules saveRules, Client obj, ClientView view)
        {
            saveRules.ModifyClientData(obj, view);
        }

        /// <summary>
        /// Выбор элемента в UI списке представлений Клиентов
        /// </summary>
        private void clientsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var view = this.clientsListBox.SelectedItem as ClientView;
            if (view is null)
                return;

            this.RefreshDataContext(view);
        }

        /// <summary>
        /// Смена типа пользователя в выпадающем списке UI
        /// </summary>
        private void userComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUserWrapper = this.userComboBox.SelectedItem as UserWrapper;
            if (selectedUserWrapper is null)
                return;

            this.ChangeUser(selectedUserWrapper.User);
        }

        private void deleteDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!this._currentUser.IsCanAddData())
                return;

            if (this._editedObject is null || this._editedObject.Id == 0)
                return;

            var result = MessageBox.Show("Действительно удалить запись?", "Внимание", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                DataManager.DeleteClient(this._editedObject.Id);

            this.clientsListBox.SelectedIndex = 0;
            this.RefreshData();

        }

        private void addDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!this._currentUser.IsCanAddData())
                return;

            this.RefreshDataContext(new ClientView());
        }
    }
}
