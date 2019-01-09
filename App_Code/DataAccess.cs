using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    public DataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    static string getConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ProJectCSharp"].ToString();
    }
    public int updateClassAttend(string user,string sub1,string sub2,string teacher)
    {
        string sql = "update [ClassAttendence] set [SubjectCode]='" + sub2 + "',[TeacherCode]='" + teacher + "'" +
            " where [SubjectCode]='" + sub1 + "' and [StudentCode]='" + user + "';";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();

        return command.ExecuteNonQuery();
    }
    public int deletefromClassAttendence(string user,string Class)
    {
        string sql = "delete  from [ClassAttendence] where [StudentCode] = '" + user + "' and [SubjectCode] ='"+Class+"';";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();

        return command.ExecuteNonQuery();
    }
    public int inserttorequeststudent(string type,string code,string msg)
    {
        string sql = "insert into [RequestOfStudent] values(@a,@b,@c)";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
        SqlParameter param1 = new SqlParameter("@a", SqlDbType.VarChar);
        param1.Value = type;
        command.Parameters.Add(param1);
        param1 = new SqlParameter("@b", SqlDbType.VarChar);
        param1.Value = code;
        command.Parameters.Add(param1);
        param1 = new SqlParameter("@c", SqlDbType.VarChar);
        param1.Value = msg;
        command.Parameters.Add(param1);
        return command.ExecuteNonQuery();
    }
    public int updaterecord(string user,string col)
    {
        string sql = "update StudentRecord set " + col +" ='Learning';";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
        return command.ExecuteNonQuery();
    }
    public int inserttoclassattendence(string subject,string teacher, string student)
    {
        string sql = "insert into [ClassAttendence] values('" + subject + "','" + teacher + "','" + student+"',";
        for(int i = 1; i <= 30; i++)
        {
            sql += "'Not yet',";
        }
        for(int i = 1; i <= 6; i++)
        {
            if(i<6)
            sql += "'0',";
            else
            {
                sql += "'0')";
            }
        }
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
        return command.ExecuteNonQuery();
    }
    
    public int inserttotresponse(string code,string msg)
    {
        string sql = "insert into Response values(@a,@b)";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
        SqlParameter param1 = new SqlParameter("@a", SqlDbType.VarChar);
        param1.Value = code;
        command.Parameters.Add(param1);
        param1 = new SqlParameter("@b", SqlDbType.VarChar);
        param1.Value = msg;
        command.Parameters.Add(param1);
        return command.ExecuteNonQuery();
    }
    public int deletetrequest(string code)
    {
        string sql = "delete  from RequestOfTeacher where Teachercode = '"+code+"';";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
       
        return command.ExecuteNonQuery();
    }
    public int deletetresponse(string code)
    {
        string sql = "delete  from response where code = '" + code + "';";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();

        return command.ExecuteNonQuery();
    }
    public int insertToTeacherRequest(string code,string msg)
    {
        string sql = "insert into requestofteacher values(@a,@b)";
        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect); 
        connect.Open();
        SqlParameter param1 = new SqlParameter("@a", SqlDbType.VarChar);
        param1.Value = code;
        command.Parameters.Add(param1);
        param1 = new SqlParameter("@b", SqlDbType.VarChar);
        param1.Value = msg;
        command.Parameters.Add(param1);
       return command.ExecuteNonQuery();
    }
    public DataTable getDataByQuery(string sql)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adapt = new SqlDataAdapter(sql, getConnectionString());
        adapt.Fill(ds);
        return ds.Tables[0];
    }
    // return list of account to login for student
    public DataTable getAccountForStudent()
    {
        string sql = "select studentcode,password from [StudentInfo]";
        return getDataByQuery(sql);
    }
    public DataTable getTimetableofOneStudent(string code)
    {
        string sql = "SELECT TOP 1000 t1.[SubjectCode],t1.[StudentCode],t2.Room,t2.Slot FROM[ProJectCSharp].[dbo].[ClassAttendence] as t1 inner join timetableofsubject as t2 on t1.subjectcode=t2.subjectcode where t1.StudentCode ='"+code+"'";
        return getDataByQuery(sql);
    }
    public DataTable getLearningSubject(string code)
    {
        string sql = "select subjectcode from classattendence where studentcode = '" + code + "';";
        return getDataByQuery(sql);
    }
    public DataTable getSubject(string subjectcode)
    {
        string sql = "select subjectname from subject where subjectcode = '" + subjectcode + "'";
        return getDataByQuery(sql);
    }
    public DataTable getAttendence(String code)
    {
        string sql = "select * from classattendence where studentcode = '" + code + "';";
        return getDataByQuery(sql);
    }
    public string getTimetableByClass(string classname)
    {
        string sql = "select slot from timetableofsubject where subjectcode = '" + classname + "'";
        DataTable tbl= getDataByQuery(sql);
        foreach(DataRow dr in tbl.Rows)
        {
            sql = dr[0].ToString();
        }
        return sql;
    }
    public ClassAttend GetClassAttendenceByStudentIDandSubject(string student,string subject)
    {
        string sql = "select * from classattendence where subjectcode = '" + subject + "' and studentcode ='" + student + "'";
        List<string> arr = new List<string>();
        DataTable tbl = getDataByQuery(sql);
        ClassAttend c = null;
        foreach(DataRow dr in tbl.Rows)
        {
            for(int i = 0; i < 30; i++)
            {
                arr.Add(dr[i + 3].ToString());
            }
            c = new ClassAttend(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), arr);
        }
        return c;
    }
    public string getSubjectByCode(string code)
    {
        string sql = "select subjectname from subject where subjectcode ='" + code + "';";
        DataTable tbl = getDataByQuery(sql);
        string subejct = null;
        foreach(DataRow dr in tbl.Rows)
        {
            subejct = dr[0].ToString();
        }
        return subejct;
    }
    public List<string> listofsubjectcode()
    {
        string sql = "select Column_name from Information_schema.columns where Table_name like 'StudentRecord'";
        DataTable dt = getDataByQuery(sql);
        List<string> arr = new List<string>();
        foreach(DataRow dr in dt.Rows)
        {
            arr.Add(dr[0].ToString());
        }
        return arr;
    }
    public List<string> getTypeOfGrade()
    {
        string sql = "select Column_name from Information_schema.columns where Table_name like 'Classattendence'";
        DataTable dt = getDataByQuery(sql);
        List<string> arr = new List<string>();
        int i = 0;
       foreach(DataRow dr in dt.Rows)
        {
            i++;
            if (i >= 34)
            {
                arr.Add(dr[0].ToString());
            }
        }
        return arr;
    }
    public DataTable getAllSubjectsOfTeacher(string name)
    {
        string sql = "select * from TimetableOfSubject where Teacher='" + name + "'";
        return getDataByQuery(sql);
    }

    public DataTable getTimeTableByRoom(string room)
    {
        string sql = "select * from TimetableOfSubject where Room='" + room + "'";
        return getDataByQuery(sql);
    }

    public DataTable getNameOfSubjectByCode(string code)
    {
        string sql = "select SubjectName from Subject where SubjectCode='" + code + "'";
        return getDataByQuery(sql);
    }

    public DataTable getNameOfAllRoom()
    {
        string sql = "select  distinct Room from TimetableOfSubject";
        return getDataByQuery(sql);
    }

    public int takeAttendanceForAClass(int slotNo, string result, string classCode, string sCode)
    {
        string slott = "slot " + slotNo;
        string sql = @"update ClassAttendence set [" + slott + "] =@result where SubjectCode=@classCode and StudentCode=@sCode";


        SqlConnection connect = new SqlConnection(getConnectionString());
        SqlCommand command = new SqlCommand(sql, connect);
        connect.Open();
        //SqlParameter param1 = new SqlParameter("@slott", SqlDbType.VarChar);
        SqlParameter param2 = new SqlParameter("@result", SqlDbType.VarChar);
        SqlParameter param3 = new SqlParameter("@classCode", SqlDbType.VarChar);
        SqlParameter param4 = new SqlParameter("@sCode", SqlDbType.VarChar);


        // param1.Value = slott;
        param2.Value = result;
        param3.Value = classCode;
        param4.Value = sCode;

        //command.Parameters.Add(param1);
        command.Parameters.Add(param2);
        command.Parameters.Add(param3);
        command.Parameters.Add(param4);

        int count = command.ExecuteNonQuery();
        command.Connection.Close();


        return count;
    }



    public DataTable getStudentListByClassCode(string code)
    {
        string sql = "select ClassAttendence.StudentCode, StudentInfo.StudentFullName from ClassAttendence\n"
+ " Inner join StudentInfo on ClassAttendence.StudentCode=StudentInfo.StudentCode\n"
+ " where SubjectCode='" + code + "'";
        return getDataByQuery(sql);
    }
}
