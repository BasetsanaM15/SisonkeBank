using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SisonkeBank.Data;
using SisonkeBank.Models;

namespace SisonkeBank.Pages;

public partial class TransferFundsPage : ContentPage
{
    private readonly DatabaseHelper _databaseHelper;

    // ✅ Constructor now accepts DatabaseHelper from the MainPage
    public TransferFundsPage(DatabaseHelper dbHelper)
    {
        InitializeComponent();
        _databaseHelper = dbHelper;
    }

    private async void OnTransferClicked(object sender, EventArgs e)
    {
        string recipientEmail = recipientEntry.Text;
        bool isValidAmount = decimal.TryParse(amountEntry.Text, out decimal amount);

        if (string.IsNullOrWhiteSpace(recipientEmail) || !isValidAmount || amount <= 0)
        {
            messageLabel.Text = "Please enter valid details.";
            messageLabel.IsVisible = true;
            return;
        }

        var recipient = await _databaseHelper.GetUserByEmailAsync(recipientEmail);
        var senderUser = App.LoggedInUser;

        if (recipient == null)
        {
            messageLabel.Text = "Recipient not found.";
            messageLabel.IsVisible = true;
            return;
        }

        if (senderUser == null || senderUser.Balance < amount)
        {
            messageLabel.Text = "Insufficient funds or not logged in.";
            messageLabel.IsVisible = true;
            return;
        }

        // ✅ Transfer funds
        senderUser.Balance -= amount;
        recipient.Balance += amount;

        await _databaseHelper.UpdateUserAsync(senderUser);
        await _databaseHelper.UpdateUserAsync(recipient);

        messageLabel.TextColor = Colors.Green;
        messageLabel.Text = "Transfer successful!";
        messageLabel.IsVisible = true;
    }
}
