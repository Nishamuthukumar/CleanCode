public interface INotificationChannel
{
	//public Content content {get; set;}
	public void SendNotifications(string message);
	public string FormatContent(Content content);
}
 
--------------------------------------------------------------------------------
public class NotificationService
{
	public INotificationChannel notificationChannel;
	public Content content;
 
	NotificationService(INotificationChannel notificationChannel)
	{
		this.notificationChannel = notificationChannel;
	}
	string message = notificationChannel.FormatContent(content);
	notificationChannel.SendNotifications(message);
}
 
--------------------------------------------------------------------------------
 
public class Email : INotificationChannel
 
{
	public void SendNotifications(string message)
	{
	}
 
	public string FormatContent(Content content) 
	{
	}
}
 
--------------------------------------------------------------------------------
public class SMS : INotificationChannel
{
	public void SendNotifications(string message)
	{
	} 
	public string FormatContent(Content content) 
	{
	}
}
 
--------------------------------------------------------------------------------
 
public class PushNotification : INotificationChannel
{
	public void SendNotifications(string message)
	{
	} 
	public string FormatContent(Content content) 
	{
	}
}
 
--------------------------------------------------------------------------------
 
public interface IContent
{
    //contains attachment type and body of message
}
