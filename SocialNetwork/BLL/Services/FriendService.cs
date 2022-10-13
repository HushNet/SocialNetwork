using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class FriendService
{
    private IUserRepository _userRepository;
    private IFriendRepository _friendRepository;

    public FriendService()
    {
        _userRepository = new UserRepository();
        _friendRepository = new FriendRepository();
    }

    public void AddFriend(AddingFriendData addingFriendData)
    {
        var userEntity = _userRepository.FindByEmail(addingFriendData.friendEmail);
        if (userEntity is null) throw new UserNotFoundException();
        
        
        FriendEntity friendEntity = new FriendEntity()
        {
            user_id = addingFriendData.senderId,
            friend_id = addingFriendData.friendId
        };

        if (_friendRepository.Create(friendEntity) == 0)
            throw new ArgumentNullException();
    }
}