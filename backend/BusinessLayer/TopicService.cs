using NiveAccessDate_CodeFirst;
using LibrarieModele;
using System.Text.RegularExpressions;


namespace BusinessLayer;

public class TopicService : ITopicService
{
    private readonly ITopicsAccessor topicsAccessor;
    private readonly IUserService userService;
    private readonly ICache cacheManager;
    public TopicService(ITopicsAccessor topicsAccessor, IUserService userService, ICache cacheManager)
    {
        this.topicsAccessor = topicsAccessor;
        this.userService = userService;
        this.cacheManager = cacheManager;
    }

    public int Create(int userId, Topic topic)
    {
        string userRole = userService.GetUserRole(userId);
        if (userRole != "admin")
            return 0;

        topicsAccessor.CreateTopic(topic);
        return 1;
    }

    public int Delete(int userId, int topicId)
    {
        string userRole = userService.GetUserRole(userId);
        if (userRole != "admin")
            return 0;

        topicsAccessor.DeleteTopic(topicId);
        var key = "topic" + $"_{topicId}";
        cacheManager.Remove(key);

        return 1;
    }

    public List<Topic> GetAll()
    {
        List<Topic> topics;
        var key = "topic" + $"_all";
        if (cacheManager.IsSet(key))
        {
            topics = cacheManager.Get<List<Topic>>(key)!;
        }
        else
        {
            topics = topicsAccessor.GetTopics();
            cacheManager.Set(key, topics);
        }

        return topics;
    }

    public Topic? Get(int id)
    {
        Topic? topic;

        var key = "topic" + $"_{id}";
        if (cacheManager.IsSet(key))
        {
            topic = cacheManager.Get<Topic>(key)!;
        }
        else
        {
            topic = topicsAccessor.GetTopic(id);
            if (topic != null)
                cacheManager.Set(key, topic);
        }

        return topic;
    }

}