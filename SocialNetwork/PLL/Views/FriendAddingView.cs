using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class FriendAddingView
{
    private FriendService _friendService;

    public FriendAddingView(FriendService friendService)
    {
        _friendService = friendService;
    }
    public void Show(User user)
    {
        var addingFriendData = new AddingFriendData();
        Console.WriteLine("Введите почтовый адрес друга:");

        addingFriendData.friendEmail = Console.ReadLine();
        addingFriendData.senderId = user.Id;

        try
        {
            _friendService.AddFriend(addingFriendData);
            SuccessMessage.Show("Друг успешно добавлен!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }

        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }

        catch (Exception ex)
        {
            AlertMessage.Show("Произошла ошибка при добавлении друга!");
            Console.WriteLine(ex);


        }
    }
}