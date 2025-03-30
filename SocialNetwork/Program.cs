using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

class Program
{
    static MessageService messageService;
    static UserService userService;
    static FriendService friendService;
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticatationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendingView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutcomingMessageView userOutcomingMessageView;
    public static FriendAddView friendAddView;
    public static FriendListView friendListView;

    static void Main(string[] args)
    {
        userService = new UserService();
        messageService = new MessageService();
        friendService = new FriendService();

        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticatationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendingView = new MessageSendingView(messageService, userService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutcomingMessageView = new UserOutcomingMessageView();
        friendAddView = new FriendAddView(friendService);
        friendListView = new FriendListView(userService, friendService);

        while (true)
        {
            mainView.Show();
        }
    }
}