using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using StackOverFlowProject.DomainModel;

namespace StackOverflow.Repositories
{
    public interface IQuestionRepository
    {
        void InsertQuestion(Question q);
        void UpdateQuestionDetails(Question q);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
        void DeleteQuestion(int qid);
        List<Question> GetQuestions();
        List<Question> GetQuestionByQuestionID(int QuestionID);
    }
    public class QuestionsRepository : IQuestionRepository
    {
        StackOverflowDataDbContext stackOverflowDataDb;
        public QuestionsRepository()
        {
            stackOverflowDataDb = new StackOverflowDataDbContext();
        }
        public void DeleteQuestion(int qid)
        {
            Question qt = stackOverflowDataDb.Quetions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            stackOverflowDataDb.Quetions.Remove(qt);
            stackOverflowDataDb.SaveChanges();
        }

        public List<Question> GetQuestionByQuestionID(int QuestionID)
        {
            List<Question> result =stackOverflowDataDb.Quetions.Where(temp=>temp.QuestionID==QuestionID).ToList();
            return result;
        }

        public List<Question> GetQuestions()
        {
            List<Question> quetions = stackOverflowDataDb.Quetions.ToList();
            return quetions;
        }

        public void InsertQuestion(Question q)
        {
            stackOverflowDataDb.Quetions.Add(q);
            stackOverflowDataDb.SaveChanges();
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            Question quetion = stackOverflowDataDb.Quetions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (quetion != null)
            {
                quetion.AnswersCount = value;
                stackOverflowDataDb.SaveChanges();  
            }
        }

        public void UpdateQuestionDetails(Question q)
        {
            Question quetion = stackOverflowDataDb.Quetions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (quetion != null)
            {
                quetion.AnswersCount = q.AnswersCount;
                quetion.QuestionName = q.QuestionName;
                quetion.CategoryID = q.CategoryID;
                stackOverflowDataDb.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            Question quetion = stackOverflowDataDb.Quetions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (quetion != null)
            {
                quetion.ViewsCount = value;
                stackOverflowDataDb.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            Question quetion = stackOverflowDataDb.Quetions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (quetion != null)
            {
                quetion.VotesCount = value;
                stackOverflowDataDb.SaveChanges();
            }
        }
    }
}
