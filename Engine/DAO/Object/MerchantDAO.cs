using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.DAO.Domain;
using log4net;

namespace Engine.DAO.Object
{
    public class MerchantDAO : IMerchantDAO
    {
        //TODO: Need to get log4net up
        public static readonly ILog _log = LogManager.GetLogger(typeof(ManufacturerDAO));
        public ManufacturerDAO(string connectionString): base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Question> UpdateManufacturer()
        {

            List<Question> surveyQuestions = null;
            _log.DebugFormat(@"GetSurveyQuestions: SurveyTypeID={0}", surveyTypeID);
            try
            {
                surveyQuestions = new List<Question>();
                SqlParameter[] parameters = {CreateParameter("@SurveyTypeID", SqlDbType.Int, surveyTypeID)};
                SqlDataReader dataReader = ExecuteProcedure("dbo.GetSurveyQuestions", parameters);

                while (dataReader.Read())
                {
                    Question question = new Question();
                    question.QuestionID = SafeConvert.ToInt32(dataReader["QuestionID"], 0);
                    question.SurveyQuestionID = SafeConvert.ToInt32(dataReader["id"], 0);
                    question.QuestionDescription = SafeConvert.ToString(dataReader["question"], "");
                    question.QuestionOrder = SafeConvert.ToInt32(dataReader["question_order"], 0);
                    question.ResponseTypeID = SafeConvert.ToInt32(dataReader["response_type_id"], 0);
                    question.Tags = SafeConvert.ToString(dataReader["tags"], "");
                    question.Valid = SafeConvert.ToBoolean(dataReader["is_valid"], false);
                    question.HasComment = SafeConvert.ToBoolean(dataReader["has_comment"], false);
                    question.Hidden = SafeConvert.ToBoolean(dataReader["hidden"], false);
                    surveyQuestions.Add(question);
                }
                dataReader.Close();
            }
            catch (SqlException ex)
            {   
                _log.ErrorFormat("GetSurveyQuestions: SQL Exception=\n{0}", ex.Message);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("GetSurveyQuestions: Exception=\n{0}", ex.Message);
            }
            return surveyQuestions;
        }
    }
}
