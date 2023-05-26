using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.UIModels;

public class UIValidator
{
    public async Task<bool> IsValidateRoomUIParamsAsync(UiRoom uiRoom)
    {
        Task<bool> realNumber = IsValueInRange<ushort>(uiRoom.RealNumber, 0, ushort.MaxValue);
        Task<bool> bedsNumber = IsValueInRange<byte>(uiRoom.BedsNumber, 0, byte.MaxValue);
        Task<bool> pricePerDay = IsValueInRange<decimal>(uiRoom.PricePerDay, 0.0m, decimal.MaxValue);

        bool[] result = await Task.WhenAll(realNumber, bedsNumber, pricePerDay);

        return !result.Any(i => i.Equals(false));
    }

    /// <summary>
    /// Validate all params in UserUi. Using for register data validation
    /// </summary>
    /// <param name="uiUser">Object that save entered data on register/login window</param>
    /// <returns>Return true if all validations were successful</returns>
    public async Task<bool> IsValidAllUserUIParamsAsync(UiUser uiUser)
    {
        Task<bool> nameIsValid = ValidateEnteredStringSyntax(uiUser.Username, nameof(uiUser.Username));

        Task<bool> mainParamsIsValid = IsValidMainUserUIParamsAsync(uiUser);

        Task<bool> passwordConfirmParamsIsValid =
            ValidateEnteredStringSyntax(uiUser.PasswordConfirm, nameof(uiUser.PasswordConfirm));

        bool[] result = await Task.WhenAll(nameIsValid, mainParamsIsValid, passwordConfirmParamsIsValid);

        return !result.Any(i => i.Equals(false)) ||
               await ValidatePasswordsMatch(uiUser.Password, uiUser.PasswordConfirm);
    }

    /// <summary>
    /// Validate only IEN and password entered by user data.
    /// Using for login data validation
    /// </summary>
    /// <param name="uiUser">Object that save entered data on register/login window</param>
    /// <returns>Return true if all validations were successful</returns>
    public async Task<bool> IsValidMainUserUIParamsAsync(UiUser uiUser)
    {
        Task<bool> ienIsValid = ValidateEnteredIenSyntax(uiUser.IndividualEmployeeNumber);

        Task<bool> passwordParamsIsValid = ValidateEnteredStringSyntax(uiUser.Password, nameof(uiUser.Password));

        bool[] result = await Task.WhenAll(ienIsValid, passwordParamsIsValid);

        return !result.Any(i => i.Equals(false));
    }

    private async Task<bool> ValidateEnteredStringSyntax(string data, string paramName)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            MessageBox.Show("You must enter data in order to create a new object!", "Data error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        else if (data.Length < 3 || data.Length > 30)
        {
            return false;
        }
        else return true;
    }

    private async Task<bool> ValidateEnteredIenSyntax(string ien)
    {
        string pattern = @"^\d{3}-\d{3}-\d{3}$";

        if (!Regex.IsMatch(ien, pattern))
        {
            MessageBox.Show($"Individual employee number must have style pattern: \"000-000-000\"", "Data style error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }

    private async Task<bool> ValidatePasswordsMatch(string password1, string password2)
    {
        if (!string.Equals(password1, password2))
        {
            MessageBox.Show($"Entered passwords are not match", "Data error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }

    private async Task<bool> IsValueInRange<T>(T value, T minValue, T maxValue) where T : IComparable<T>
    {
        return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
    }
}