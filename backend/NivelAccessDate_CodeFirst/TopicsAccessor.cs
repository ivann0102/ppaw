using LibrarieModele;
using Microsoft.EntityFrameworkCore;
using Repository_CodeFirst;

namespace NiveAccessDate_CodeFirst;

public class TopicsAccessor : ITopicsAccessor
{
    private readonly ForumContext context;
    public TopicsAccessor(ForumContext context)
    {
        this.context = context;
    }
    public List<Topic> GetTopics()
    {
        return context.Topics.ToList();
    }
    public Topic? GetTopic(int id)
    {
        return context.Topics.FirstOrDefault(topic => topic.TopicId == id);
    }
    public void CreateTopic(Topic topic)
    {
        context.Topics.Add(topic);
        context.SaveChanges();
    }
    public void DeleteTopic(int id)
    {

    }
}